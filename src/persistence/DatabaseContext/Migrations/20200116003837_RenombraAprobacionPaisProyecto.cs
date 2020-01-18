using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class RenombraAprobacionPaisProyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Aprovado",
                table: "ProyectoPais",
                newName: "Aprobado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Aprobado",
                table: "ProyectoPais",
                newName: "Aprovado");
        }
    }
}
