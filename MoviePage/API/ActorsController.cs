using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MoviePage.Models;
using MoviePage.Models.Dtos.Actors;
using MoviePage.Services.Actors.Commands;
using MoviePage.Services.Actors.Queries;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.API
{
    public class ActorsController: ApiControllerBase<Guid, CreateActorDTO, UpdateActorDTO>
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public ActorsController(IMediator mediator, IWebHostEnvironment hostEnvironment) : base(mediator)
        {
            _hostEnvironment = hostEnvironment;
        }

        public override async Task<IActionResult> Create([FromForm] CreateActorDTO data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(new CreateActorCommand(data, _hostEnvironment.ContentRootPath));
            if(result.StatusCode == (int)HttpStatusCode.OK)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        public override async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteActorCommand(id));
            if(result.StatusCode == 404)
            {
                return NotFound(result);
            }
            if(result.StatusCode == 400)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        public override async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery, CancellationToken token)
        {
            return Ok(await _mediator.Send(new GetAllActorsQuery()));
        }

        public override async Task<IActionResult> GetDetail(Guid id)
        {
            var result = await _mediator.Send(new GetActorQuery(id));
            if(result.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        public override async Task<IActionResult> Update(Guid id, UpdateActorDTO data)
        {
            if(id != data.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(new UpdateActorCommand(id, data, _hostEnvironment.ContentRootPath));
            if(result.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
