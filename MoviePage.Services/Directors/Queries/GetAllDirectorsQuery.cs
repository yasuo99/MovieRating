using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Dtos.Directors;
using MoviePage.Services.Wrappers;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Directors.Queries
{
    public class GetAllDirectorsQuery: PaginationRequest, IRequestWrapper<PaginationHelper<DirectorDTO>> { }
    public class GetAllDirectorsHandler : IHandlerWrapper<GetAllDirectorsQuery, PaginationHelper<DirectorDTO>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public GetAllDirectorsHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Response<PaginationHelper<DirectorDTO>>> Handle(GetAllDirectorsQuery request, CancellationToken cancellationToken)
        {
            var directors = await _db.Directors.AsNoTracking().ToListAsync();

            var paginationDirectors = await PaginationHelper<Director>.OnCreateAsync(directors.AsQueryable(), request.PaginationQuery.CurrentPage, request.PaginationQuery.PageSize);


            var mappedPaginationDirectors = _mapper.Map<PaginationHelper<DirectorDTO>>(paginationDirectors);

            return await Task.FromResult(Response.Ok("Get directors", data: mappedPaginationDirectors));
        }
    }
}
