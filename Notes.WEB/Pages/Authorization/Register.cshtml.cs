using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.DB.Entity;
using Notes.Domain.Services;
using Notes.WEB.DTO;
using System.Security.Claims;

namespace Notes.WEB.Pages.Authorization
{
    [ValidateAntiForgeryToken]
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

        public async Task<IActionResult> OnPost(RegistrationRequestDTO model)
        {
            if (ModelState.IsValid)
            {
                int res = await _userService.RegisterUser(model);
                if (res > 0)
                {
                    return Redirect("/login");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                    ViewData.Add("err", "Логин занят, попробуйте другой");
                }
            }
            return Page();
        }
    }
}
