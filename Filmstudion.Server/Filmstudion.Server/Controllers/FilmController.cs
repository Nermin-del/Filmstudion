using AutoMapper;
using Filmstudion.Business.DTOs.Film;
using Filmstudion.Business.Services.Interface;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.DTOs;
using Filmstudion.Models.DTOs.Film;
using Filmstudion.Models.Film;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Filmstudion.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        
        private IFilmService filmService;
        private readonly IMapper _mapper;
        public FilmController(IMapper mapper, IFilmService filmService)
        {
            _mapper = mapper;
            this.filmService = filmService;
            
        }

        /// <summary>
        /// Get list of all films
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllFilms()
        {
            var filmList = filmService.GetFilms();

            var filmDto = new List<FilmDto>();


            foreach (var film in filmList)
            {
                filmDto.Add(_mapper.Map<FilmDto>(film));
            }

            return Ok(filmDto);
        }

        /// <summary>
        /// Get a specific film
        /// </summary>
        /// <param name="filmId"> Get Id of a specific film</param>
        /// <returns></returns>
        [HttpGet("{filmId:int}", Name = "GetFilmById")]
        public IActionResult GetFilmById(int filmId)
        {
            var film = filmService.GetFilmById(filmId);
            if (film == null)
            {
                return NotFound();
            }

            var filmDto = _mapper.Map<FilmDto>(film);
            return Ok(filmDto);
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

            var filmItem = _mapper.Map<Film>(model);

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
        [HttpPatch("{filmId:int}", Name = "UpdateFilm")]
        public IActionResult UpdateFilm(int Id, [FromBody] UpdateFilmDto model)
        {
            if (model == null || Id != model.Id)
            {
                return BadRequest(ModelState);
            }

            var filmItem = _mapper.Map<Film>(model);

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

