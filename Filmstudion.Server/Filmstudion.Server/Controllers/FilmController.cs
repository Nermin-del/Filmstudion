using AutoMapper;
using Filmstudion.Business.DTOs.Film;
using Filmstudion.Business.Services.Interface;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.DTOs;
using Filmstudion.Models.DTOs.Film;
using Filmstudion.Models.Film;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Filmstudion.Server.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        
        private readonly IFilmService filmService;
        private readonly IMapper mapper;
        public FilmController(IMapper mapper, IFilmService filmService)
        {
            this.mapper = mapper;
            this.filmService = filmService;
            
        }

        /// <summary>
        /// Get list of all films
        /// </summary>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllFilms()
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

            if(role == "admin" || role == "filmstudio") 
            {
                var filmList = filmService.GetFilms();

                var filmDto = new List<FilmAdminDto>();


                foreach (var film in filmList)
                {
                    filmDto.Add(mapper.Map<FilmAdminDto>(film));
                }

                return Ok(filmDto);
            }
            else 
            {
                var filmList = filmService.GetFilms();

                var filmDto = new List<FilmDto>();


                foreach (var film in filmList)
                {
                    filmDto.Add(mapper.Map<FilmDto>(film));
                }

                return Ok(filmDto);
            }
        }

        /// <summary>
        /// Get a specific film
        /// </summary>
        /// <param name="filmId"> Get Id of a specific film</param>
        /// <returns></returns>
        [HttpGet("{filmId:int}", Name = "GetFilmById")]
        [AllowAnonymous]
        public IActionResult GetFilmById(int filmId)
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

            var film = filmService.GetFilmById(filmId);
            if (film == null)
            {
                return NotFound();
            }

            if(role == "admin" || role == "filmstudio") 
            {
                var filmAdminDto = mapper.Map<FilmAdminDto>(film);
                return Ok(filmAdminDto);
            }
            else 
            {
                var filmDto = mapper.Map<FilmDto>(film);
                return Ok(filmDto);
            }

        }

        /// <summary>
        /// Create film
        /// </summary>
        /// <param name="filmDto"> Create a film</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateFilm([FromBody] CreateFilmDto model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }

            if (filmService.FilmExists(model.Title))
            {
                ModelState.AddModelError("", "Filmen existerar!");
                return StatusCode(404, ModelState);
            }

            var filmItem = mapper.Map<Film>(model);

            if (!filmService.CreateFilm(filmItem))
            {
                ModelState.AddModelError("", $"Något gick fel när {filmItem.Title} skulle sparas");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetFilmById", new { filmId = filmItem.Id }, filmItem);
        }

        /// <summary>
        /// Update Film
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="model">Update film</param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "admin")]
        [HttpPatch("{filmId:int}", Name = "UpdateFilm")]
        public IActionResult UpdateFilm(int Id, [FromBody] UpdateFilmDto model)
        {
            if (model == null || Id != model.Id)
            {
                return BadRequest(ModelState);
            }

            var filmItem = mapper.Map<Film>(model);

            if (!filmService.UpdateFilm(filmItem))
            {
                ModelState.AddModelError("", $"Något gick fel när {filmItem.Title} skulle updateras");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete film
        /// </summary>
        /// <param name="filmId">Delete a specific film</param>
        /// <returns></returns>
        [HttpDelete("{filmId:int}", Name = "DeleteFilm")]
        public IActionResult DeleteFilm(int filmId)
        {
            if (!filmService.FilmExists(filmId))
            {
                return NotFound();
            }

            var filmItem = filmService.GetFilmById(filmId);

            if (!filmService.DeleteFilm(filmItem))
            {
                ModelState.AddModelError("", $"Något gick fel när {filmItem.Title} skulle raderas");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}

