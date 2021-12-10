using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class MovieSchedule
    {
        [Key]
        public int Id { get; set; }
        public Guid TheaterBranchId { get; set; }
        [ForeignKey(nameof(TheaterBranchId))]
        public virtual TheaterBranch TheaterBranch { get; set; }
        public Guid MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        public DateTime Start { get; set; }
        [NotMapped]
        public DateTime End => Start.AddMinutes(Movie.Duration);
    }
}
