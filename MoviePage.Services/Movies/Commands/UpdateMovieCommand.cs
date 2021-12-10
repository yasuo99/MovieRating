using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Dtos.Movies;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Movies.Commands
{
    public record UpdateMovieCommand(Guid id, UpdateMovieDTO MovieDTO) : IRequestWrapper<Movie>;

    public class UpdateMovieHandler : IHandlerWrapper<UpdateMovieCommand, Movie>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UpdateMovieHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Response<Movie>> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _db.Movies.Where(movie => movie.Id == request.id)
                .Include(inc => inc.Actors)
                .Include(inc => inc.Directors).FirstOrDefaultAsync();

            if(movie == null)
            {
                return await Task.FromResult(Response.NotFound($"Movie {request.id} not found", data: movie));
            }
            _mapper.Map(request.MovieDTO, movie);
            if (await _db.SaveChangesAsync() > 0)
            {
                return await Task.FromResult(Response.Ok("Update movie success", data: movie));
            }
            return await Task.FromResult(Response.Ok("Nothing changed", data: movie));

        }
    }
}
