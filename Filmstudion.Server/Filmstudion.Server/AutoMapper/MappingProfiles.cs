using AutoMapper;
using Filmstudion.Business.DTOs.Film;
using Filmstudion.Models.DTOs;
using Filmstudion.Models.DTOs.Film;
using Filmstudion.Models.Film;

namespace Filmstudion.Server.FilmMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Film, FilmDto>().ReverseMap();
            CreateMap<Film, CreateFilmDto>().ReverseMap();
            CreateMap<Film, UpdateFilmDto>().ReverseMap();
        }
    }
}
