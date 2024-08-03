using Notes.DB.Entity;
using Notes.Domain.Interfaces;

namespace Notes.Domain.Services
{
    public interface IUserService
    {
        public User? AuthUser(ILoginRequest request);
        public Task<int> RegisterUser(IRegistrationRequest request);
    }
}
