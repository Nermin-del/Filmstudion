using Filmstudion.Business.Services.Interface;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;


        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public User Authenticate(string username, string password)
        {
            return repository.Authenticate(username, password);

        }

        public bool IsUniqueName(string username)
        {
            return repository.IsUniqueName(username);

        }

        public User Register(string username, string password, bool isAdmin)
        {
            return repository.Register(username, password, isAdmin);
        }

        public ICollection<User> GetUsers()
        {
            return repository.GetUsers();
        }
    }
}
