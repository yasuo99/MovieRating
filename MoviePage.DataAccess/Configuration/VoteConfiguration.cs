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
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(k => new { k.MovieId, k.AccountId });
            builder.HasOne(o => o.Account).WithMany(m => m.Votes).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(o => o.Movie).WithMany(m => m.Votes).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
