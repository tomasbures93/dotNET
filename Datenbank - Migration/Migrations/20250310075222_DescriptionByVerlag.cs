using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datenbank___Migration.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionByVerlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "ReleaseDatum",
            //    table: "Books",
            //    newName: "PublishDate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Verlags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Please Change");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Verlags");

            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "Books",
                newName: "ReleaseDatum");
        }
    }
}
