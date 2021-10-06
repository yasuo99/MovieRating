using Microsoft.EntityFrameworkCore;
using MoviePage.Data;
using MoviePage.Models;
using MoviePage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services
{
    public class GenreServices : IGenreServices
    {
        private readonly ApplicationDbContext _db;

        public GenreServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Genres> CreateGenre(Genres genres)
        {
            _db.Add(genres);
            if(await _db.SaveChangesAsync() > 0)
            {
                return genres;
            }
            return null;
        }

        public async Task DeleteGenre(Guid id)
        {
            var genre = await _db.Genres.FirstOrDefaultAsync(gen => gen.Id == id);
            _db.Remove(genre);
            await _db.SaveChangesAsync();
        }

        public async Task<Genres> GetGenre(Guid id)
        {
            return await _db.Genres.Include(inc => inc.Movies).FirstOrDefaultAsync(gen => gen.Id == id);
        }

        public async Task<IEnumerable<Genres>> GetGenres(string search = null)
        {
            var genres = await _db.Genres.ToListAsync();
            if(search != null)
            {
                genres = genres.Where(gen => gen.GenresName.ToLower().Contains(search.ToLower())).ToList();
            }
            return genres;
        }

        public async Task<Genres> UpdateGenre(Guid id, Genres genres)
        {
            var genre = await GetGenre(id);
            genre.GenresName = genres.GenresName;
            genre.Movies = genres.Movies;
            if(await _db.SaveChangesAsync() > 0)
            {
                return genre;
            }
            return null;
        }
    }
}
