using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Dtos.Movies;
using MoviePage.Services;
using MoviePage.Services.Movies.Commands;
using MoviePage.Services.Movies.Queries;
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
    public class MoviesController : ApiControllerBase<Guid, CreateMovieDTO, UpdateMovieDTO>
    {
        public MoviesController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public override async Task<IActionResult> Create([FromForm] CreateMovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(new CreateMovieCommand(movieDTO)));
        }
        [ProducesResponseType(typeof(Response<Pagination<Movie>>), (int) HttpStatusCode.OK)]
        public override async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllMoviesQuery(),cancellationToken));
        }
        public override async Task<IActionResult> GetDetail(Guid id)
        {
            return Ok(await _mediator.Send(new GetMovieQuery(id)));
        }

        public override async Task<IActionResult> Update(Guid id, [FromBody] UpdateMovieDTO body)
        {
            if(id != body.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(new UpdateMovieCommand(id, body));
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

        public override async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteMovieCommand(id));
            if(result.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return NotFound(result);
            }
            if(result.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
