using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datenbank___BucherDB_und_Migration.Migrations
{
    /// <inheritdoc />
    public partial class state2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HowMuchPages",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 1,
                column: "HowMuchPages",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 2,
                column: "HowMuchPages",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HowMuchPages",
                table: "Books");
        }
    }
}
