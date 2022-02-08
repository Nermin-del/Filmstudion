using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.DTOs.User.Interface
{
    public interface IUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
