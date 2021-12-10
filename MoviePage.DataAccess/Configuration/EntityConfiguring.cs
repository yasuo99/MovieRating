using Microsoft.EntityFrameworkCore;
using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.DataAccess.Configuration
{
    public static class EntityConfiguring
    {
        public static void ConfiguringEntity(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new AccountRoleConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new ActorConfiguration());
            builder.ApplyConfiguration(new MovieActorConfiguration());
            builder.ApplyConfiguration(new MovieDirectorConfiguration());
            builder.ApplyConfiguration(new MovieScheduleConfiguration());
            builder.ApplyConfiguration(new SeatConfiguration());
            builder.ApplyConfiguration(new VoteConfiguration());
            builder.ApplyConfiguration(new MovieTagConfiguration());
            builder.ApplyConfiguration(new MovieGenreConfiguration());
        }
    }
}
