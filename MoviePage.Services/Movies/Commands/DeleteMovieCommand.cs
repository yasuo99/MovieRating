using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Movies.Commands
{
    public record DeleteMovieCommand(Guid MovieId): IRequestWrapper<Guid>;
    public class DeleteMovieHandler : IHandlerWrapper<DeleteMovieCommand, Guid>
    {
        private readonly ApplicationDbContext _db;
        public DeleteMovieHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Response<Guid>> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _db.Movies.FirstOrDefaultAsync(movie => movie.Id == request.MovieId);
            if(movie == null)
            {
                return await Task.FromResult(Response.NotFound($"Movie {request.MovieId} not found", data: request.MovieId));
            }
            _db.Movies.Remove(movie);
            if(await _db.SaveChangesAsync() > 0)
            {
                return await Task.FromResult(Response.Ok("Movie deleted", data: request.MovieId));
            }
            return await Task.FromResult(Response.Ok("Movie can't be deleted", data: request.MovieId));
        }
    }
}
