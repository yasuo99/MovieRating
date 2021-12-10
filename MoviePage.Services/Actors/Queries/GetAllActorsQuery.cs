using AutoMapper;
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

namespace MoviePage.Services.Actors.Queries
{
    public class GetAllActorsQuery: PaginationRequest, IRequestWrapper<PaginationHelper<Actor>>
    {
        
    }
    public class GetAllActorHandler : IHandlerWrapper<GetAllActorsQuery, PaginationHelper<Actor>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetAllActorHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Response<PaginationHelper<Actor>>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            var actors = await _db.Actors.AsNoTracking().OrderByDescending(orderBy => orderBy.CreatedAt).ToListAsync();
            var result = await PaginationHelper<Actor>.OnCreateAsync(actors.AsQueryable(), request.PaginationQuery.CurrentPage, request.PaginationQuery.PageSize);

            return await Task.FromResult(Response.Ok("Get actors", data: result));
        }
    }
}
