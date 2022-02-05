using Filmstudion.Business.Services.Interface;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository repository;


        public FilmService(IFilmRepository repository)
        {
            this.repository = repository;
        }

        public bool CreateFilm(Film model)
        {
            return repository.CreateFilm(model);

        }

        public bool DeleteFilm(Film model)
        {
            return repository.DeleteFilm(model);

        }

        public Film GetFilmById(int Id)
        {
            return repository.GetFilmById(Id);
        }

        public ICollection<Film> GetFilms()
        {
            return repository.GetFilms();
        }

        public bool FilmExists(string title)
        {
            return repository.FilmExists(title);
        }

        public bool FilmExists(int id)
        {
            return repository.FilmExists(id);
        }


        public bool Save()
        {
            return repository.Save();
        }

        public bool UpdateFilm(Film model)
        {
            return repository.UpdateFilm(model);
        }
    }
}
