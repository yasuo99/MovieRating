using AutoMapper;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Dtos.Actors;
using MoviePage.Services.Interfaces;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Actors.Commands
{
    public record CreateActorCommand(CreateActorDTO CreateActorDTO, string ContentRootPath): IRequestWrapper<Actor>;
    public class CreateActorHandler : IHandlerWrapper<CreateActorCommand, Actor>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public CreateActorHandler(ApplicationDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<Response<Actor>> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = _mapper.Map<Actor>(request.CreateActorDTO);
            if(request.CreateActorDTO.AvatarFile != null)
            {
                actor.Avatar = _fileService.UploadFile(request.CreateActorDTO.AvatarFile, request.ContentRootPath);
            }
            _db.Actors.Add(actor);
            if(await _db.SaveChangesAsync() > 0)
            {
                return await Task.FromResult(Response.Created("Created actor", data: actor));
            }
            return await Task.FromResult(Response.Fail("Fail on create actor", data: actor));
        }
    }
}
