using Microsoft.EntityFrameworkCore;
using ClassLibrary.Entity;
using System.IO;
using WebApplication1.Models.Entity;

namespace ClassLibrary.EntityFramework
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options)
            : base(options)
        {

        }
        public DbSet<Film> Films { get; set; }

    }
}
