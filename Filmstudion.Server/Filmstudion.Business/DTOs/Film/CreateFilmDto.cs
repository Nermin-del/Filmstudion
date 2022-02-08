using Filmstudion.Business.DTOs.Film.Interface;
using Filmstudion.Models.Film;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.DTOs.Film
{
    public class CreateFilmDto : ICreateFilm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FilmCopies { get; set; }
        public DateTime Created { get; set; }
    }
}
