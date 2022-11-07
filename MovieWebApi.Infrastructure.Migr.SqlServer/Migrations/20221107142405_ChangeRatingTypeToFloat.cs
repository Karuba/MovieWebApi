using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class ChangeRatingTypeToFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78b9fd87-f07f-4b57-90ac-9e8a08fbc1d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dff4a0e6-6fab-4499-8684-95b2e09e1aeb");

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "UserRatings",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a6b40dc-6ee2-464b-a44a-c16614cd0c29", "d0bbca32-0258-461b-ac33-13efe24333fe", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f14e50ca-9ed4-4eb2-ad96-30f999a7e9cb", "afd24703-d73d-4ac1-a4c6-fed78b70df6e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a6b40dc-6ee2-464b-a44a-c16614cd0c29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f14e50ca-9ed4-4eb2-ad96-30f999a7e9cb");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "UserRatings",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78b9fd87-f07f-4b57-90ac-9e8a08fbc1d5", "bc2bed6f-17a3-424e-b3c7-bd223ae51368", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dff4a0e6-6fab-4499-8684-95b2e09e1aeb", "7968db5b-020b-4d1d-a6cd-3629c239b11d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
