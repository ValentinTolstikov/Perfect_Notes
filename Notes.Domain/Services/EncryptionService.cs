using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string EncryptValue(string value)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            string result = "";

            foreach (var b in hash)
            {
                result += b.ToString("x2");
            }

            return result;
        }
    }
}
