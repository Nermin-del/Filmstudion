using Filmstudion.Business.DTOs.Film.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.DTOs.Film
{
    public class UpdateFilmDto : IUpdateFilm
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
