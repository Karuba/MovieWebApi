using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class InitNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Starring",
                columns: table => new
                {
                    StarringId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starring", x => x.StarringId);
                });

            migrationBuilder.CreateTable(
                name: "MovieStarring",
                columns: table => new
                {
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StarringsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStarring", x => new { x.MoviesId, x.StarringsId });
                    table.ForeignKey(
                        name: "FK_MovieStarring_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStarring_Starring_StarringsId",
                        column: x => x.StarringsId,
                        principalTable: "Starring",
                        principalColumn: "StarringId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieStarrings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StarringId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStarrings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieStarrings_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStarrings_Starring_StarringId",
                        column: x => x.StarringId,
                        principalTable: "Starring",
                        principalColumn: "StarringId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Starring",
                columns: new[] { "StarringId", "Description", "FirstName", "SecondName" },
                values: new object[] { new Guid("11abbca8-664d-4b20-b5de-024705497d4a"), "One of the main character", "John", "Travolta" });

            migrationBuilder.InsertData(
                table: "Starring",
                columns: new[] { "StarringId", "Description", "FirstName", "SecondName" },
                values: new object[] { new Guid("12abbca8-664d-4b20-b5de-024705497d4a"), "One of the main character", "Samuel L.", "Jackson" });

            migrationBuilder.InsertData(
                table: "MovieStarrings",
                columns: new[] { "Id", "MovieId", "StarringId" },
                values: new object[,]
                {
                    { new Guid("161b89eb-4dde-474b-894c-75be72212e86"), new Guid("02abbca8-664d-4b20-b5de-024705497d4a"), new Guid("11abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("9bc7c0a4-eb40-4c72-8969-0e5442a20cce"), new Guid("01abbca8-664d-4b20-b5de-024705497d4a"), new Guid("12abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("cb1cced4-6fa8-463c-b03c-3d82ec10ce35"), new Guid("01abbca8-664d-4b20-b5de-024705497d4a"), new Guid("11abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("fa40dd43-0867-49aa-95f8-42c04406942f"), new Guid("02abbca8-664d-4b20-b5de-024705497d4a"), new Guid("12abbca8-664d-4b20-b5de-024705497d4a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieStarring_StarringsId",
                table: "MovieStarring",
                column: "StarringsId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStarrings_MovieId",
                table: "MovieStarrings",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStarrings_StarringId",
                table: "MovieStarrings",
                column: "StarringId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieStarring");

            migrationBuilder.DropTable(
                name: "MovieStarrings");

            migrationBuilder.DropTable(
                name: "Starring");
        }
    }
}
