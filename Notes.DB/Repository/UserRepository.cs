using Notes.DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DB.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NotesDbContext _context;

        public UserRepository(NotesDbContext context)
        {
            _context = context;
        }

        public Task<int> Create(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public bool IsUserExist(int id)
        {
            return _context.Users.Find(id) != null;
        }

        public bool IsUserUnique(string username)
        {
            return _context.Users.Where(u=>u.Login==username).Count() == 0;
        }

        public User? Login(string username, string hashed_password)
        {
            return _context.Users.FirstOrDefault(u => u.Login == username && u.HashedPassword == hashed_password);
        }
    }
}
