using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.DTOs.Film.Interface
{
    public interface IUpdateFilm
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
