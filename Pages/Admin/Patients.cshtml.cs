using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospitalPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Net;

namespace HospitalPortal.Pages.Admin
{
    [Authorize]
    public class PatientsModel : PageModel
    {
        public List<Patient> Patients { get; set; } = null!;
        private readonly ApiSettings _apiSettings;
        private readonly HttpClient _httpClient;
        private readonly string _deployedUrl;
        public bool isLoading { get; set; } = true;

        public PatientsModel(HttpClient httpClient, ApiSettings apiSettings, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
            _deployedUrl = configuration["DeployedUrl"]!;
        }
        public async Task OnGetAsync()
        {
            try
            {
                Patients = await _httpClient.GetFromJsonAsync<List<Patient>>($"{_apiSettings.BaseUrl}/patients");
                isLoading = false;
            }
            catch (Exception ex)
            {
                // Optionally log error
                ModelState.AddModelError("Error", ex.Message);
            }
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
