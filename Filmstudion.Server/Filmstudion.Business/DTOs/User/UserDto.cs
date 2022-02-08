using Filmstudion.Business.DTOs.User.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.DTOs.User

{
    public class UserDto : IUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

       
    }
}
