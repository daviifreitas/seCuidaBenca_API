using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tester01.Migrations
{
    public partial class AtualizacaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "tb_usuario");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_usuario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_usuario",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "dataNascimento",
                table: "tb_usuario",
                newName: "data_nascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_usuario",
                table: "tb_usuario");

            migrationBuilder.RenameTable(
                name: "tb_usuario",
                newName: "usuarios");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "usuarios",
                newName: "dataNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");
        }
    }
}
