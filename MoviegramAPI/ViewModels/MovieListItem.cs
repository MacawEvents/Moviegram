using MoviegramAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviegramAPI.ViewModels
{
    [NotMapped]
    public class MovieListItem
    {
        private Movie movie;
        public int MovieId { get { return this.movie.MovieId; } }
        public byte[] Thumbnail { get { return this.movie.Thumbnail; } }
        public ICollection<MovieViewTime> ViewTimes { get { return this.movie.ViewTimes; } }

        public MovieListItem(Movie movie)
        {
            this.movie = movie;
        }
    }
}
