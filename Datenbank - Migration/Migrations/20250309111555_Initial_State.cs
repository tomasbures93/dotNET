using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Datenbank___Migration.Migrations
{
    /// <inheritdoc />
    public partial class Initial_State : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Musste alles auskomentieren ... dann Update-Migration geht!
            // VOR es wollte immer Existierte tabelle erstellen.


            //migrationBuilder.CreateTable(
            //    name: "Books",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Titel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        ReleaseDatum = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Books", x => x.ID);
            //    });

            //migrationBuilder.InsertData(
            //    table: "Books",
            //    columns: new[] { "ID", "ReleaseDatum", "Titel" },
            //    values: new object[,]
            //    {
            //        { 1, "1.1.1111", "Beste Buch" },
            //        { 2, "2.2.2222 ", "Buch nummer 2" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
