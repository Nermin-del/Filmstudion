using filmstudion.server;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.FilmStudio;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.DataAccess.Repositorys
{
    public class FilmStudioRepository : IFilmStudioRepository
    {
        private readonly AppDbContext _db;
        private readonly AppSettings _appSettings;

        public FilmStudioRepository(AppDbContext db, IOptions<AppSettings> appsettings)
        {
            _db = db;
            _appSettings = appsettings.Value;
        }

        public FilmStudio Authenticate(string username, string password)
        {
            var user = _db.FilmStudioUser.SingleOrDefault(x => x.Username == username && x.Password == password);

            //user not found
            if (user == null)
            {
                return null;
            }

            //if user was found generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials
                                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = "";
            return user;
        }

        public bool IsUniqueUser(string username)
        {
            throw new NotImplementedException();
        }

        public FilmStudio Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}


// Skapa filmstudio bara genom att registrera.
// 1 admin login, 1 filmstudio login + registrering = filmstudioobjekt

//skapa 2 typer användare en admin och en filmstudio.

//Klient = logga in som filmstudio eller admin (2 olika flikar navigering)

//kolla igenom authenticating api



//Efter du är klar med detta. Kolla hur du lånar film osv för filmstudio.