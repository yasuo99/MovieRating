using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviePage.API.Abstractions;
using MoviePage.Models;
using MoviePage.Services.Tags.Commands;
using MoviePage.Services.Tags.Queries;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.API
{
    public class TagsController : ApiControllerBase<Guid, Tag, Tag>
    {
        public TagsController(IMediator mediator) : base(mediator)
        {
        }

        public override async Task<IActionResult> Create(Tag data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(new CreateTagCommand(data)));
        }

        public override async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteTagCommand(id)));
        }

        public override async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllTagsQuery(), cancellationToken));
        }

        public override async Task<IActionResult> GetDetail(Guid id)
        {
            return Ok(await _mediator.Send(new GetTagQuery(id)));
        }


        public override async Task<IActionResult> Update(Guid id, Tag body)
        {
            throw new NotImplementedException();
        }
    }
}
