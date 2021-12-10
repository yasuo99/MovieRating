using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MoviePage.DataAccess.Configuration;
using MoviePage.Models;
using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<Account, Role, Guid, IdentityUserClaim<Guid>, AccountRole , IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<PG> PGs { get; set; }
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
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseModel && (e.State == EntityState.Modified || e.State == EntityState.Added)).ToList();
            var httpContextAccessor = this.GetService<IHttpContextAccessor>();
            if(entries.Count > 0)
            {
                foreach(var entry in entries)
                {
                    if(entry.Entity is BaseModel)
                    {
                        if (entry.State == EntityState.Added)
                        {
                            ((BaseModel)entry.Entity).CreatedAt = DateTime.Now;
                            ((BaseModel)entry.Entity).CreatedBy = httpContextAccessor.HttpContext.User.Identity.Name ?? "System";
                        }
                        if (entry.State == EntityState.Modified)
                        {
                            Entry((BaseModel)entry.Entity).Property(p => p.CreatedAt).IsModified = false;
                            Entry((BaseModel)entry.Entity).Property(p => p.CreatedBy).IsModified = false;
                            ((BaseModel)entry.Entity).UpdatedAt = DateTime.Now;
                            ((BaseModel)entry.Entity).UpdatedBy = httpContextAccessor.HttpContext.User.Identity.Name;
                        }
                    }
                    
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
