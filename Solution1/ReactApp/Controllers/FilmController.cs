
using ClassLibrary.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebClient.Controllers
{
    //Route attribute defines path api/film
    [Route("api/[controller]")]
    public class FilmController : Controller
    {
        private IFilmRepository filmRepository;

        public FilmController(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ICollection<Film> films = filmRepository.SelectAll();
            return Ok(films);
        }

        // "{id}" is a placeholder variable for the ID of the Film 
        [HttpGet("{id}")]
        public IActionResult GetByName(string id)
        {
            var films = filmRepository.SelectByName(id);
            if (films == null)
            {
                return NotFound();
            }
            return Ok(films);
        }

        //
        [HttpGet("{id:regex(^\\d{{1,3}}$)}", Name = "GetFilmsById")]
        public IActionResult GetById(long id)
        {
            var item = filmRepository.SelectById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Film film)
        {
            if (film == null)
            {
                return BadRequest(ModelState);
            }

            bool created = filmRepository.Create(film);
            if (!created)
            {
                return BadRequest($"{film.Id} already exists");
            }

            return CreatedAtRoute("GetFilmsById", new { id = film.Id }, film);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Film film)
        {
            if (film == null || film.Id != id)
            {
                return BadRequest();
            }

            if (filmRepository.SelectById(id) == null)
            {
                return NotFound();
            }

            bool updated = filmRepository.Update(film);
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            bool deleted = filmRepository.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }
            return new NoContentResult();
        }


    }
}
