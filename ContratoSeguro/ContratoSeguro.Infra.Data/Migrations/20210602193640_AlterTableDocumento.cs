using Microsoft.EntityFrameworkCore.Migrations;

namespace ContratoSeguro.Infra.Data.Migrations
{
    public partial class AlterTableDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlArquivo",
                table: "Documento",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlArquivo",
                table: "Documento");
        }
    }
}
