using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviegramAPI.Models;

namespace MoviegramAPI.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviegramAPIContext context;

        public MovieRepository(MoviegramAPIContext moviegramAPIContext)
        {
            this.context = moviegramAPIContext;
        }
        public Movie Delete(int id)
        {
            var movie = this.context.Movie.Find(id);
            if (movie != null)
            {
                this.context.Movie.Remove(movie);
            }
            this.context.Movie.Remove(movie);
            this.context.SaveChanges();
            return movie;
        }

        public IEnumerable<Movie> Get()
        {
            return this.context.Movie.Include(m=>m.ViewTimes).ToArray();
        }

        public Movie Get(int id)
        {
            return this.context.Movie.Include(m => m.ViewTimes).FirstOrDefault(m=>m.MovieId == id);
        }

        public Movie Insert(Movie movie)
        {
            this.context.Movie.Add(movie);
            this.context.SaveChanges();
            return movie;
        }

        public Movie Update(Movie movie)
        {
            this.context.Entry(movie).State = EntityState.Modified;

            try
            {
                this.context.SaveChanges();
                return movie;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.MovieId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool MovieExists(int id)
        {
            return this.context.Movie.Any(e => e.MovieId == id);
        }
    }
}
