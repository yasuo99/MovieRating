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
    public class MovieScheduleConfiguration : IEntityTypeConfiguration<MovieSchedule>
    {
        public void Configure(EntityTypeBuilder<MovieSchedule> builder)
        {
            builder.HasOne(o => o.TheaterBranch).WithMany(m => m.MovieSchedules).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Movie).WithMany(m => m.MovieSchedules).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
