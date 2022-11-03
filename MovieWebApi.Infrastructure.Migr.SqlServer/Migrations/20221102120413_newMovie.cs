using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class newMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f10da33-85ff-48bc-9a71-4e88c0978882");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9144b8fa-cd9c-43d8-8c47-e818eb5df3c5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78b9fd87-f07f-4b57-90ac-9e8a08fbc1d5", "bc2bed6f-17a3-424e-b3c7-bd223ae51368", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dff4a0e6-6fab-4499-8684-95b2e09e1aeb", "7968db5b-020b-4d1d-a6cd-3629c239b11d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Description", "Name", "Rating" },
                values: new object[] { "8e6e716c-a47c-4fac-9765-08dabb42e809", "Two goons mistake 'the Dude' Lebowski for a millionaire Lebowski and urinate on his rug.", "The Big Lebowski", 5.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78b9fd87-f07f-4b57-90ac-9e8a08fbc1d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dff4a0e6-6fab-4499-8684-95b2e09e1aeb");

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: "8e6e716c-a47c-4fac-9765-08dabb42e809");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f10da33-85ff-48bc-9a71-4e88c0978882", "b7b13648-9f80-4cc7-b796-2c7344f8f3dd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9144b8fa-cd9c-43d8-8c47-e818eb5df3c5", "420d3dd7-c2b1-4e68-a03f-c12c365a6bf2", "Administrator", "ADMINISTRATOR" });
        }
    }
}
