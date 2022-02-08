using Filmstudion.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.Services.Interface
{
    public interface IUserService
    {
        bool IsUniqueName(string username);
        ICollection<User> GetUsers();
        User Register(string username, string password, bool isAdmin);
        User Authenticate(string username, string password);
    }
}
