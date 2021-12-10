using MoviePage.Models.Dtos.Actors;
using MoviePage.Models.Dtos.Directors;
using MoviePage.Models.Dtos.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.Dtos.Client
{
    public class HomeDTO
    {
        public HomeDTO()
        {
            FeaturedActors = new List<ActorDTO>();
            FeaturedMovies = new List<MovieDTO>();
            FeaturedDirectors = new List<DirectorDTO>();
            FanFavoritesMovies = new List<MovieDTO>();
        }
        public List<DirectorDTO>  FeaturedDirectors { get; set; }
        public List<MovieDTO> FeaturedMovies { get; set; }
        public List<ActorDTO> FeaturedActors { get; set; }
        public List<MovieDTO> FanFavoritesMovies { get; set; }
        public List<MovieDTO> TopPicksMovies { get; set; }
        public List<MovieDTO> NewMovies { get; set; }
    }
}
