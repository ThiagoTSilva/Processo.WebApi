using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Processo.WebApi.Migrations
{
    public partial class octenario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Movimentacao");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Movimentacao",
                newName: "DataTramitacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataTramitacao",
                table: "Movimentacao",
                newName: "DataCadastro");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Movimentacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
