using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Actors
{
    public class DetailActorDTO
    {
        public DetailActorDTO()
        {
            Movies = new HashSet<Movie>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
