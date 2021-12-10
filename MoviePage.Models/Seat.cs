using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Seat: BaseModel
    {
        public string Code { get; set; }
        [DisplayName("Column")]
        public int XNum { get; set; }
        [DisplayName("Row")]
        public int YNum { get; set; }
        public double Price { get; set; }
        public Guid TheaterBranchId { get; set; }
        [ForeignKey(nameof(TheaterBranchId))]
        public virtual TheaterBranch TheaterBranch { get; set; }
        public virtual ICollection<SeatBooking> SeatBookings { get; set; }
    }
}
