using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Directors
{
    public class MovieDirectorDTO
    {
        public Guid DirectorId { get; set; }
        public Guid MovieId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Avatar { get; set; }
    }
}
