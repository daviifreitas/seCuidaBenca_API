using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace seCuidaBenca.Migrations.Ocorrencia
{
    public partial class AddTheDateOfOcurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ocorrencia",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ocorrencia");
        }
    }
}
