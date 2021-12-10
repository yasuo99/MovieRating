using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Genres.Queries
{
    public record GetGenreQuery(Guid GenreId): IRequestWrapper<MoviePage.Models.Genres> { }
    public class GetGenreHandler : IHandlerWrapper<GetGenreQuery, MoviePage.Models.Genres>
    {
        private readonly ApplicationDbContext _db;
        public GetGenreHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Response<Models.Genres>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = await _db.Genres.AsNoTracking().Where(genre => genre.Id == request.GenreId).FirstOrDefaultAsync();
            if(genre == null)
            {
                return await Task.FromResult(Response.NotFound("Genre not found", data: genre));
            }
            return await Task.FromResult(Response.Ok("Genre found", data: genre));
        }
    }

}
