using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Services.Wrappers;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Movies.Queries
{
    public class GetAllMoviesQuery : PaginationRequest, IRequestWrapper<PaginationHelper<Movie>>
    {
    }

    public class GetAllMoviesHandler : IHandlerWrapper<GetAllMoviesQuery, PaginationHelper<Movie>>
    {
        //DI
        private readonly ApplicationDbContext _db;
        public GetAllMoviesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Response<PaginationHelper<Movie>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = _db.Movies.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                if(request.OrderBy == Models.Enums.OrderBy.DESCENDING)
                {
                    movies = movies.SortByProperty(prop => prop.Id, request.SortBy);
                }
                else
                {

                }
                
            }
            var result = await PaginationHelper<Movie>.OnCreateAsync(movies.AsQueryable(), request.PaginationQuery.CurrentPage, request.PaginationQuery.PageSize);
            var response = Response.Ok("Get all movies", data: result);
            await Task.Delay(10000,cancellationToken);
            Console.WriteLine("dkmm");
            return await Task.FromResult(response);
        }
    }
}
