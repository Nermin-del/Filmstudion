using Filmstudion.Web.Models;
using Filmstudion.Web.Repository.IRepository;
using System.Net.Http;

namespace Filmstudion.Web.Repository
{
    public class FilmRepository : Repository<Film>, IFilmRepository
    {
        private readonly IHttpClientFactory clientFactory;

        public FilmRepository(IHttpClientFactory clientFactory) : base(clientFactory)

        {
            this.clientFactory = clientFactory;
        }
    }
}