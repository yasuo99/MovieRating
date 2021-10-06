using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MoviePage.Models;
using MoviePage.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoviePage.Data
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
            builder.Entity<Movie>(movie =>
            {
                movie.HasMany(m => m.Directors).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
                movie.HasMany(m => m.Genres).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
                movie.HasMany(m => m.WatchUrls).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
                movie.HasMany(m => m.Tags).WithOne(o => o.Movie).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<Vote>(vote =>
            {
                vote.HasKey(k => new { k.MovieId, k.AccountId });
                vote.HasOne(o => o.Account).WithMany(m => m.Votes).OnDelete(DeleteBehavior.Cascade);
                vote.HasOne(o => o.Movie).WithMany(m => m.Votes).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<MovieActor>(movieActor =>
            {
                movieActor.HasKey(k => new { k.MovieId, k.ActorId });
                movieActor.HasOne(o => o.Actor).WithMany(m => m.Movies).OnDelete(DeleteBehavior.Cascade);
                movieActor.HasOne(o => o.Movie).WithMany(m => m.Actors).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<MovieDirector>(movieDirector =>
            {
                movieDirector.HasKey(key => new { key.DirectorId, key.MovieId });
                movieDirector.HasOne(o => o.Movie).WithMany(m => m.Directors).OnDelete(DeleteBehavior.Cascade);
                movieDirector.HasOne(o => o.Director).WithMany(m => m.Movies).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<MovieGenres>(movieGenres =>
            {
                movieGenres.HasKey(key => new { key.MovieId, key.GenresId });
                movieGenres.HasOne(o => o.Movie).WithMany(m => m.Genres).OnDelete(DeleteBehavior.Cascade);
                movieGenres.HasOne(o => o.Genres).WithMany(m => m.Movies).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<MovieTag>(movieTag =>
            {
                movieTag.HasKey(key => new { key.MovieId, key.TagId });
                movieTag.HasOne(o => o.Movie).WithMany(m => m.Tags).OnDelete(DeleteBehavior.Cascade);
                movieTag.HasOne(o => o.Tag).WithMany(m => m.Movies).OnDelete(DeleteBehavior.Cascade);
            });
            builder.Entity<AccountRole>(ar =>
            {
                ar.HasOne(o => o.Account)
                .WithMany(m => m.Roles)
                .HasForeignKey(fk => fk.UserId)
                .IsRequired();
                ar.HasOne(o => o.Role)
                .WithMany(m => m.Accounts)
                .HasForeignKey(fk => fk.RoleId)
                .IsRequired();
            });
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
                            ((BaseModel)entry.Entity).CreatedBy = httpContextAccessor.HttpContext.User.Identity.Name;
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
