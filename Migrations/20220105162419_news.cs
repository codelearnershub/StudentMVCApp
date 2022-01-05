using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace StudentMVCApp.Migrations
{
    public partial class news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ship",
                table: "Ship");

            migrationBuilder.RenameTable(
                name: "Ship",
                newName: "Pythons");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Pythons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pythons",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(767)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pythons",
                table: "Pythons",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pythons",
                table: "Pythons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Pythons",
                newName: "Ship");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ship",
                type: "varchar(767)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ship",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ship",
                table: "Ship",
                column: "Name");
        }
    }
}
