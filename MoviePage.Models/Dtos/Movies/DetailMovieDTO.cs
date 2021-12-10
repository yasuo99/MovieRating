using MoviePage.Models.Dtos.Actors;
using MoviePage.Models.Dtos.Directors;
using MoviePage.Models.Dtos.Genres;
using MoviePage.Models.Dtos.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Movies
{
    public class DetailMovieDTO
    {
        public Guid Id { get; set; }
        public string Cover { get; set; }
        public string Title { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Trailer { get; set; }
        public DateTime ReleasedAt { get; set; }
        public double Budget { get; set; }
        public double BoxOffice { get; set; }
        public double Rating { get; set; }
        public PG PG { get; set; }
        public List<MovieActorDTO> Actors { get; set; }
        public List<MovieDirectorDTO> Directors { get; set; }
        public virtual IEnumerable<GenreDTO> Genres { get; set; }
        public virtual IEnumerable<TagDTO> Tags { get; set; }
        public virtual IEnumerable<Vote> Votes { get; set; }
    }
}
