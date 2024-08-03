using Microsoft.EntityFrameworkCore;
using Notes.DB.Entity;
using Notes.DB.Repository;
using Notes.Domain.Interfaces;
using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Notes.Domain.Exceptions;

namespace Notes.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryption;
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _context;

        public UserService(IUserRepository userRepository,IEncryptionService encryption, Microsoft.AspNetCore.Http.IHttpContextAccessor context)
        {
            _userRepository = userRepository;
            _encryption = encryption;
            _context = context;
        }

        public Task AuthUser(ILoginRequest request)
        {
            string hashedPassword = _encryption.EncryptValue(request.Password);
            User user = _userRepository.Login(request.Login,hashedPassword);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, request.Login)
                };

                ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return _context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            }
            else
            {
                throw new UserNotFoundExceprion("Пользователь не найден");
            }
        }

        public async Task RegisterUser(IRegistrationRequest request)
        {
            User user = new User();
            if (_userRepository.IsUserUnique(request.Login))
            {
                user.Login = request.Login;
                user.Email = request.Email;
                user.Surname = request.Surname;
                user.Name = request.Name;
                user.Age = request.Age;
                user.HashedPassword = _encryption.EncryptValue(request.Password);
                await _userRepository.Create(user);
            }
            else
            {
                throw new UserNotUniqueException("Имя пользователя должно быть уникальным");
            }
        }

        public Task Logout()
        {
            return _context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
