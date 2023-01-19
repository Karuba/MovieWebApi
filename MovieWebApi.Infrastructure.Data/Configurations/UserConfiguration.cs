using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieWebApi.Domain.Core.Entities;

namespace MovieWebApi.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = "cbb11d71-4e29-48d0-93d0-55558777336b",
                    UserName = "Kirill",
                },
                new Movie
                {
                },
                new Movie
                {
                }
            );
        }
    }
}
