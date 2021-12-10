using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Directors
{
    public class DirectorDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age;
        public string Bio { get; set; }
        public string Country { get; set; }
        public List<MovieDirectorDTO> Movies { get; set; }
    }
}
