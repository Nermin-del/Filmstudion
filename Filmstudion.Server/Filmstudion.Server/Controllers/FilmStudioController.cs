using Filmstudion.Business.Services;
using Filmstudion.Business.Services.Interface;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.FilmStudio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmstudion.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmStudioController : ControllerBase
    {
        private readonly IFilmStudioService filmStudioService;
        public FilmStudioController(IFilmStudioService filmStudioService)
        {
            this.filmStudioService = filmStudioService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] FilmStudio model)
        {
            var creatingUser = filmStudioService.Authenticate(model.Username, model.Password);
            if (creatingUser == null)
            {
                return BadRequest(new { message = "Felaktig användarnamn eller lösenord" });
            }
            return Ok(creatingUser);

        }

        [HttpPost]
        public IActionResult register()
        {
            return NoContent();
        }

    }
}
