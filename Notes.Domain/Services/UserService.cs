using Microsoft.AspNetCore.Http;
using Notes.DB.Entity;
using Notes.DB.Repository;
using Notes.Domain.Interfaces;
using System.Net.Http;
using System.Security.Claims;

namespace Notes.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryption;

        public UserService(IUserRepository userRepository,IEncryptionService encryption)
        {
            _userRepository = userRepository;
            _encryption = encryption;
        }

        public User? AuthUser(ILoginRequest request)
        {
            string hashedPassword = _encryption.EncryptValue(request.Password);
            User user = _userRepository.Login(request.Login,hashedPassword);
            return user;
        }

        public async Task<int> RegisterUser(IRegistrationRequest request)
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

                return await _userRepository.Create(user);
            }
            else
            {
                return -1;
            }
        }
    }
}
