using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Models
{
    public class Movie: BaseModel, IValidatableObject
    {
        public Movie()
        {
            WatchUrls = new HashSet<WatchUrl>();
            Genres = new HashSet<MovieGenres>();
            Directors = new HashSet<MovieDirector>();
        }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public string Trailer { get; set; }
        public DateTime ReleasedAt { get; set; }
        public double Budget { get; set; }
        public double BoxOffice { get; set; }
        public virtual IEnumerable<WatchUrl> WatchUrls { get; set; }
        public virtual IEnumerable<MovieDirector> Directors { get; set; }
        public virtual IEnumerable<MovieGenres> Genres { get; set; }
        public virtual IEnumerable<MovieTag> Tags { get; set; }
        public virtual IEnumerable<Vote> Votes { get; set; }
        public virtual IEnumerable<MovieActor> Actors { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Budget <= 0)
            {
                yield return new ValidationResult("Budget must higher than zero", new[] { nameof(Budget) });
            }
            if(Length <= 0)
            {
                yield return new ValidationResult("Movie length must higher than zero", new[] { nameof(Length) });
            }
        }
    }
}
