using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.Film;
using Filmstudion.Models.FilmStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.DataAccess.Repository
{
    public class FilmRepository : IFilmRepository
    {

        private readonly AppDbContext _db;

        public FilmRepository(AppDbContext db)
        {
            _db = db;
        }

        public bool CreateFilm(Film model)
        {
            _db.Film.Add(model);
            return Save();
        }

        public bool DeleteFilm(Film model)
        {
            _db.Film.Remove(model);
            return Save();
        }

        public Film GetFilmById(int Id)
        {
            return _db.Film.FirstOrDefault(a => a.Id == Id);
        }

        public ICollection<Film> GetFilms()
        {
            return _db.Film.OrderBy(a => a.Title).ToList();
        }

        public bool FilmExists(string title)
        {
            bool value = _db.Film.Any(a => a.Title.ToLower().Trim() == title.ToLower().Trim());
            return value;
        }

        public bool FilmExists(int id)
        {
            return _db.Film.Any(a => a.Id == id);
        }


        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateFilm(Film model)
        {
            _db.Film.Update(model);
            return Save();
        }

    }
}
