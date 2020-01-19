using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class RenombraAprobacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaAprovado",
                table: "ProyectoPais",
                newName: "FechaAprobado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaAprobado",
                table: "ProyectoPais",
                newName: "FechaAprovado");
        }
    }
}
