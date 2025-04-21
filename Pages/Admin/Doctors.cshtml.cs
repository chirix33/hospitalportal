using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalPortal.Pages.Admin
{
    public class DoctorsModel : PageModel
    {
        [Authorize]
        public void OnGet()
        {
        }
    }
}
