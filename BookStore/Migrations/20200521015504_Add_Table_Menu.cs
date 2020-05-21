using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace BookStore.Migrations
{
    public partial class Add_Table_Menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(unicode: false, maxLength: 200, nullable: true, defaultValueSql: "'NULL'"),
                    order = table.Column<int>(type: "int(11)", nullable: false, defaultValue: 0),
                    parentId = table.Column<int>(type: "int(11)", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.id);
                });

            migrationBuilder.InsertData("menu",
                new[] { "id", "title", "order", "parentId" },
                new object[,]
                {
                    { 1, "Home", 0, 0},
                    { 2, "Shop", 1, 0},
                    { 3, "Page", 2, 0},
                    { 4, "Blog", 3, 0},
                    { 5, "Contact", 4, 0},
                    { 6, "Page One", 0, 1},
                    { 7, "Page Two", 1, 1},
                    { 8, "Page Three", 2, 1},
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu");
        }
    }
}
