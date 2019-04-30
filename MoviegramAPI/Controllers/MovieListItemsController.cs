using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviegramAPI.Data;
using MoviegramAPI.Models;
using MoviegramAPI.ViewModels;

namespace MoviegramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieListItemsController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;

        public MovieListItemsController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        // GET api/movielistitems
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<MovieListItem>> Get()
        {
            
            var movieListItems = this.movieRepository.Get().Select(m => new MovieListItem(m));
            return Ok(movieListItems);
        }

        // GET api/movielistitems/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<MovieListItem> Get(int id)
        {
            Movie target = this.movieRepository.Get(id);
            
            if (target == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(new MovieListItem(target));
            }
        }
    }
}
