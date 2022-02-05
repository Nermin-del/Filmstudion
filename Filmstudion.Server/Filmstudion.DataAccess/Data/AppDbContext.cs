using Microsoft.EntityFrameworkCore;
using System;
using Filmstudion.Models.FilmStudio;
using Filmstudion.Models.Film;
using Filmstudion.Models.Users;

namespace Filmstudion.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Film> Film { get; set; }
        public DbSet<FilmStudio> FilmStudioUser { get; set; }
        
        //public DbSet<User> User { get; set; }
        
    }
}
