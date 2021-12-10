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
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasOne(o => o.TheaterBranch).WithMany(m => m.Seats).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(o => o.SeatBookings).WithOne(o => o.Seat).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
