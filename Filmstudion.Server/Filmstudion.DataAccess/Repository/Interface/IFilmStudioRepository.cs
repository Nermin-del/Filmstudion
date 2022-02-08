using Filmstudion.Models.Filmstudio;
using Filmstudion.Models.FilmStudio;
using Filmstudion.Models.FilmStudio.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.DataAccess.Repository.Interface
{
    public interface IFilmStudioRepository
    {
        ICollection<FilmStudio> GetFilmStudios();

        FilmStudio Authenticate(string username, string password);
        bool IsUniqueUser(string username);
        FilmStudio Register(string username, string password);

    }
}

