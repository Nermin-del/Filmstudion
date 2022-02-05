using Filmstudion.Business.Services.Interface;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.FilmStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}

