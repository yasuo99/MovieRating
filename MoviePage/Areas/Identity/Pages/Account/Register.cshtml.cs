using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoviePage.Areas.Identity.Dtos;
using MoviePage.DataAccess.Data;

namespace MoviePage.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Models.Account> _userManager;
        public RegisterModel(ApplicationDbContext db, UserManager<Models.Account> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        [BindProperty]
        public RegisterDTO Register { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var account = new Models.Account
            {
                UserName = Register.UserName,
                Email = Register.Email,
                PhoneNumber = Register.PhoneNumber
            };
            var registerResult = await _userManager.CreateAsync(account, Register.Password);
            if (registerResult.Succeeded)
            {
                return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
