using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestApi.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e56f9c-b822-426e-a2a8-cf3e9d47944f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99af711e-af0d-44dd-a98a-5885f1a3d243");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ef65ed3-a9f5-4249-9ca9-73a45b9cfd29", null, "SuperUser", "SUPERUSER" },
                    { "c612ddab-a2ea-4407-b3e6-fc53b8493cbc", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "46e56f9c-b822-426e-a2a8-cf3e9d47944f", null, "SuperUser", "SUPERUSER" },
                    { "99af711e-af0d-44dd-a98a-5885f1a3d243", null, "User", "USER" }
                });
        }
    }
}
