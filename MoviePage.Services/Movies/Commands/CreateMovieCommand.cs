using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Configurations;
using MoviePage.Models.Dtos.Movies;
using MoviePage.Services.Handlers;
using MoviePage.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Movies.Commands
{
    public class CreateMovieCommand: IRequestWrapper<Guid> {
        public CreateMovieDTO Movie { get; set; }
        public CreateMovieCommand(CreateMovieDTO movie)
        {
            Movie = movie;
        }
    }
    public class CreateMovieCommandHandler : IHandlerWrapper<CreateMovieCommand, Guid>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CloudinaryHandler cloudinaryHandler;
        public CreateMovieCommandHandler(ApplicationDbContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor, IOptions<CloudinarySettings> options)
        {
            _db = db;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            cloudinaryHandler = new CloudinaryHandler(new CloudinaryDotNet.Account
            {
                ApiKey = options.Value.ApiKey,
                ApiSecret = options.Value.ApiSecret,
                Cloud = options.Value.CloudName,
            });
        }
        public async Task<Response<Guid>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Movie>(request.Movie);
            movie.PGId = 1;
            if(request.Movie.Image != null)
            {
                var response = cloudinaryHandler.UploadImage(request.Movie.Image, new Models.Options.TransformImageOptions { Height = 600, Width = 400 });
                movie.Cover = response.PublicUrl;
                movie.PublicId = response.PublicId;
            }
            else
            {
                movie.Cover = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/3EE321A248366260FDADDC2736AEE165B900A7CE74494C0D89E3F097981E34BB/scale?width=1200&aspectRatio=1.78&format=jpeg";
            }
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
            return await Task.FromResult(Response.Ok("New movie created", data: movie.Id));
        }
    }
}
