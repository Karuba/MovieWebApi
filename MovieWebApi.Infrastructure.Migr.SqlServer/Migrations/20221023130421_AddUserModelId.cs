using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class AddUserModelId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fde162f-6866-4d94-8727-06f32c0908ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c136f86d-b44c-43a2-91e7-51c9af8f5684");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76107245-5942-4342-8aa9-d8f0b3a74d3b", "c159fe4b-f28a-48d2-adb2-253c36a0da8e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "975bf1d3-468c-4011-9766-8157854f8920", "8e03d53e-715d-445a-a899-0b72a375683d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1fde162f-6866-4d94-8727-06f32c0908ae", "6342dab7-30e3-41ef-9f73-810d4d217762", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c136f86d-b44c-43a2-91e7-51c9af8f5684", "e2cde7c8-41ef-4043-91e6-0317fc274ba3", "User", "USER" });
        }
    }
}
