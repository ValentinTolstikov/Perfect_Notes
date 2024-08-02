using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Domain.Services;
using Notes.WEB.DTO;

namespace Notes.WEB.Pages.Authorization
{
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {

        }

        public void OnPost(LoginRequestDTO request) 
        {
            
        }    
    }
}
