using Microsoft.AspNetCore.Mvc;
using Notes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.WEB.DTO
{
    public class RegistrationRequestDTO : IRegistrationRequest
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Surname { get; set; }
        [BindProperty]
        public string Login { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public int Age { get; set; }
    }
}
