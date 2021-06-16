using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yum_PractiseCheck.Repository.IRepository
{
    public interface IAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
