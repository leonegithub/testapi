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
                keyValue: "82eaff07-24a2-40dd-9897-dfec3f1103d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f62bf39f-aed7-49a9-bc03-e67ef5008de6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "062e7fc4-8e2c-400b-9843-b50218b594be", null, "User", "USER" },
                    { "691c70c0-4cc7-43ec-90b8-6341a95bed92", null, "SuperUser", "SUPERUSER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "062e7fc4-8e2c-400b-9843-b50218b594be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "691c70c0-4cc7-43ec-90b8-6341a95bed92");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82eaff07-24a2-40dd-9897-dfec3f1103d7", null, "User", "USER" },
                    { "f62bf39f-aed7-49a9-bc03-e67ef5008de6", null, "SuperUser", "SUPERUSER" }
                });
        }
    }
}
