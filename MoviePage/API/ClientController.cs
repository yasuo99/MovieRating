using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviePage.Services.Client.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.API
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClientController: ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Home(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetHomeQuery(cancellationToken)));
        }
    }
}
