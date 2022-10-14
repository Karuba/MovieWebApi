using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieWebApi.Domain.Core.Entities;

namespace MovieWebApi.Infrastructure.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData( 
                new Movie
                {
                    Id = new Guid("01abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Pulp Fiction",
                    Description = "This is film was made by Quentin Tarantino",
                    Rating = null,
                },
                new Movie
                {
                    Id = new Guid("02abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Snatch",
                    Description = "This is film was made by Guy Ritchie",
                    Rating = 3,
                }
            );
        }
    }
}
