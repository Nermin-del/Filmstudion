using filmstudion.server;
using Filmstudion.DataAccess.Repository.Interface;
using Filmstudion.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Filmstudion.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext db;
        private readonly AppSettings appSettings;
        //private readonly UserManager<User> userManager;

        public UserRepository(AppDbContext db, IOptions<AppSettings> appsettings /*UserManager<User> userManager*/)
        {
            //this.userManager = userManager;
            this.db = db;
            this.appSettings = appsettings.Value;
        }


        public User Authenticate(string username, string password)
        {
            var user = db.User.SingleOrDefault(x => x.Username == username && x.Password == password);

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
                    new Claim(ClaimTypes.Role, user.Role)

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

        public bool IsUniqueName(string username)
        {

            var user = db.User.SingleOrDefault(x => x.Username == username);

            // return null if user is not found
            if (user == null)
                return true;

            return false;
        }

        public User Register(string username, string password, bool isAdmin)
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Password = password,
                Role = isAdmin ? "admin" : "user" 
            };

            db.User.Add(user);
            db.SaveChanges();
            user.Password = "";
            return user;
        }

        public ICollection<User> GetUsers()
        {
            return db.User.ToList();
        }
    }
}

