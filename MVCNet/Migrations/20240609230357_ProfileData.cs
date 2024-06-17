using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCNet.Migrations
{
    /// <inheritdoc />
    public partial class ProfileData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "IdProfile", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Developer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "IdProfile",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "IdProfile",
                keyValue: 2);
        }
    }
}
