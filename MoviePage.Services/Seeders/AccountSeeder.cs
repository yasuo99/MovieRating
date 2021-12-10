using Microsoft.AspNetCore.Identity;
using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Seeders
{
    public static class AccountSeeder
    {
        public static void SeedAccount(UserManager<Account> userManager)
        {
            if (userManager.FindByNameAsync("Admin").GetAwaiter().GetResult() == null)
            {
                var account = new Account
                {
                    UserName = "Admin",
                    Email = "yasuo12091999@gmail.com"
                };
                userManager.CreateAsync(account, "Thanhpro1@").GetAwaiter().GetResult();
            }
            if (userManager.FindByNameAsync("BManager").GetAwaiter().GetResult() == null)
            {
                var account = new Account
                {
                    UserName = "Bmanager",
                    Email = "yasuo120999@gmail.com"
                };
                userManager.CreateAsync(account, "Thanhpro1@").GetAwaiter().GetResult();
            }
            if (userManager.FindByNameAsync("Technical").GetAwaiter().GetResult() == null)
            {
                var account = new Account
                {
                    UserName = "Bmanager",
                    Email = "lnthah.work@gmail.com"
                };
                userManager.CreateAsync(account, "Thanhpro1@").GetAwaiter().GetResult();
            }
        }
    }
}
