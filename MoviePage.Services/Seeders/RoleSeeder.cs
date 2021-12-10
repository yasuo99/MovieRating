using Microsoft.AspNetCore.Identity;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services.Seeders
{
    public static class RoleSeeder
    {
        public static void SeedRole(RoleManager<Role> _roleManager)
        {
            if (! _roleManager.RoleExistsAsync(SD.ADMIN_ROLE).GetAwaiter().GetResult())
            {
                var result =  _roleManager.CreateAsync(new Role
                {
                    Name = SD.ADMIN_ROLE
                }).GetAwaiter().GetResult();
            }
            if (! _roleManager.RoleExistsAsync(SD.BRANCH_MANAGER).GetAwaiter().GetResult())
            {
                var result =  _roleManager.CreateAsync(new Role
                {
                    Name = SD.BRANCH_MANAGER
                }).GetAwaiter().GetResult();
            }
            if (! _roleManager.RoleExistsAsync(SD.TECHNICAL_ROLE).GetAwaiter().GetResult())
            {
                var result =  _roleManager.CreateAsync(new Role
                {
                    Name = SD.TECHNICAL_ROLE
                }).GetAwaiter().GetResult();
            }
            if (! _roleManager.RoleExistsAsync(SD.USER_ROLE).GetAwaiter().GetResult())
            {
                var result =  _roleManager.CreateAsync(new Role
                {
                    Name = SD.USER_ROLE
                }).GetAwaiter().GetResult();
            }
        }
    }
}
