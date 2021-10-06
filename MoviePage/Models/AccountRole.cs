using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class AccountRole: IdentityUserRole<Guid>
    {
        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}
