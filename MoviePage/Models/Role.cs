using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Role: IdentityRole<Guid>
    {
        public virtual IEnumerable<AccountRole> Accounts { get; set; }
    }
}
