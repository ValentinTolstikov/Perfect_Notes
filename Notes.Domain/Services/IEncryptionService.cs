using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Services
{
    public interface IEncryptionService
    {
        string EncryptValue(string value);
    }
}
