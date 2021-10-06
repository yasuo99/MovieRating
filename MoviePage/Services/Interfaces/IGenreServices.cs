using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Services.Interfaces
{
    public interface IGenreServices
    {
        Task<IEnumerable<Genres>> GetGenres(string search = null);
        Task<Genres> GetGenre(Guid id);
        Task<Genres> CreateGenre(Genres genres);
        Task<Genres> UpdateGenre(Guid id, Genres genres);
        Task DeleteGenre(Guid id);
    }
}
