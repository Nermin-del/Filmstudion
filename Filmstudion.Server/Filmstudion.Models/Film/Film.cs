using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Filmstudion.Models.Film
{
    public class Film 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int FilmCopies { get; set; } 
        public DateTime Created { get; set; }
        public byte[] Picture { get; set; }

    }
}
