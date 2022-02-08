using Filmstudion.Models.Film;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Filmstudion.Models.FilmStudio.Interface;

namespace Filmstudion.Models.FilmStudio
{
    public class FilmStudio : IFilmStudio
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<FilmCopies> FilmCopies { get; set; } = new List<FilmCopies>();
        public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }

    }
}
