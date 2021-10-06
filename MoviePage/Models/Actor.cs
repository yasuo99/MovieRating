using MoviePage.Models.Base;
using MoviePage.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Actor: BaseModel
    {
        public Actor()
        {
            Movies = new HashSet<MovieActor>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + FirstName;
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year;
        public virtual IEnumerable<MovieActor> Movies { get; set; }
    }
}
