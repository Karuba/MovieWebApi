using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class addNewFieald : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "327f5925-2efb-43a9-ac14-b1235f898c5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b480353-c640-4d10-8b9a-8696831eb344");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movie",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30c1ee68-fe9e-42a5-a731-5da0a5c8796f", "800f4d40-e6a0-4be0-b7d2-08e672dc4a13", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a11c6dd-2f05-47dc-becf-9c36b1e82ea4", "cb15c146-65ad-405e-8ffb-5b31573c7762", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30c1ee68-fe9e-42a5-a731-5da0a5c8796f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a11c6dd-2f05-47dc-becf-9c36b1e82ea4");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movie");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "327f5925-2efb-43a9-ac14-b1235f898c5e", "b5f9a98f-7f05-42b4-a13a-e4f951c4abe4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b480353-c640-4d10-8b9a-8696831eb344", "1c28b13f-bab4-4117-a7e3-b5eb1eadc6f2", "Administrator", "ADMINISTRATOR" });
        }
    }
}
