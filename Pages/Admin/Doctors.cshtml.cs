using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HospitalPortal.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sustainsys.Saml2.Configuration;

namespace HospitalPortal.Pages.Admin
{
    [Authorize]
    public class DoctorsModel : PageModel
    {
        public List<Doctor> Doctors { get; set; } = new();
        private readonly ApiSettings _apiSettings;
        private readonly HttpClient _httpClient;
        private readonly string _deployedUrl;

        public DoctorsModel(HttpClient httpClient, ApiSettings apiSettings, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
            _deployedUrl = configuration["DeployedUrl"]!;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true)
            {
                return RedirectToPage("/Unauthorized");
            }

            Doctors = await _httpClient.GetFromJsonAsync<List<Doctor>>($"{_apiSettings.BaseUrl}/doctors");

            return Page();
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
