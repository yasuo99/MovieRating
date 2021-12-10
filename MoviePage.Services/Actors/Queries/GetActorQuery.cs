using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Dtos.Actors;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Actors.Queries
{
    public record GetActorQuery(Guid ActorId): IRequestWrapper<DetailActorDTO>;
    public class GetActorHandler : IHandlerWrapper<GetActorQuery, DetailActorDTO>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetActorHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Response<DetailActorDTO>> Handle(GetActorQuery request, CancellationToken cancellationToken)
        {
            var actor = await _db.Actors.AsNoTracking().Where(actor => actor.Id == request.ActorId).Include(inc => inc.Movies).ThenInclude(inc => inc.Movie).FirstOrDefaultAsync();
            var returnActor = _mapper.Map<DetailActorDTO>(actor);
            if(actor == null)
            {
                return await Task.FromResult(Response.NotFound($"Can't find actor with Id={request.ActorId}", data: returnActor));
            }
            return await Task.FromResult(Response.Ok("Get actor", data: returnActor));
        }
    }
}
