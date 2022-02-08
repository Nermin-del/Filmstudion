using Filmstudion.Models.FilmStudio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Models.Filmstudio
{
    public class RegisterFilmStudio : IRegisterFilmStudio
    {
        public string Username {get; set;}
        public string Password { get; set; }
    }
}
