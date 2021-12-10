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
    public class MovieTagConfiguration : IEntityTypeConfiguration<MovieTag>
    {
        public void Configure(EntityTypeBuilder<MovieTag> builder)
        {
            builder.HasKey(key => new { key.MovieId, key.TagId });
            builder.HasOne(o => o.Movie).WithMany(m => m.Tags).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Tag).WithMany(m => m.Movies).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
