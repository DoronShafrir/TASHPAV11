using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TASHPAV11.Model;

namespace TASHPAV11.Pages.Login
{
    public class ExitModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.SetString("Admin", "");
            HttpContext.Session.SetString("Username","" );
            HttpContext.Session.SetString("FirstName","");
            HttpContext.Session.SetString("LastName", "");
            HttpContext.Session.SetString("SId", "");
            return RedirectToPage("/Index");
        }
    }
}
