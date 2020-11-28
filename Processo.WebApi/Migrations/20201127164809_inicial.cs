using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Processo.WebApi.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiario", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arquivo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BeneficiarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_Beneficiario_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beneficio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoBeneficioId = table.Column<int>(type: "int", nullable: true),
                    BeneficiarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficio_Beneficiario_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficio_TipoBeneficio_TipoBeneficioId",
                        column: x => x.TipoBeneficioId,
                        principalTable: "TipoBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficio_BeneficiarioId",
                table: "Beneficio",
                column: "BeneficiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficio_TipoBeneficioId",
                table: "Beneficio",
                column: "TipoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_BeneficiarioId",
                table: "Documento",
                column: "BeneficiarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficio");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "TipoBeneficio");

            migrationBuilder.DropTable(
                name: "Beneficiario");
        }
    }
}
