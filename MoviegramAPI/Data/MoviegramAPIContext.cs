using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviegramAPI.Models;

namespace MoviegramAPI.Models
{
    public class MoviegramAPIContext : DbContext
    {
        public MoviegramAPIContext (DbContextOptions<MoviegramAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MoviegramAPI.Models.Movie> Movie { get; set; }

        public DbSet<MoviegramAPI.Models.MovieViewTime> MovieViewTime { get; set; }
    }
}
