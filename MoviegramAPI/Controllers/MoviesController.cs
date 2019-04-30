using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviegramAPI.Data;
using MoviegramAPI.Models;

namespace MoviegramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        
        private readonly IMovieRepository movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

         // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movie> GetMovie()
        {
            
            return this.movieRepository.Get();

        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public IActionResult GetMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = this.movieRepository.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult PutMovie([FromRoute] int id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            if (this.movieRepository.Update(movie) == null)
            {
                return NotFound(id);
            }
            else
            {
                return NoContent();
            }
            
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult PostMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.movieRepository.Insert(movie);
            

            return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = this.movieRepository.Delete(id);
            if (movie == null)
            {
                return NotFound();
            }
   
            return Ok(movie);
        }

       
    }
}