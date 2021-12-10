using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class SeatBooking: DeleteEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual Account User { get; set; }
        public Guid SeatId { get; set; }
        [ForeignKey(nameof(SeatId))]
        public virtual Seat Seat { get; set; }
        public Guid MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        public DateTime BookAt { get; set; }
        [NotMapped]
        public DateTime AvailableBefore => BookAt.AddMinutes(Movie.Duration);
    }
}
