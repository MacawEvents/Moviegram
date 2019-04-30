using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviegramAPI.Models;

namespace MoviegramAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieViewTimesController : ControllerBase
    {
        private readonly MoviegramAPIContext context;

        public MovieViewTimesController(MoviegramAPIContext context)
        {
            this.context = context;
        }

        // GET: api/MovieViewTimes
        [HttpGet]
        public IEnumerable<MovieViewTime> GetMovieViewTime()
        {
            return this.context.MovieViewTime;
        }

        // GET: api/MovieViewTimes/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMovieViewTime([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieViewTime = await this.context.MovieViewTime.FindAsync(id);

            if (movieViewTime == null)
            {
                return NotFound();
            }

            return Ok(movieViewTime);
        }

        // PUT: api/MovieViewTimes/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutMovieViewTime([FromRoute] int id, [FromBody] MovieViewTime movieViewTime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieViewTime.MovieViewTimeId)
            {
                return BadRequest();
            }

            this.context.Entry(movieViewTime).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieViewTimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieViewTimes
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostMovieViewTime([FromBody] MovieViewTime movieViewTime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.context.MovieViewTime.Add(movieViewTime);
            await this.context.SaveChangesAsync();

            return CreatedAtAction("GetMovieViewTime", new { id = movieViewTime.MovieViewTimeId }, movieViewTime);
        }

        // DELETE: api/MovieViewTimes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMovieViewTime([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieViewTime = await this.context.MovieViewTime.FindAsync(id);
            if (movieViewTime == null)
            {
                return NotFound();
            }

            this.context.MovieViewTime.Remove(movieViewTime);
            await this.context.SaveChangesAsync();

            return Ok(movieViewTime);
        }

        private bool MovieViewTimeExists(int id)
        {
            return this.context.MovieViewTime.Any(e => e.MovieViewTimeId == id);
        }
    }
}