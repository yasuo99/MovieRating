using Microsoft.AspNetCore.Http;
using MoviePage.Models.Dtos.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Movies
{
    public class UpdateMovieDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public int Length { get; set; }
        public string Trailer { get; set; }
        public double Budget { get; set; }
        public double BoxOffice { get; set; }
        public DateTime ReleasedAt { get; set; }
        public List<MovieActorDTO> Actors { get; set; }
        public List<MovieDirector> Directors { get; set; }
    }
}
