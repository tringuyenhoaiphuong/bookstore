using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class AddSelfReferenceForCategoryAndMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("parentId", "menu");
            migrationBuilder.AddColumn<int>(
                name: "parentId",
                table: "menu",
                type: "int(11)",
                nullable: true);

            migrationBuilder.DropColumn("parentId", "category");
            migrationBuilder.AddColumn<int>(
                name: "Parentid",
                table: "category",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_parentId",
                table: "menu",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_category_Parentid",
                table: "category",
                column: "Parentid");

            migrationBuilder.AddForeignKey(
                name: "FK_category_category_Parentid",
                table: "category",
                column: "Parentid",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_menu_menu_parentId",
                table: "menu",
                column: "parentId",
                principalTable: "menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.UpdateData("menu", "id",new object[] {6, 7, 8}, "parentId", new object[]{1, 1, 1});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_category_Parentid",
                table: "category");

            migrationBuilder.DropForeignKey(
                name: "FK_menu_menu_parentId",
                table: "menu");

            migrationBuilder.DropIndex(
                name: "IX_menu_parentId",
                table: "menu");

            migrationBuilder.DropIndex(
                name: "IX_category_Parentid",
                table: "category");

            migrationBuilder.AlterColumn<int>(
                name: "parentId",
                table: "menu",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");

            migrationBuilder.AlterColumn<int>(
                name: "Parentid",
                table: "category",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true,
                oldDefaultValueSql: "'NULL'");
        }
    }
}
