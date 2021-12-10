using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviePage.Models;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.API
{
    public class TheatersController : ApiControllerBase<Guid, Theater, Theater>
    {
        public TheatersController(IMediator mediator): base(mediator)
        {

        }

        public override Task<IActionResult> Create(Theater data)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> GetDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Update(Guid id, Theater theater)
        {
            throw new NotImplementedException();
        }
    }
}
