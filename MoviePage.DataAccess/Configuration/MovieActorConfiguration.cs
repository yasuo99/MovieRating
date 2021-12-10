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
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(k => new { k.MovieId, k.ActorId });
            builder.HasOne(o => o.Actor).WithMany(m => m.Movies).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Movie).WithMany(m => m.Actors).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
