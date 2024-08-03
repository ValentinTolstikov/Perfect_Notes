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
                try
                {
                    await _userService.RegisterUser(model);
                    return Redirect("/login");
                }
                catch (Exception ex)
                {
                    ViewData.Add("err", ex.Message);
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
