using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.DTOs.User.Interface
{
    public interface IUserRegister
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
