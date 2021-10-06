using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class MovieDirector
    {
        public Guid DirectorId { get; set; }
        [ForeignKey(nameof(DirectorId))]
        public virtual Director Director { get; set; }
        public Guid MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
    }
}
