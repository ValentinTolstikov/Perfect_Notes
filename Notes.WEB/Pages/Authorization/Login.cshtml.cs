using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Domain.Services;

namespace Notes.WEB.Pages.Authorization
{
    public class LoginModel : PageModel
    {
        private IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {

        }
    }
}
