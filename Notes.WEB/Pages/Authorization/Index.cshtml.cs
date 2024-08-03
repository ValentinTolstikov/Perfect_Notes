using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Notes.WEB.Pages.Authorization
{
    public class IndexModel : PageModel
    {
        public RedirectResult OnGet()
        {
            return Redirect("/login");
        }
    }
}
