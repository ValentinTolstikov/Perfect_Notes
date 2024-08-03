using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Notes.WEB.Pages.Main
{
    [Authorize]
    public class MainPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
