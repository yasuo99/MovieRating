using Microsoft.Extensions.DependencyInjection;
using MoviePage.Services;
using MoviePage.Services.Interfaces;
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
            services.AddTransient<IGenreServices, GenreServices>();
        }
    }
}
