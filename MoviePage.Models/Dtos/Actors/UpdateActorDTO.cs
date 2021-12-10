using Microsoft.AspNetCore.Http;
using MoviePage.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Actors
{
    public class UpdateActorDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile AvatarFile { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public List<MovieActor> Movies { get; set; }
    }
}
