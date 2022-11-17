using Microsoft.EntityFrameworkCore;
using ClassLibrary.Entity;
using ClassLibrary.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entity;

namespace ClassLibrary.EntityFramework 
{
    public class FilmRepository : IFilmRepository
    {
        private FilmContext context;

        public FilmRepository(FilmContext context)
        {
            this.context = context;
        }

        public bool Create(Film Film)
        {
            context.Films.Add(Film);
            try
            {
                return context.SaveChanges() == 1;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            Film Film = context.Films.Find(id);
            if (Film == null)
            {
                return false;
            }
            context.Remove(Film);
            return context.SaveChanges() == 1;
        }

        public ICollection<Film> SelectAll()
        {
            return context.Films.ToList();
        }


        public Film SelectById(long id)
        {
            return context.Films.Find(id);
        }

        public ICollection<Film> SelectByName(string id)
        {
            return context.Films.Where(p => p.Title.Contains(id)).ToList();
        }

        public bool Update(Film modifiedFilm)
        {
            Film Film = context.Films.Find(modifiedFilm.Id);
            if (Film == null)
            {
                return false;
            }
            Film.Stock = modifiedFilm.Stock;
            Film.Genre = modifiedFilm.Genre;
            return context.SaveChanges() == 1;
        }

    }
}
