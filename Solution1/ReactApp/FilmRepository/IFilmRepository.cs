using ClassLibrary.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models.Entity;

namespace ClassLibrary.RepositoryInterfaces
{
    public interface IFilmRepository
    {
        ICollection<Film> SelectAll();
        Film SelectById(long id);
        bool Create(Film product);
        bool Delete(long id);
        bool Update(Film product);
        ICollection<Film> SelectByName(string id);
    }
}