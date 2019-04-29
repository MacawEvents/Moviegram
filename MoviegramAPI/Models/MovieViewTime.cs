using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviegramAPI.Models
{
    public class MovieViewTime
    {
        [Key]
        public int MovieViewTimeId { get; set; }
        public DateTime DateTime { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public MovieViewTime()
        {

        }

    }
}
