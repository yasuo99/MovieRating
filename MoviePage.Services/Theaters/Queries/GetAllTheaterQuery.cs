using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Services.Wrappers;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Services.Theaters.Queries
{
    public class GetAllTheaterQuery: PaginationRequest ,IRequestWrapper<PaginationHelper<Theater>>
    {
        
    }
    public class GetAllTheaterHandler : IHandlerWrapper<GetAllTheaterQuery, PaginationHelper<Theater>>
    {
        private readonly ApplicationDbContext _db;

        public GetAllTheaterHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Response<PaginationHelper<Theater>>> Handle(GetAllTheaterQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
