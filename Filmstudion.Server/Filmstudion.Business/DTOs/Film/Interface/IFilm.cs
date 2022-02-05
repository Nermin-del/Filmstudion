using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.DTOs.Film.Interface
{
    public interface IFilm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FilmCopies { get; set; }
        public DateTime Created { get; set; }
        public DateTime Established { get; set; }
    }
}
