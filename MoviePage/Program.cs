using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoviePage.DataAccess.Data;
using MoviePage.Models;
using MoviePage.Services.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                try
                {
                    var services = scope.ServiceProvider;
                    var roleSeederService = services.GetRequiredService<RoleManager<Role>>();
                    var userManagerService = services.GetRequiredService<UserManager<Account>>();
                    var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
                    RoleSeeder.SeedRole(roleSeederService);
                    AccountSeeder.SeedAccount(userManagerService);
                    DataSeeder.SeedData(applicationDbContext);
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
