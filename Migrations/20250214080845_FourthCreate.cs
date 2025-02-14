using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApi.Migrations
{
    /// <inheritdoc />
    public partial class FourthCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "3d39a5ca-e057-48a7-92e0-56a8a696976d", null, "User", "USER" },
                    { "62e6d813-ac70-45af-83e3-f8f970ea33f6", null, "SuperUser", "SUPERUSER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d39a5ca-e057-48a7-92e0-56a8a696976d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62e6d813-ac70-45af-83e3-f8f970ea33f6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b3a5e5f-940b-4b3c-aa8e-ff97b9a8b4da", null, "SuperUser", "SUPERUSER" },
                    { "a0d45c98-0a7b-41b4-8cff-0e3f3ac74e0f", null, "User", "USER" }
                });
        }
    }
}
