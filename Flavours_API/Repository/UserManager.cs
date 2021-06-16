using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yum_PractiseCheck.Context;
using Yum_PractiseCheck.Models;
using Yum_PractiseCheck.Repository.IRepository;

namespace Yum_PractiseCheck.Repository
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext _context;

        public UserManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == id);
            if(user == null)
            {
                return null;
            }
            return user;
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
