using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaTipoBeneficiariosAIndicadotProyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PorcentajeBeneficiarios",
                table: "Proyecto",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TipoBeneficiario",
                table: "Proyecto",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoBeneficiario",
                table: "Indicador",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentajeBeneficiarios",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "TipoBeneficiario",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "TipoBeneficiario",
                table: "Indicador");
        }
    }
}
