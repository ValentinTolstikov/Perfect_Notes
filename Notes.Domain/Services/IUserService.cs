using Notes.DB.Entity;
using Notes.Domain.Interfaces;

namespace Notes.Domain.Services
{
    public interface IUserService
    {
        public Task AuthUser(ILoginRequest request);
        public Task Logout();
        public Task RegisterUser(IRegistrationRequest request);
    }
}
