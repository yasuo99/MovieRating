using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Directors
{
    public class CreateDirectorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile AvatarFile { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        public string Country { get; set; }
        public virtual List<MovieDirectorDTO> Movies { get; set; }
    }
}
