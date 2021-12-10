using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.API
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TestController: ControllerBase
    {
        [HttpGet("ok")]
        public IActionResult Ok1()
        {
            return Ok();
        }
        [HttpGet("badrequest")]
        public IActionResult BadRequest1()
        {
            return BadRequest();
        }
        [HttpGet("notfound")]
        public IActionResult NotFound1()
        {
            return NotFound();
        }
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("forbidden")]
        public IActionResult Forbidden()
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("signin")]
        public IActionResult Test5()
        {
            return SignIn(new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity[] { 
                new ClaimsIdentity("JwtToken")
            }));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("signout")]
        public IActionResult SignOut()
        {
            return SignOut();
        }
        [HttpGet("redirect")]
        public IActionResult Test6()
        {
            return RedirectToAction("Test7");
        }
        [HttpGet("test7")]
        public IActionResult Test7()
        {
            return Ok();
        }
    }
}
