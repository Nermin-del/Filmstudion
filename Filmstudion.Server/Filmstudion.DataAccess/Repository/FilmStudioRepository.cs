using filmstudion.server;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.Filmstudio;
using Filmstudion.Models.FilmStudio;
using Filmstudion.Models.FilmStudio.Interface;
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
        private readonly AppDbContext db;
        private readonly AppSettings appSettings;


        public FilmStudioRepository(AppDbContext db, IOptions<AppSettings> appsettings)
        {
            this.db = db;
            this.appSettings = appsettings.Value;
        }

        public FilmStudio Authenticate(string username, string password)
        {
            var user = db.FilmStudioUser.SingleOrDefault(x => x.Username == username && x.Password == password);

            //user not found
            if (user == null)
            {
                return null;
            }

            //if user was found generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
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
            var user = db.FilmStudioUser.SingleOrDefault(x => x.Username == username);

            // return null if user is not found
            if (user == null)
                return true;

            return false;
        }

        public FilmStudio Register(string username, string password)
        {
            FilmStudio user = new FilmStudio()
            {
                Username = username,
                Password = password,
                Role = "Filmstudio"
            };

            db.FilmStudioUser.Add(user);
            db.SaveChanges();
            user.Password = "";
            return user;
        }

        public FilmStudio RentFilmCopy()
        {
            throw new NotImplementedException();
        }

        public ICollection<FilmStudio> GetFilmStudios()
        {
            return db.FilmStudioUser.ToList();
            
        }

    }
}


