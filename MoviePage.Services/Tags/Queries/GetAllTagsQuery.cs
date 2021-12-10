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

namespace MoviePage.Services.Tags.Queries
{
    public class GetAllTagsQuery: PaginationRequest, IRequestWrapper<PaginationHelper<Tag>> {
        public GetAllTagsQuery()
        {

        }
    }
    public class GetAllTagsHandler : IHandlerWrapper<GetAllTagsQuery, PaginationHelper<Tag>>
    {
        private readonly ApplicationDbContext _db;
        public GetAllTagsHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Response<PaginationHelper<Tag>>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _db.Tags.AsNoTracking().ToListAsync();
            var result = await PaginationHelper<Tag>.OnCreateAsync(tags.AsQueryable(), request.PaginationQuery.CurrentPage, request.PaginationQuery.PageSize);
            return await Task.FromResult(Response.Ok("Get tags", data: result));
        }
    }
}
