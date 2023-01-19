using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class newUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a6b40dc-6ee2-464b-a44a-c16614cd0c29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f14e50ca-9ed4-4eb2-ad96-30f999a7e9cb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23a0d319-06ff-4405-8ace-26c966e8fb63", "cf122026-0a8d-40ea-bf3c-d9c3736b99db", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d89e37d1-27e0-4480-9023-6ab07a37205c", "fff11c98-737f-457f-9ac5-ec8f582cdc83", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23a0d319-06ff-4405-8ace-26c966e8fb63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d89e37d1-27e0-4480-9023-6ab07a37205c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a6b40dc-6ee2-464b-a44a-c16614cd0c29", "d0bbca32-0258-461b-ac33-13efe24333fe", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f14e50ca-9ed4-4eb2-ad96-30f999a7e9cb", "afd24703-d73d-4ac1-a4c6-fed78b70df6e", "Administrator", "ADMINISTRATOR" });
        }
    }
}
