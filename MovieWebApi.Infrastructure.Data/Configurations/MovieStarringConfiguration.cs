using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;

namespace MovieWebApi.Infrastructure.Data.Configurations
{
    public class MovieStarringConfiguration : IEntityTypeConfiguration<MovieStarring>
    {
        public void Configure(EntityTypeBuilder<MovieStarring> builder)
        {
            builder.HasKey(opt => new { opt.MovieId, opt.StarringId });

            builder.HasOne(opt => opt.Movie)
                .WithMany(movie => movie.MovieStarrings)
                .HasForeignKey(movie => movie.MovieId);

            builder.HasOne(opt => opt.Starring)
                .WithMany(starring => starring.MovieStarrings)
                .HasForeignKey(starring => starring.StarringId);

            builder.HasData(
                new MovieStarring
                {
                    MovieId = new Guid("01abbca8-664d-4b20-b5de-024705497d4a"),
                    StarringId = new Guid("11abbca8-664d-4b20-b5de-024705497d4a"),                    
                },
                new MovieStarring
                {
                    MovieId = new Guid("02abbca8-664d-4b20-b5de-024705497d4a"),
                    StarringId = new Guid("12abbca8-664d-4b20-b5de-024705497d4a"),
                },
                new MovieStarring
                {
                    MovieId = new Guid("02abbca8-664d-4b20-b5de-024705497d4a"),
                    StarringId = new Guid("11abbca8-664d-4b20-b5de-024705497d4a"),
                },
                new MovieStarring
                {
                    MovieId = new Guid("01abbca8-664d-4b20-b5de-024705497d4a"),
                    StarringId = new Guid("12abbca8-664d-4b20-b5de-024705497d4a"),
                }
            );
        }
    }
}
