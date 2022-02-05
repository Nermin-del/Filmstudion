using System;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.Models.Film
{
    public class Film 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int FilmCopies { get; set; }
        public DateTime Created { get; set; }
     

    }
}
