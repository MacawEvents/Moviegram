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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasData(new Movie { MovieId = 1, Details = "Movie 1 details - this movie only has 1 viewing time" });
            modelBuilder.Entity<Movie>().HasData(new Movie { MovieId = 2, Details = "Movie 2 details - this movie has 2 viewing times" });

            modelBuilder.Entity<MovieViewTime>().HasData(new Models.MovieViewTime { MovieViewTimeId = 1, MovieId = 1, DateTime = new DateTime(2000, 1, 1, 10,0,0) });
            modelBuilder.Entity<MovieViewTime>().HasData(new Models.MovieViewTime { MovieViewTimeId = 2, MovieId = 2, DateTime = new DateTime(2000, 1, 1, 10, 0, 0) });
            modelBuilder.Entity<MovieViewTime>().HasData(new Models.MovieViewTime { MovieViewTimeId = 3, MovieId = 2, DateTime = new DateTime(2000, 1, 2, 10, 0, 0) });
        }

        public DbSet<MoviegramAPI.Models.Movie> Movie { get; set; }

        public DbSet<MoviegramAPI.Models.MovieViewTime> MovieViewTime { get; set; }
    }
}
