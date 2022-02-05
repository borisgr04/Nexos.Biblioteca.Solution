using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Infrastructure.Data.Migrations
{
    public partial class AlterDataTypeMaxLibros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaximoLibrosRegistrados",
                table: "Editoriales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaximoLibrosRegistrados",
                table: "Editoriales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
