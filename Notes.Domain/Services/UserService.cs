using Notes.DB.Repository;
using Notes.Domain.Interfaces;

namespace Notes.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task Login(ILoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public Task<int> Register(IRegistrationRequest registrationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
