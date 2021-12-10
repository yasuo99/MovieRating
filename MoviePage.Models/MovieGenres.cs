using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePage.Models
{
    public class MovieGenres
    {
        public Guid MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        public Guid GenresId { get; set; }
        public virtual Genres Genres { get; set; }
    }
}