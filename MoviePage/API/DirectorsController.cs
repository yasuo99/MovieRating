using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviePage.Models;
using MoviePage.Models.Dtos.Directors;
using MoviePage.Services.Directors.Queries;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.API
{
    public class DirectorsController : ApiControllerBase<Guid, CreateDirectorDTO, Director>
    {
        public DirectorsController(IMediator mediator) : base(mediator)
        {
        }

        public override async Task<IActionResult> Create([FromForm] CreateDirectorDTO data)
        {
            var test = new SelectList("");
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllDirectorsQuery()));
        }

        public override Task<IActionResult> GetDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Update(Guid id, Director data)
        {
            throw new NotImplementedException();
        }
    }
}
