using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datenbank___Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddedPagesAndLanguageExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pages",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Language", "Pages" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Language", "Pages" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Pages",
                table: "Books");
        }
    }
}
