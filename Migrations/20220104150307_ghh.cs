using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentMVCApp.Migrations
{
    public partial class ghh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Goat",
                table: "Goat");

            migrationBuilder.RenameTable(
                name: "Goat",
                newName: "Ship");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ship",
                table: "Ship",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ship",
                table: "Ship");

            migrationBuilder.RenameTable(
                name: "Ship",
                newName: "Snake");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Snake",
                table: "Snake",
                column: "Id");
        }
    }
}
