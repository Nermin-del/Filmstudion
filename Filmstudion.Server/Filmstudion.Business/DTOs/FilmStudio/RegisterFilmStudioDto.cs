using Filmstudion.Business.DTOs.FilmStudio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.DTOs.FilmStudio
{
    public class RegisterFilmStudioDto : IRegisterFilmStudio
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
