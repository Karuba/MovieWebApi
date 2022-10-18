using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using MovieWebApi.Infrastructure.Data.Configurations;

namespace MovieWebApi.Infrastructure.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) 
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new MovieConfiguration());
            model.ApplyConfiguration(new StarringConfiguration());
            model.ApplyConfiguration(new MovieStarringConfiguration());
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Starring> Starrings { get; set; }
        public DbSet<MovieStarring> MovieStarrings { get; set; }
    }
}