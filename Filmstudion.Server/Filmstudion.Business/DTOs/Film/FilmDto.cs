using Filmstudion.Business.DTOs.Film.Interface;
using Filmstudion.DataAccess.Repository.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.Models.DTOs.Film
{
    public class FilmDto : ICreateFilm
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int FilmCopies { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }

    }
}
