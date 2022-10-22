
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;

namespace MovieWebApi.Infrastructure.Data.Configurations
{
    public class UserRatingConfiguration : IEntityTypeConfiguration<UserRating>
    {
        public void Configure(EntityTypeBuilder<UserRating> builder)
        {
            builder.HasKey(opt => new { opt.MovieId, opt.UserId });

            builder.HasOne(opt => opt.Movie)
                .WithMany(movie => movie.UserRatings)
                .HasForeignKey(movie => movie.MovieId);

            builder.HasOne(opt => opt.User)
                .WithMany(user => user.UserRatings)
                .HasForeignKey(user => user.UserId);
        }
    }
}
