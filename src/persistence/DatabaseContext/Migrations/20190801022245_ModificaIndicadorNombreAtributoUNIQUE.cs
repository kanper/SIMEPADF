using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class ModificaIndicadorNombreAtributoUNIQUE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Indicador_NombreIndicador",
                table: "Indicador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Indicador_NombreIndicador",
                table: "Indicador",
                column: "NombreIndicador",
                unique: true);
        }
    }
}
