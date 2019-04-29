using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviegramAPI.Models;
using MoviegramAPI.ViewModels;

namespace MoviegramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieListItemsController : ControllerBase
    {
        private readonly MoviegramAPIContext context;

        public MovieListItemsController(MoviegramAPIContext context)
        {
            this.context = context;
        }

        // GET api/movielistitems
        [HttpGet]
        public ActionResult<IEnumerable<MovieListItem>> Get()
        {
            
            var movieListItems = this.context.Movie.Include(m => m.ViewTimes).Select(m => new MovieListItem(m));
            return Ok(movieListItems);
        }

        // GET api/movielistitems/5
        [HttpGet("{id}")]
        public ActionResult<MovieListItem> Get(int id)
        {
            Movie target = this.context.Movie.Find(id);
            
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
