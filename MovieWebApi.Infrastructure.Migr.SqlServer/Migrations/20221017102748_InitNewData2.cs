using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class InitNewData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieStarring");

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyValue: new Guid("161b89eb-4dde-474b-894c-75be72212e86"));

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyValue: new Guid("9bc7c0a4-eb40-4c72-8969-0e5442a20cce"));

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyValue: new Guid("cb1cced4-6fa8-463c-b03c-3d82ec10ce35"));

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyValue: new Guid("fa40dd43-0867-49aa-95f8-42c04406942f"));

            migrationBuilder.InsertData(
                table: "MovieStarrings",
                columns: new[] { "Id", "MovieId", "StarringId" },
                values: new object[,]
                {
                    { new Guid("469bf1bf-5c19-4d8d-bc02-201e0db8c17b"), new Guid("02abbca8-664d-4b20-b5de-024705497d4a"), new Guid("12abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("687ba901-8133-4a53-a520-9263454f25bb"), new Guid("01abbca8-664d-4b20-b5de-024705497d4a"), new Guid("11abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("9aa1be55-7b9b-4798-893a-e00b0c9c8373"), new Guid("02abbca8-664d-4b20-b5de-024705497d4a"), new Guid("11abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("b94d3e00-143e-4208-8c0d-650b5192bf8e"), new Guid("01abbca8-664d-4b20-b5de-024705497d4a"), new Guid("12abbca8-664d-4b20-b5de-024705497d4a") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyValue: new Guid("469bf1bf-5c19-4d8d-bc02-201e0db8c17b"));

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyValue: new Guid("687ba901-8133-4a53-a520-9263454f25bb"));

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyValue: new Guid("9aa1be55-7b9b-4798-893a-e00b0c9c8373"));

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyValue: new Guid("b94d3e00-143e-4208-8c0d-650b5192bf8e"));

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
        }
    }
}
