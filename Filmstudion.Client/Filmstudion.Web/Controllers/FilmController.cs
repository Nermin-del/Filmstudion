using Filmstudion.Web.Models;
using Filmstudion.Web.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Filmstudion.Web.Controllers
{
    public class FilmController : Controller
    {

        private readonly IFilmRepository filmRepo;

        public FilmController(IFilmRepository filmRepo)
        {
            this.filmRepo = filmRepo;
        }

        public IActionResult Index()
        {
            return View(new Film() { });
        }

        public async Task<IActionResult> GetAllFilms()
        {
            return Json(new { data = await filmRepo.GetAllAsync(SD.FilmApiPath) });
        }
    }
}
