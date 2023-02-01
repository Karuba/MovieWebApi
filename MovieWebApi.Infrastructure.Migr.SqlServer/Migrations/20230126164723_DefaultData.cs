using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebApi.Infrastructure.Migr.SqlServer.Migrations
{
    public partial class DefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30c1ee68-fe9e-42a5-a731-5da0a5c8796f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a11c6dd-2f05-47dc-becf-9c36b1e82ea4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "063d0c88-447a-4bde-8e3b-df88ad390db1", "52b3ef06-764d-4af2-bcc1-7dc5a64b454a", "Administrator", "ADMINISTRATOR" },
                    { "cac1887a-6ad8-474c-8f8f-ca9a23fdf07b", "8ff952fe-78a5-49c7-992f-fa4333292a49", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: "01abbca8-664d-4b20-b5de-024705497d4a",
                columns: new[] { "Image", "Rating" },
                values: new object[] { "pulpfiction.webp", 4.0 });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: "02abbca8-664d-4b20-b5de-024705497d4a",
                column: "Image",
                value: "snatch.webp");

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: "8e6e716c-a47c-4fac-9765-08dabb42e809",
                column: "Image",
                value: "dude.webp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "063d0c88-447a-4bde-8e3b-df88ad390db1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac1887a-6ad8-474c-8f8f-ca9a23fdf07b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30c1ee68-fe9e-42a5-a731-5da0a5c8796f", "800f4d40-e6a0-4be0-b7d2-08e672dc4a13", "Administrator", "ADMINISTRATOR" },
                    { "8a11c6dd-2f05-47dc-becf-9c36b1e82ea4", "cb15c146-65ad-405e-8ffb-5b31573c7762", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: "01abbca8-664d-4b20-b5de-024705497d4a",
                columns: new[] { "Image", "Rating" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: "02abbca8-664d-4b20-b5de-024705497d4a",
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: "8e6e716c-a47c-4fac-9765-08dabb42e809",
                column: "Image",
                value: null);
        }
    }
}
