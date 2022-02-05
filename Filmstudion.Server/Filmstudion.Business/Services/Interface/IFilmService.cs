using Filmstudion.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.Services.Interface
{
    public interface IFilmService
    {
        ICollection<Film> GetFilms();
        bool CreateFilm(Film model);
        bool DeleteFilm(Film model);
        bool UpdateFilm(Film model);
        bool FilmExists(string title);
        bool FilmExists(int id);
        bool Save();
        Film GetFilmById(int Id);


    }
}
