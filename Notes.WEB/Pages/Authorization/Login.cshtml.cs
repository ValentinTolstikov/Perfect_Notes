using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.DB;
using Notes.DB.Entity;
using Notes.Domain.Services;
using Notes.WEB.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> OnPost(LoginRequestDTO request) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.AuthUser(request);
                    return Redirect("/Main/MainPage");
                }
                catch (Exception ex)
                {
                    ViewData["err"] = ex.Message;
                    return Page();
                }
            }
            else
            {
                ViewData["err"] = "Всему пиздец";
                return Page();
            }
        }
    }
}
