using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaTableAlertas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Mensaje = table.Column<string>(maxLength: 150, nullable: false),
                    Tipo = table.Column<string>(maxLength: 6, nullable: false),
                    Revisado = table.Column<bool>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Expira = table.Column<DateTime>(nullable: false),
                    Rol = table.Column<string>(maxLength: 15, nullable: false),
                    Pais = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alertas");
        }
    }
}
