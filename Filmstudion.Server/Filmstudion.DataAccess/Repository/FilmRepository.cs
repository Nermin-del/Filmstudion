using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.Film;
using Filmstudion.Models.FilmStudio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.DataAccess.Repository
{
    public class FilmRepository : IFilmRepository
    {

        private readonly AppDbContext db;

        public FilmRepository(AppDbContext db)
        {
            this.db = db;
        }

        public bool CreateFilm(Film model)
        {
            db.Film.Add(model);
            return Save();
        }

        public bool DeleteFilm(Film model)
        {
            
           var test = db.Film.Remove(model);
            return Save();
        }

        public Film GetFilmById(int Id)
        {
            return db.Film.FirstOrDefault(a => a.Id == Id);
        }

        public ICollection<Film> GetFilms()
        {
            return db.Film.OrderBy(a => a.Title).ToList();
        }

        public bool FilmExists(string title)
        {
            bool value = db.Film.Any(a => a.Title.ToLower().Trim() == title.ToLower().Trim());
            return value;
        }

        public bool FilmExists(int id)
        {
            return db.Film.Any(a => a.Id == id);
        }


        public bool Save()
        {
            return db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateFilm(Film model)
        {
            db.Film.Update(model);
            return Save();
        }

    }
}
