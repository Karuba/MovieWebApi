using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class InitNewData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieStarrings",
                columns: new[] { "MovieId", "StarringId" },
                values: new object[,]
                {
                    { new Guid("01abbca8-664d-4b20-b5de-024705497d4a"), new Guid("11abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("01abbca8-664d-4b20-b5de-024705497d4a"), new Guid("12abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("02abbca8-664d-4b20-b5de-024705497d4a"), new Guid("11abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("02abbca8-664d-4b20-b5de-024705497d4a"), new Guid("12abbca8-664d-4b20-b5de-024705497d4a") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumns: new[] { "MovieId", "StarringId" },
                keyValues: new object[] { new Guid("01abbca8-664d-4b20-b5de-024705497d4a"), new Guid("11abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumns: new[] { "MovieId", "StarringId" },
                keyValues: new object[] { new Guid("01abbca8-664d-4b20-b5de-024705497d4a"), new Guid("12abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumns: new[] { "MovieId", "StarringId" },
                keyValues: new object[] { new Guid("02abbca8-664d-4b20-b5de-024705497d4a"), new Guid("11abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumns: new[] { "MovieId", "StarringId" },
                keyValues: new object[] { new Guid("02abbca8-664d-4b20-b5de-024705497d4a"), new Guid("12abbca8-664d-4b20-b5de-024705497d4a") });
        }
    }
}
