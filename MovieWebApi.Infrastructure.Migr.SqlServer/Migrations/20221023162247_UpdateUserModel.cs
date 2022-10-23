using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class UpdateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76107245-5942-4342-8aa9-d8f0b3a74d3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "975bf1d3-468c-4011-9766-8157854f8920");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1fea0be6-3498-4abc-93c1-ec558898a0e8", "1a24df5b-1e6f-4d16-9598-33b6b1995cb3", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a0f5e084-6e44-4fad-96a3-5b2ddece72d8", "a033f8c6-461d-44de-b396-38656f4f4c79", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fea0be6-3498-4abc-93c1-ec558898a0e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0f5e084-6e44-4fad-96a3-5b2ddece72d8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76107245-5942-4342-8aa9-d8f0b3a74d3b", "c159fe4b-f28a-48d2-adb2-253c36a0da8e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "975bf1d3-468c-4011-9766-8157854f8920", "8e03d53e-715d-445a-a899-0b72a375683d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
