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
        private readonly IHttpContextAccessor _context;

        public LoginModel(IUserService userService, IHttpContextAccessor context)
        {
            _userService = userService;
            _context = context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(LoginRequestDTO request) 
        {
            if (ModelState.IsValid)
            {
                User? user = _userService.AuthUser(request);
                if (user != null)
                {
                    await Authenticate(request.Login); // аутентификация
                    return Redirect("/Main/MainPage");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                ViewData.Add("err","Неверный логин или пароль");
            }
            return Page();
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/login");
        }
    }
}
