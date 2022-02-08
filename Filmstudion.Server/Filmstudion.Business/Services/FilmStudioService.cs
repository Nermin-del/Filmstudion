using Filmstudion.Business.Services.Interface;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.Filmstudio;
using Filmstudion.Models.FilmStudio;
using Filmstudion.Models.FilmStudio.Interface;
using System.Collections.Generic;

namespace Filmstudion.Business.Services
{
    public class FilmStudioService : IFilmStudioService
    {
        private readonly IFilmStudioRepository repository;


        public FilmStudioService(IFilmStudioRepository repository)
        {
            this.repository = repository;
        }

        public FilmStudio Authenticate(string username, string password)
        {
            return repository.Authenticate(username, password);

        }

        public bool IsUniqueUser(string username)
        {
            return repository.IsUniqueUser(username);

        }

        public FilmStudio Register(string username, string password)
        {
            return repository.Register(username, password);
        }

        public ICollection<FilmStudio> GetFilmStudios()
        {
            return repository.GetFilmStudios();
        }
    }
}

