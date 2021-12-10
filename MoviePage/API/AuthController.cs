using Microsoft.AspNetCore.Mvc;
using MoviePage.Models.Dtos.Identity;
using MoviePage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.API
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _authService.GenerateToken(loginDTO);
            if(response.StatusCode == (int)HttpStatusCode.OK)
            {
                return Ok(response);
            }
            return Unauthorized(response);
        }
        [HttpGet("refresh")]
        public async Task<IActionResult> RefreshToken()
        {
            return Ok();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }
    }
}
