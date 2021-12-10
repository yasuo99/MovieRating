using Microsoft.Extensions.DependencyInjection;
using MoviePage.Services;
using MoviePage.Services.Handlers;
using MoviePage.Services.Interfaces;
using MoviePage.Services.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Extensions
{
    public static class Extension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFileService, FileService>();
        }
    }
}
