using AutoMapper;
using Filmstudion.Business.DTOs.Film;
using Filmstudion.Business.DTOs.FilmStudio;
using Filmstudion.Business.DTOs.User;
using Filmstudion.Models.DTOs;
using Filmstudion.Models.DTOs.Film;
using Filmstudion.Models.Film;
using Filmstudion.Models.FilmStudio;
using Filmstudion.Models.Users;

namespace Filmstudion.Server.FilmMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<FilmStudio, RegisterFilmStudioDto>().ReverseMap();
            CreateMap<FilmStudio, FilmStudioDto>().ReverseMap();
            CreateMap<FilmStudio, FilmStudioAdminDto>().ReverseMap();
            CreateMap<Film, FilmDto>().ReverseMap();
            CreateMap<Film, FilmAdminDto>().ReverseMap();
            CreateMap<Film, CreateFilmDto>().ReverseMap();
            CreateMap<Film, UpdateFilmDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();
        }
    }
}
