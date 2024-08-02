using Notes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Services
{
    public interface IUserService
    {
        public Task Login(ILoginRequest loginRequest);
        public void Logout();
        public Task<int> Register(IRegistrationRequest registrationRequest);
    }
}
