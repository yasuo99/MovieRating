using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Models.Dtos.Actors;
using MoviePage.Models.Dtos.Client;
using MoviePage.Models.Dtos.Directors;
using MoviePage.Models.Dtos.Movies;
using MoviePage.Services.Wrappers;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Client.Queries
{
    public record GetHomeQuery(CancellationToken CancellationToken) : IRequestWrapper<HomeDTO>;
    public class GetHomeHandler : IHandlerWrapper<GetHomeQuery, HomeDTO>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetHomeHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Response<HomeDTO>> Handle(GetHomeQuery request, CancellationToken cancellationToken)
        {
            var movies = await _db.Movies.AsNoTracking().Include(inc => inc.PG).Include(inc => inc.Actors).ThenInclude(inc => inc.Actor)
                .Include(inc => inc.Directors).ThenInclude(inc => inc.Director)
                .Include(inc => inc.Votes)
                .ToListAsync(cancellationToken);

            var home = new HomeDTO();
            var featuredMovies = movies.Where(movie => movie.IsFeatured).ToList();
            home.FeaturedMovies = _mapper.Map<List<MovieDTO>>(featuredMovies);
            home.NewMovies = _mapper.Map<List<MovieDTO>>(movies.Where(movie => movie.IsNew));
            home.FanFavoritesMovies = _mapper.Map<List<MovieDTO>>(movies.OrderByDescending(movie => movie.Votes.Count()).Take(10));

            home.FeaturedActors = _mapper.Map<List<ActorDTO>>(featuredMovies.SelectMany(sel => sel.Actors).Select(sel => sel.Actor).ToList());
            home.FeaturedDirectors = _mapper.Map<List<DirectorDTO>>(featuredMovies.SelectMany(sel => sel.Directors).Select(sel => sel.Director).ToList());

            home.TopPicksMovies = _mapper.Map<List<MovieDTO>>(movies.Shuffle().Take(10));
            return await Task.FromResult(Response.Ok("Client get data", data: home));
        }
    }
}
