using System;
using System.ComponentModel.DataAnnotations;

namespace Filmstudion.Web.Models
{
    public class Film
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
