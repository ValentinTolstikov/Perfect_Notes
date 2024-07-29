using Notes.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Services
{
    public interface IUserService
    {
        public Task Login(LoginRequestDTO loginRequest);
        public void Logout();
        public Task<int> Register(RegistrationRequestDTO registrationRequest);
    }
}
