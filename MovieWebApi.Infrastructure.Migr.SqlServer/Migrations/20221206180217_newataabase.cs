using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class newataabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "cd4e4164-72c1-41d5-a875-2224b732b337", "218bf0e1-a810-46fe-8f81-6f1f12ba9bcf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1fe425a-efd1-4caa-8aa0-d578b6ecf0fc", "f71fdf33-dbb2-466e-9691-f20613cd19dd", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd4e4164-72c1-41d5-a875-2224b732b337");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1fe425a-efd1-4caa-8aa0-d578b6ecf0fc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23a0d319-06ff-4405-8ace-26c966e8fb63", "cf122026-0a8d-40ea-bf3c-d9c3736b99db", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d89e37d1-27e0-4480-9023-6ab07a37205c", "fff11c98-737f-457f-9ac5-ec8f582cdc83", "User", "USER" });
        }
    }
}
