using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Processo.WebApi.Migrations
{
    public partial class septario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacao_Usuario_UsuarioId",
                table: "Movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacao_UsuarioId",
                table: "Movimentacao");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Movimentacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Movimentacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Movimentacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Movimentacao");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Movimentacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_UsuarioId",
                table: "Movimentacao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacao_Usuario_UsuarioId",
                table: "Movimentacao",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
