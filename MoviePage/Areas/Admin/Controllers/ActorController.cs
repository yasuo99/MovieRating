using Microsoft.AspNetCore.Mvc;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ActorController: Controller
    {
        private readonly ApplicationDbContext _db;

        public ActorController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName, LastName, BirthDate, Sex")] Actor actor)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [Bind("FirstName, LastName, BirthDate, Sex")] Actor updateActor)
        {
            return View();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return View();
        }

    }
}
