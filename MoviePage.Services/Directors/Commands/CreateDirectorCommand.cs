using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Dtos.Directors;
using MoviePage.Services.Interfaces;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Directors.Commands
{
    public record CreateDirectorCommand(CreateDirectorDTO CreateDirectorDTO, string contentRootPath): IRequestWrapper<Guid>;
    public class CreateDirectorHandler : IHandlerWrapper<CreateDirectorCommand, Guid>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public CreateDirectorHandler(IMapper mapper, ApplicationDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<Response<Guid>> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var director = _mapper.Map<Director>(request.CreateDirectorDTO);
            //var exist = await _db.Directors.AnyAsync(director => director.);
            if(request.CreateDirectorDTO.AvatarFile != null)
            {
                director.Avatar = _fileService.UploadFile(request.CreateDirectorDTO.AvatarFile, request.contentRootPath);
            }
            _db.Directors.Add(director);
            if(await _db.SaveChangesAsync() > 0)
            {
                return await Task.FromResult(Response.Ok("Created director", data: director.Id));
            }
            return await Task.FromResult(Response.Fail("Created director fail", data: director.Id));
        }
    }
}
