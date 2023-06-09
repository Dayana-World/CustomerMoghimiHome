﻿using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Seo;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Net.Http.Headers;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.File;

public partial class AdminUploadImagePage
{
    #region Actions
    [Parameter]
    public EventCallback<string> OnChange { get; set; }

    List<AltDto> altList = new();
    private string AltSelectedValue { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        altList = await _httpService.GetValueList<AltDto>(SeoRoutes.Alt + CRUDRouts.ReadAll);
    }
    private async Task UploadImageAction(InputFileChangeEventArgs e)
    {
        var imageFiles = e.GetMultipleFiles();
        foreach (var imageFile in imageFiles)
        {
            if (imageFile != null)
            {
                var resizedFile = await imageFile.RequestImageFileAsync("image/png", 300, 500);
                using (var ms = resizedFile.OpenReadStream(resizedFile.Size))
                {
                    var content = new MultipartFormDataContent();
                    content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                    content.Add(new StreamContent(ms, Convert.ToInt32(resizedFile.Size)), "image", imageFile.Name);
                    var ImgResponse = await _httpService.UploadImage(content, FileRoutes.StaticFile + CRUDRouts.Create, AltSelectedValue);
                    if (ImgResponse == "Image Path Exist")
                    {
                        _snackbar.Add("عکس با نام تکراری موجود است.", Severity.Warning);
                    }
                    else
                    {
                        _snackbar.Add("عکس با موفقیت آپلود شد.", Severity.Success);
                        await OnChange.InvokeAsync();
                    }
                }
            }
        }

    }
    #endregion
}
