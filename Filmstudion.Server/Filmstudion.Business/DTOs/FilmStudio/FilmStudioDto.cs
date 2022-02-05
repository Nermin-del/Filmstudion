using Filmstudion.Business.DTOs.FilmStudio.Interface;
namespace Filmstudion.Business.DTOs.FilmStudio
{
    public class FilmStudioDto : IFilmStudio
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
