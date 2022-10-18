using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieWebApi.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebApi.Infrastructure.Data.Configurations
{
    public class StarringConfiguration : IEntityTypeConfiguration<Starring>
    {
        public void Configure(EntityTypeBuilder<Starring> builder)
        {
            builder.HasData(
                new Starring
                {
                    Id = new Guid("11abbca8-664d-4b20-b5de-024705497d4a"),
                    FirstName = "John",
                    SecondName = "Travolta",
                    Description = "One of the main character"
                },
                new Starring
                {
                    Id = new Guid("12abbca8-664d-4b20-b5de-024705497d4a"),
                    FirstName = "Samuel L.",
                    SecondName = "Jackson",
                    Description = "One of the main character"
                }
            );
        }
    }
}
