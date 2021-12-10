using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Actors.Commands
{
    public record DeleteActorCommand(Guid ActorId): IRequestWrapper<Guid>;
    public class DeleteActorHandler : IHandlerWrapper<DeleteActorCommand, Guid>
    {
        private readonly ApplicationDbContext _db;
        public DeleteActorHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Response<Guid>> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _db.Actors.FirstOrDefaultAsync(actor => actor.Id == request.ActorId);
            if(actor == null)
            {
                return await Task.FromResult(Response.NotFound("Actor not found", data: request.ActorId));
            }
            _db.Actors.Remove(actor);
            if(await _db.SaveChangesAsync() > 0)
            {
                return await Task.FromResult(Response.Ok("Deleted actor", data: request.ActorId));
            }
            return await Task.FromResult(Response.Fail("Delete actor error", data: request.ActorId));
        }
    }
}
