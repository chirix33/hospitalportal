using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospitalPortal.Models;

namespace HospitalPortal.Pages.Admin
{
    [Authorize]
    public class DrugsModel : PageModel
    {
        private readonly ApiSettings _apiSettings;
        private readonly HttpClient _httpClient;
        private readonly string _deployedUrl;

        public DrugsModel(ApiSettings apiSettings, HttpClient httpClient, IConfiguration configuration)
        {
            _apiSettings = apiSettings;
            _httpClient = httpClient;
            _deployedUrl = configuration["DeployedUrl"]!;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogout()
        {
            return SignOut(new AuthenticationProperties
            {
                RedirectUri = $"https://dev-51454621.okta.com/login/signout?fromURI={WebUtility.UrlEncode(_deployedUrl)}"
                //RedirectUri = _deployedUrl
            },
            CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
