using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviePage.API.Constant;
using MoviePage.DataAccess.Data;
using MoviePage.Utility.Helper;
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
    public abstract class ApiControllerBase<TKey, TCreateData, TUpdateData>: ControllerBase
    {
        protected IMediator _mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }
        // Default route and method for CRUD controller
        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public abstract Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery, CancellationToken cancellationToken);
        [HttpGet("{id}")]
        public abstract Task<IActionResult> GetDetail(TKey id);
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public abstract Task<IActionResult> Create(TCreateData data);
        [HttpPut("{id}")]
        public abstract Task<IActionResult> Update(TKey id, TUpdateData data);
        [HttpDelete("{id}")]
        public abstract Task<IActionResult> Delete(TKey id);
    }
}
