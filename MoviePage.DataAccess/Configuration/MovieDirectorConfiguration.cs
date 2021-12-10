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
    public class MovieDirectorConfiguration : IEntityTypeConfiguration<MovieDirector>
    {
        public void Configure(EntityTypeBuilder<MovieDirector> builder)
        {
            builder.HasKey(key => new { key.DirectorId, key.MovieId });
            builder.HasOne(o => o.Movie).WithMany(m => m.Directors).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Director).WithMany(m => m.Movies).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
