using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movies = await _db.Movies.ToListAsync();
            return View(movies);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var movie = await _db.Movies.Where(movie => movie.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if(movie == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPut]
        public IActionResult Update(Guid id, Movie updateMovie)
        {
            return View();
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
