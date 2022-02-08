using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Models.Film
{
    public class FilmCopies
    {
        public int Id { get; set; }
        public string StudioId { get; set; }
        public string FilmId { get; set; }
        public int Amount { get; set; }
    }
}
