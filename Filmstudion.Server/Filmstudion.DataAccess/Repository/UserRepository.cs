using filmstudion.server;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Filmstudion.DataAccess.Repository
{
    public class UserRepository : IUserRegisterRepository
    {
        private readonly AppDbContext _db;
        private readonly AppSettings _appSettings;

        public UserRepository(AppDbContext db, IOptions<AppSettings> appsettings)
        {
            _db = db;
            _appSettings = appsettings.Value;
        }

        //public User Authenticate(string username, string password)
        //{
        //    var user = _db.User.SingleOrDefault(x => x.Username == username && x.Password == password);

        //    //user not found
        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    //if user was found generate JWT Token
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Id.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials
        //                        (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    user.Token = tokenHandler.WriteToken(token);
        //    user.Password = "";
        //    return user;
        //}

        //public bool IsUniqueUser(string username)
        //{
        //    throw new NotImplementedException();
        //}

        //public FilmStudio Register(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

