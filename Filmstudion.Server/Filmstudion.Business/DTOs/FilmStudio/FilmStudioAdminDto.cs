using Filmstudion.Business.DTOs.FilmStudio.Interface;
using Filmstudion.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.DTOs.FilmStudio
{
    public class FilmStudioAdminDto : IFilmStudio
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<FilmCopies> Rentedlist { get; set; } = new List<FilmCopies>();
        public string Role { get; set; }
    }
}
