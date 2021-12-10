using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Tags.Commands
{
    public class CreateTagCommand: IRequestWrapper<Tag>
    {
        public Tag Tag { get; set; }

        public CreateTagCommand(Tag tag)
        {
            Tag = tag;
        }
    }
    public class CreateTagHandler : IHandlerWrapper<CreateTagCommand, Tag>
    {
        private readonly ApplicationDbContext _db;
        public CreateTagHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Response<Tag>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            _db.Tags.Add(request.Tag);
            if(await _db.SaveChangesAsync() > 0)
            {
                return await Task.FromResult(Response.Ok("Created tag", data: request.Tag));
            }
            return await Task.FromResult(Response.Fail("Error", data: request.Tag));
        }
    }
}
