using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Tags.Queries
{
    public class GetTagQuery: IRequestWrapper<Tag>
    {
        public Guid Id { get; set; }
        public GetTagQuery(Guid id)
        {
            Id = id;
        }
    }
    public class GetTagHandler : IHandlerWrapper<GetTagQuery, Tag>
    {
        private readonly ApplicationDbContext _db;

        public GetTagHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Response<Tag>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var tag = await _db.Tags.AsNoTracking().FirstOrDefaultAsync(tag => tag.Id == request.Id);
            return await Task.FromResult(Response.Ok("Get tag", data: tag));
        }
    }

}
