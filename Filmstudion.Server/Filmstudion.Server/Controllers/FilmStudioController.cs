using AutoMapper;
using Filmstudion.Business.DTOs.FilmStudio;
using Filmstudion.Business.DTOs.User;
using Filmstudion.Business.Services.Interface;
using Filmstudion.Models.DTOs.Film;
using Filmstudion.Models.FilmStudio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Filmstudion.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmStudioController : ControllerBase
    {
        private readonly IFilmStudioService filmStudioService;
        private readonly IMapper mapper;
        public FilmStudioController(IMapper mapper, IFilmStudioService filmStudioService)
        {
            this.mapper = mapper;
            this.filmStudioService = filmStudioService;
        }

        /// <summary>
        /// Get a specific film
        /// </summary>
        /// <param name="filmStudioId"> Id of filmstudio</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{filmStudioId:int}", Name = "GetFilmStudioById")]
        public IActionResult GetFilmById(int filmStudioId)
        {
            var role = "";
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            
            if(token != null && token != "") {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadJwtToken(token);

                    foreach (var claim in jsonToken.Claims) {
                        if (claim.Type == "role") {
                            role = claim.Value;
                        }
                    }
            }

            var filmstudioList = filmStudioService.GetFilmStudios();
            var selectedStudio = filmstudioList.FirstOrDefault(filmStudio => filmStudio.Id == filmStudioId);
            if(role == "admin") {
                var filmStudioAdminDto = mapper.Map<FilmStudioAdminDto>(selectedStudio);
                return Ok(filmStudioAdminDto);
            }
            else {
                var filmstudioDto = mapper.Map<FilmStudioDto>(selectedStudio);

                return Ok(filmstudioDto);
             }
        }


        [Authorize]
        [HttpGet]
        public IActionResult GetAllFilmStudios()
        {
            var role = "";
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            
            if(token != null && token != "") {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadJwtToken(token);

                    foreach (var claim in jsonToken.Claims) {
                        if (claim.Type == "role") {
                            role = claim.Value;
                        }
                    }
            }

            var filmstudioList = filmStudioService.GetFilmStudios();
            
            if(role == "admin") {
                var filmStudioAdminDto = new List<FilmStudioAdminDto>();
                foreach (var studio in filmstudioList)
                {
                    filmStudioAdminDto.Add(mapper.Map<FilmStudioAdminDto>(studio));
                }

                return Ok(filmStudioAdminDto);
            }
            else {
                var filmstudioDto = new List<FilmStudioDto>();
                foreach (var studio in filmstudioList)
                {
                    filmstudioDto.Add(mapper.Map<FilmStudioDto>(studio));
                }

                return Ok(filmstudioDto);
             }
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] RegisterFilmStudioDto model)
        {
            var creatingUser = filmStudioService.Authenticate(model.Username, model.Password);
            if (creatingUser == null)
            {
                return BadRequest(new { message = "Felaktig användarnamn eller lösenord" });
            }
            return Ok(creatingUser);

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterFilmStudioDto model)
        {
            bool ifUsernameUnique = filmStudioService.IsUniqueUser(model.Username);
            if (!ifUsernameUnique)
            {
                return BadRequest(new { message = "Användarnamnet finns redan!" });
            }
            var user = filmStudioService.Register(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Något gick fel med registreringen" });
            }

            return Ok(model);
        }

    }
}
