using Filmstudion.Models.Film;
using Filmstudion.Models.FilmStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.DataAccess.Repository.Interface
{
    public interface IFilmRepository
    {
        ICollection<Film> GetFilms();
        Film GetFilmById(int filmId);
        bool FilmExists(string name);
        bool FilmExists(int id);
        bool CreateFilm(Film film);
        bool UpdateFilm(Film film);
        bool DeleteFilm(Film film);
        bool Save();
    }
}
