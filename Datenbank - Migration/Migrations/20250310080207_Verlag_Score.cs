using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datenbank___Migration.Migrations
{
    /// <inheritdoc />
    public partial class Verlag_Score : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Verlags",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Verlags");
        }
    }
}
