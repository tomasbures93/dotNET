using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datenbank___Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddedVerlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VerlagID",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Verlags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verlags", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 1,
                column: "VerlagID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 2,
                column: "VerlagID",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verlags");

            migrationBuilder.DropColumn(
                name: "VerlagID",
                table: "Books");
        }
    }
}
