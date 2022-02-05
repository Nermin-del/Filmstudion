using Filmstudion.Models.FilmStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.Business.Services.Interface
{
    public interface IFilmStudioService
    {
        FilmStudio Authenticate(string username, string password);
        bool IsUniqueUser(string username);
        FilmStudio Register(string username, string password);
    }
}
