using Filmstudion.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.DataAccess.Repository.Interface
{
    public interface IUserRepository
    {
        bool IsUniqueName(string username);
        ICollection<User> GetUsers();
        User Authenticate(string username, string password);
        User Register(string username, string password, bool isAdmin);
    }
}
