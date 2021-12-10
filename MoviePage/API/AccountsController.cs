using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviePage.Models;
using MoviePage.Models.Dtos.Identity;
using MoviePage.Services.Interfaces;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.API
{
    public class AccountsController : ApiControllerBase<Guid, Account, Account>
    {
        private readonly IAuthService _authService;
        public AccountsController(IMediator mediator, IAuthService authService) : base(mediator)
        {
            _authService = authService;
        }
        public override Task<IActionResult> Create(Account data)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> GetDetail(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Update(Guid id, Account data)
        {
            throw new NotImplementedException();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {

            return Ok();
        }
    }
}
