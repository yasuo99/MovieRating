using MoviePage.Models.Base;
using MoviePage.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        public string Avatar { get; set; }
        public string PublicId { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year;
        public virtual IEnumerable<MovieActor> Movies { get; set; }
    }
}
