using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.Exceptions
{
    public class UserNotUniqueException:Exception
    {
        public UserNotUniqueException(string text) : base(text) { }
    }
}
