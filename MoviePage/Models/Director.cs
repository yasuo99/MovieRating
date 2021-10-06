using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Director: BaseModel
    {
        public Director()
        {
            Movies = new HashSet<MovieDirector>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + LastName;
        public DateTime BirthDate { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year;
        public string Bio { get; set; }
        public string Country { get; set; }
        public virtual IEnumerable<MovieDirector> Movies { get; set; }

    }
}
