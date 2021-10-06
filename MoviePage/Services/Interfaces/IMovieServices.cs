using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Interfaces
{
    public interface IMovieServices
    {
        Task<IEnumerable<Movie>> GetMovies(string search = null);
        Task<Movie> GetMovie(Guid id);
        Task<Movie> GetMovie(string title);


    }
}
