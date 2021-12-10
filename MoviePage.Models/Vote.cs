using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Vote
    {
        public Guid MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        public double Star { get; set; }
        public string Comment { get; set; }
        public Guid AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
