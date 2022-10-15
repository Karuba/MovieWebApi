using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class LionKing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Description", "Name", "Rating" },
                values: new object[] { new Guid("01abbca8-664d-4b20-b5de-024705497d4a"), "This is film was made by Quentin Tarantino", "Pulp Fiction", null });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Description", "Name", "Rating" },
                values: new object[] { new Guid("02abbca8-664d-4b20-b5de-024705497d4a"), "This is film was made by Guy Ritchie", "Snatch", 3.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
