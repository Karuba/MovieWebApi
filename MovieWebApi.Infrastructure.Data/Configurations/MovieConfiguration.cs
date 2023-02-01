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
                    Id = "01abbca8-664d-4b20-b5de-024705497d4a",
                    Name = "Pulp Fiction",
                    Description = "This is film was made by Quentin Tarantino",
                    Rating = 4,
                    Image = "pulpfiction.webp"
                },
                new Movie
                {
                    Id = "02abbca8-664d-4b20-b5de-024705497d4a",
                    Name = "Snatch",
                    Description = "This is film was made by Guy Ritchie",
                    Rating = 3,
                    Image = "snatch.webp"
                },
                new Movie
                {
                    Id = "8e6e716c-a47c-4fac-9765-08dabb42e809",
                    Name = "The Big Lebowski",
                    Description = "Two goons mistake 'the Dude' Lebowski for a millionaire Lebowski and urinate on his rug.",
                    Rating = 5,
                    Image = "dude.webp"
                }
            );
        }
    }
}
