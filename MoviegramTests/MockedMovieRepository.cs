using MoviegramAPI.Data;
using MoviegramAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviegramTests
{
    public class MockedMovieRepository : IMovieRepository
    {
        private List<Movie> movies;

        public MockedMovieRepository()
        {
            
            this.InitialiseMovies();
            
        }
        public Movie Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> Get()
        {
            return this.movies;
        }

        public Movie Get(int id)
        {
            return this.movies.FirstOrDefault(m => m.MovieId == id);
        }

        public Movie Insert(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie Update(Movie movie)
        {
            throw new NotImplementedException();
        }

        private void InitialiseMovies()
        {
            this.movies = new List<Movie>();
            this.movies.Add(new Movie { MovieId = 1, Details = "Movie 1 details" });
            this.movies.Add(new Movie { MovieId = 2, Details = "Movie 2 details" });
        }
    }
}
