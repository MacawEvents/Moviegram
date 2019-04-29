using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviegramAPI.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Details { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] FullImage { get; set; }
        public virtual ICollection<MovieViewTime> ViewTimes { get; set; }

        public Movie()
        {
            
        }
    }
}
