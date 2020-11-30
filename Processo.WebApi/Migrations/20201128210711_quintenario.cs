using Microsoft.EntityFrameworkCore.Migrations;

namespace Processo.WebApi.Migrations
{
    public partial class quintenario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documento_Beneficiario_BeneficiarioId",
                table: "Documento");

            migrationBuilder.DropIndex(
                name: "IX_Documento_BeneficiarioId",
                table: "Documento");

            migrationBuilder.DropColumn(
                name: "BeneficiarioId",
                table: "Documento");

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Documento",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Documento");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiarioId",
                table: "Documento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documento_BeneficiarioId",
                table: "Documento",
                column: "BeneficiarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documento_Beneficiario_BeneficiarioId",
                table: "Documento",
                column: "BeneficiarioId",
                principalTable: "Beneficiario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
