using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class InitNewData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieStarrings",
                table: "MovieStarrings");

            migrationBuilder.DropIndex(
                name: "IX_MovieStarrings_MovieId",
                table: "MovieStarrings");

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("469bf1bf-5c19-4d8d-bc02-201e0db8c17b"));

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("687ba901-8133-4a53-a520-9263454f25bb"));

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("9aa1be55-7b9b-4798-893a-e00b0c9c8373"));

            migrationBuilder.DeleteData(
                table: "MovieStarrings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("b94d3e00-143e-4208-8c0d-650b5192bf8e"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieStarrings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieStarrings",
                table: "MovieStarrings",
                columns: new[] { "MovieId", "StarringId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieStarrings",
                table: "MovieStarrings");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "MovieStarrings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieStarrings",
                table: "MovieStarrings",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_MovieStarrings_MovieId",
                table: "MovieStarrings",
                column: "MovieId");
        }
    }
}
