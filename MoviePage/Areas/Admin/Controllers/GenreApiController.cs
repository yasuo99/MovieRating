using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviePage.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Areas.Admin.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class GenreApiController : ControllerBase
    {
        private readonly ILogger<GenreApiController> _logger;
        private readonly IGenreServices _genreServices;

        public GenreApiController(ILogger<GenreApiController> logger, IGenreServices genreServices)
        {
            _logger = logger;
            _genreServices = genreServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
