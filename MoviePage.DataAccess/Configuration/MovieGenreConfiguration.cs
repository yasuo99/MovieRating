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
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenres>
    {
        public void Configure(EntityTypeBuilder<MovieGenres> builder)
        {
            builder.HasKey(key => new { key.MovieId, key.GenresId });
            builder.HasOne(o => o.Movie).WithMany(m => m.Genres).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Genres).WithMany(m => m.Movies).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
