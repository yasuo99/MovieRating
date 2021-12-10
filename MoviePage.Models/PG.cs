using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class PG
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RestrictAge { get; set; }
        public string MPAA { get; set; }
        public virtual IEnumerable<Movie> Movies { get; set; }
    }
}
