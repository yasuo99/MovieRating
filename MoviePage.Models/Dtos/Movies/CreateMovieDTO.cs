using Microsoft.AspNetCore.Http;
using MoviePage.Models.Dtos.Actors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Movies
{
    public class CreateMovieDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        public int Duration { get; set; }
        public string Trailer { get; set; }
        [Required]
        public double Budget { get; set; }
        public double BoxOffice { get; set; }
        [Required]
        public DateTime ReleasedAt { get; set; }
        public List<MovieActorDTO> Actors { get; set; }
        public List<MovieDirector> Directors { get; set; }
    }
}
