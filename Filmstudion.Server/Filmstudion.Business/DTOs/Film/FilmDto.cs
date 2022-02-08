using Filmstudion.Business.DTOs.Film.Interface;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.Film;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.Models.DTOs.Film
{
    public class FilmDto : ICreateFilm
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public byte[] Picture { get; set; }
        public DateTime Established { get; set; }

    }
}
