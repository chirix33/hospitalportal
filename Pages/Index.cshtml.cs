using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sustainsys.Saml2.AspNetCore2;

namespace HospitalPortal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnGetLogin()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/Admin/Patients" // Route to Patients after successful login
            }, Saml2Defaults.Scheme);
        }

    }
}
