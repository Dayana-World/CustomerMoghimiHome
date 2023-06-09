﻿using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.StaticPages;

public partial class ContactUs
{
	#region Pre-Load
	ContactFormDto model = new();
	#endregion

	#region Actions
	public async Task Add()
	{
        var authstate = await _apiAuthenticationStateProvider.GetAuthenticationStateAsync();
        model.UserName = authstate.User.Identity.Name ?? "";
        using var response = await _httpService.PostValue(CustomerRoute.ContactForm + CRUDRouts.Create, model);
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
}
