using Notes.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Notes.WEB.DTO
{
    public class LoginRequestDTO:ILoginRequest
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Login {  get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
