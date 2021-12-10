using Microsoft.AspNetCore.Identity;
using MoviePage.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Account: IdentityUser<Guid>
    {
        public Account()
        {
            Roles = new HashSet<AccountRole>();
            Votes = new HashSet<Vote>();
        }
        public string Avatar { get; set; }
        public string PublicId { get; set; }
        public DateTime BirthDate { get; set; }
        public double Wallet { get; set; }
        public Sex Sex { get; set; }
        public virtual IEnumerable<AccountRole> Roles { get; set; }
        public virtual IEnumerable<Vote> Votes { get; set; }
        public virtual IEnumerable<SeatBooking> SeatBookings { get; set; }
    }
}
