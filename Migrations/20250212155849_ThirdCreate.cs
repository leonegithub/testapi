using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApi.Migrations
{
    /// <inheritdoc />
    public partial class ThirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ef65ed3-a9f5-4249-9ca9-73a45b9cfd29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c612ddab-a2ea-4407-b3e6-fc53b8493cbc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b3a5e5f-940b-4b3c-aa8e-ff97b9a8b4da", null, "SuperUser", "SUPERUSER" },
                    { "a0d45c98-0a7b-41b4-8cff-0e3f3ac74e0f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b3a5e5f-940b-4b3c-aa8e-ff97b9a8b4da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0d45c98-0a7b-41b4-8cff-0e3f3ac74e0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ef65ed3-a9f5-4249-9ca9-73a45b9cfd29", null, "SuperUser", "SUPERUSER" },
                    { "c612ddab-a2ea-4407-b3e6-fc53b8493cbc", null, "User", "USER" }
                });
        }
    }
}
