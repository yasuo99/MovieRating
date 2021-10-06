using Microsoft.AspNetCore.Identity;
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
        public DateTime BirthDate { get; set; }
        public double Wallet { get; set; }
        public virtual IEnumerable<AccountRole> Roles { get; set; }
        public virtual IEnumerable<Vote> Votes { get; set; }
    }
}
