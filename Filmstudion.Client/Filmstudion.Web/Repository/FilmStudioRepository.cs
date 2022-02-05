using Filmstudion.Web.Models;
using Filmstudion.Web.Repository.IRepository;
using System.Net.Http;

namespace Filmstudion.Web.Repository
{

    public class FilmStudioRepository : Repository<FilmStudio>, IFilmStudioRepository
    {
        private readonly IHttpClientFactory clientFactory;

        public FilmStudioRepository(IHttpClientFactory clientFactory) : base(clientFactory)

        {
            this.clientFactory = clientFactory;
        }
    }
}
