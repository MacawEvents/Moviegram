using MoviegramAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviegramAPI.Data
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        Movie Get(int id);
        Movie Insert(Movie movie);
        Movie Update(Movie movie);
        Movie Delete(int id);

    }
}
