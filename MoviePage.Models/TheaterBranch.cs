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
    public class TheaterBranch: BaseModel
    {
        public Guid TheaterId { get; set; }
        [ForeignKey(nameof(TheaterId))]
        public virtual Theater Theater { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        [NotMapped]
        public string FullAddress => Province + "," + City + ", "+ District;
        public int Slot { get; set; }
        public virtual ICollection<MovieSchedule> MovieSchedules { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
