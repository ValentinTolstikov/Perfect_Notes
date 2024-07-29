using Notes.DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DB.Repository
{
    public interface IUserRepository
    {
        public User GetById(int id);
        public User Login(string username, string password);
        public Task<int> Create(User user);
        public bool IsUserExist(int id);
        public bool IsUserUnique(string username);
    }
}
