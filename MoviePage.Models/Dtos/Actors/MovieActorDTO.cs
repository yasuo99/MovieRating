using MoviePage.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Actors
{
    public class MovieActorDTO
    {
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Avatar { get; set; }
        public ActorRole Role { get; set; }
    }
}
