using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Areas.Customer.Dtos
{
    public class HomeDTO
    {
        public List<Movie> Movies { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Director> Directors { get; set; }
        public List<Movie> SuggestMovies { get; set; }
    }
}
