using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gol.IO.Infra.Data.Migrations
{
    public partial class AiplaneContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_AirplaneGol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAviao = table.Column<string>(type: "varchar(10)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    QtdPassageiros = table.Column<int>(type: "int", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AirplaneGol", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_AirplaneGol");
        }
    }
}
