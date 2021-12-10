using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Tags.Commands
{
    public record DeleteTagCommand(Guid id) : IRequestWrapper<string>;
    public class DeleteTagHandler : IHandlerWrapper<DeleteTagCommand, string>
    {
        private readonly ApplicationDbContext _db;
        public DeleteTagHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Response<string>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _db.Tags.FirstOrDefaultAsync(item => item.Id == request.id);
            _db.Remove(tag);
            if (await _db.SaveChangesAsync() > 0)
            {
                return await Task.FromResult(Response.Ok<string>("Deleted"));
            }
            return await Task.FromResult(Response.Fail<string>("Delete fail"));
        }
    }
}
