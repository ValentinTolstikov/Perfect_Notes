using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Domain.Services;

namespace Notes.WEB.Pages.Authorization
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService) 
        { 
            _userService = userService;
        }

        public void OnGet()
        {
        }
    }
}
