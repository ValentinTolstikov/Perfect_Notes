using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Interfaces
{
    public interface ILoginRequest
    {
        public string Login { get; set; } 
        public string Password { get; set; }
    }
}
