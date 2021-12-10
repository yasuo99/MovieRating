using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviePage.DataAccess.Configuration;
using MoviePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.DataAccess.Data
{
    public class ApplicationWriteDbContext: IdentityDbContext<Account, Role, Guid, IdentityUserClaim<Guid>, AccountRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationWriteDbContext(DbContextOptions<ApplicationWriteDbContext> options): base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<WatchUrl> WatchUrls { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfiguringEntity();
        }
    }
}
