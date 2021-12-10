using MoviePage.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class MovieActor
    {
        public Guid MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        public Guid ActorId { get; set; }
        public virtual Actor Actor { get; set; }
        public ActorRole Role { get; set; }
        public string Character { get; set; }
    }
}
