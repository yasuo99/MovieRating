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

namespace MoviePage.Services.Movies.Queries
{
    public class GetMovieQuery: IRequestWrapper<DetailMovieDTO> {
        public Guid Id { get; set; }

        public GetMovieQuery(Guid id)
        {
            Id = id;
        }
    }
    public class GetMovieHandler : IHandlerWrapper<GetMovieQuery, DetailMovieDTO>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetMovieHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Response<DetailMovieDTO>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await _db.Movies.AsNoTracking()
                .Where(movie => movie.Id == request.Id)
                .Include(inc => inc.PG)
                .Include(inc => inc.Actors).ThenInclude(inc => inc.Actor)
                .Include(inc => inc.Directors).ThenInclude(inc => inc.Director)
                .Include(inc => inc.Tags).ThenInclude(inc => inc.Tag)
                .Include(inc => inc.Genres).ThenInclude(inc => inc.Genres).FirstOrDefaultAsync();
            var detailMovieDto = _mapper.Map<DetailMovieDTO>(movie);
            if(movie == null)
            {
                return await Task.FromResult(Response.NotFound("Movie not found", data: detailMovieDto));
            }
            return await Task.FromResult(Response.Ok("Get movie", data: detailMovieDto));
        }
    }
}
