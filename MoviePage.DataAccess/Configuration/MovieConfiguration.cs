using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.DataAccess.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasMany(m => m.Directors).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.Genres).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.WatchUrls).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.Tags).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.MovieSchedules).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
