using Notes.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Notes.WEB.DTO
{
    public class LoginRequestDTO:ILoginRequest
    {
        [BindProperty]
        public string Login {  get; set; }
        [BindProperty]
        public string Password { get; set; }
    }
}
