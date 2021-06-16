using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yum_PractiseCheck.Models;

namespace Yum_PractiseCheck.Repository.IRepository
{
    public interface IUserManager
    {
        public User GetUserById(int id);
        public bool CreateUser(User user);
        public bool Save();

    }
}
