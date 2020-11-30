using Microsoft.EntityFrameworkCore.Migrations;

namespace Processo.WebApi.Migrations
{
    public partial class terceario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficio_TipoBeneficio_TipoBeneficioId",
                table: "Beneficio");

            migrationBuilder.DropTable(
                name: "TipoBeneficio");

            migrationBuilder.DropIndex(
                name: "IX_Beneficio_TipoBeneficioId",
                table: "Beneficio");

            migrationBuilder.DropColumn(
                name: "TipoBeneficioId",
                table: "Beneficio");

            migrationBuilder.AddColumn<string>(
                name: "DescricaoTipoBeneficio",
                table: "Beneficio",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescricaoTipoBeneficio",
                table: "Beneficio");

            migrationBuilder.AddColumn<int>(
                name: "TipoBeneficioId",
                table: "Beneficio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoBeneficio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBeneficio", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficio_TipoBeneficioId",
                table: "Beneficio",
                column: "TipoBeneficioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficio_TipoBeneficio_TipoBeneficioId",
                table: "Beneficio",
                column: "TipoBeneficioId",
                principalTable: "TipoBeneficio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
