using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Dtos.Actors;
using MoviePage.Services.Interfaces;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Actors.Commands
{
    public record UpdateActorCommand(Guid ActorId, UpdateActorDTO UpdateActorDTO, string contentRootPath) : IRequestWrapper<Actor>;
    public class UpdateActorHandler : IHandlerWrapper<UpdateActorCommand, Actor>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public UpdateActorHandler(ApplicationDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<Response<Actor>> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = await _db.Actors.Where(actor => actor.Id == request.ActorId).Include(inc => inc.Movies).FirstOrDefaultAsync();
            if(actor == null)
            {
                return await Task.FromResult(Response.NotFound($"Actor {request.ActorId} not found", data: actor));
            }
            if (request.UpdateActorDTO.AvatarFile != null)
            {
                _fileService.DeleteFile(Path.Combine(request.contentRootPath, actor.Avatar));
                actor.Avatar = _fileService.UploadFile(request.UpdateActorDTO.AvatarFile, request.contentRootPath);
            }
            _mapper.Map(request.UpdateActorDTO, actor);
            await _db.SaveChangesAsync();
            return await Task.FromResult(Response.Ok("Updated actor", data: actor));
        }
    }
}
