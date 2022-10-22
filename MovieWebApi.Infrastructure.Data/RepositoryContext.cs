using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Infrastructure.Data.Configurations;

namespace MovieWebApi.Infrastructure.Data
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) 
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.ApplyConfiguration(new MovieConfiguration());
            model.ApplyConfiguration(new StarringConfiguration());
            model.ApplyConfiguration(new MovieStarringConfiguration());
            model.ApplyConfiguration(new RoleConfiguration());
            model.ApplyConfiguration(new UserRatingConfiguration());
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Starring> Starrings { get; set; }
        public DbSet<MovieStarring> MovieStarrings { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
    }
}