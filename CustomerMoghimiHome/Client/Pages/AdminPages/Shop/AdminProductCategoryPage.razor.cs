﻿using CustomerMoghimiHome.Client.Shared;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Shop;

public partial class AdminProductCategoryPage
{
    #region Pre-Load

    List<ImageDto> imagesList = new();
    private string ImageSelectedValue { get; set; }
    List<TagDto> tagList = new();
    private string value { get; set; } = "Nothing selected";
    private IEnumerable<string> options { get; set; } = new HashSet<string>();
    protected override async Task OnParametersSetAsync()
    {
        imagesList = await _httpService.GetValueList<ImageDto>(FileRoutes.GetAllImageFile);
        tagList = await _httpService.GetValueList<TagDto>(SeoRoutes.Tag + CRUDRouts.ReadAll);
    }

    #endregion

    #region Table

    private IEnumerable<ProductCategoryDto> pagedData;
    private MudTable<ProductCategoryDto> table;
    private string searchString = "";
    private ProductCategoryDto selectedItem = null;
    private bool isBusy = false;

    /// <summary>
    /// getting the paged, filtered and ordered data from the server
    /// </summary>
    private async Task<TableData<ProductCategoryDto>> ServerReload(TableState state)
    {
        DefaultPaginationFilter paginationFilter = new(state.Page, state.PageSize);
        var paginatedData = await _httpService.GetPagedValue<ProductCategoryDto>(ShopRoutes.ProductCategory + CRUDRouts.ReadListByFilter, paginationFilter);
        pagedData = paginatedData.Data;
        return new TableData<ProductCategoryDto>() { TotalItems = paginatedData.TotalCount, Items = pagedData };
    }

    #endregion

    #region Actions
    #region Add
    ProductCategoryDto model = new();
    public async Task Add()
    {
        model.ImagePath = ImageSelectedValue;
        model.Tags = string.Join(",", options);
        using var response = await _httpService.PostValue(ShopRoutes.ProductCategory + CRUDRouts.Create, model);
        if (response.IsSuccessStatusCode)
        {
            _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
        }
        else
        {
            _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
        }
    }
    #endregion

    #region Delete
    private async Task OnDelete(long id)
    {
        var parameters = new DialogParameters
        {
            { "ContentText", "آیا از حذف این آیتم مطمئن هستید؟ این عملیات قابل برگشت نیست. موارد مرتبط این دسته بندی حذف خواهند شد" },
            { "ButtonText", "حذف" },
            { "Color", Color.Error }
        };
        var dialog = await _dialogService.ShowAsync<CommonDialog>("Delete", parameters);
        var dialogResult = await dialog.Result;
        if (dialogResult.Canceled == false)
        {
            using var response = await _httpService.DeleteValue(ShopRoutes.ProductCategory + CRUDRouts.Delete + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
            }
            else
            {
                _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
            }
        }
        else
        {
            _snackbar.Add(".عملیات لغو شد", Severity.Info);
        }
    }
    #endregion

    #region Search
    private void OnSearch(string text)
    {
        searchString = text;
        table.ReloadServerData();
    }
    #endregion

    #region Edit
    private async Task Edit(long id)
    {
        _navigationManager.NavigateTo($"/pc-pc-cp-cp==cppc-edit/{id}");
    }
    #endregion
    #endregion
}
