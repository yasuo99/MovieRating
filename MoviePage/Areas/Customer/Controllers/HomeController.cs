using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviePage.Areas.Customer.Dtos;
using MoviePage.Data;
using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var homeDto = new HomeDTO();
            homeDto.Movies = await _db.Movies.ToListAsync();
            homeDto.Actors = await _db.Actors.ToListAsync();
            homeDto.Directors = await _db.Directors.ToListAsync();
            return View(homeDto);
        }
        public async Task<IActionResult> MovieDetail(Guid id)
        {
            var movie = await _db.Movies.Where(movie => movie.Id == id)
                .Include(inc => inc.Actors)
                .Include(inc => inc.Directors)
                .Include(inc => inc.Tags)
                .Include(inc => inc.Genres)
                .AsNoTracking().FirstOrDefaultAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
