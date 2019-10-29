using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class CambiaElModeloDeTipoBeneficiario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentajeBeneficiarios",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "Porcentaje",
                table: "Meta");

            migrationBuilder.AlterColumn<string>(
                name: "TipoBeneficiario",
                table: "Proyecto",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Beneficiarios",
                table: "Proyecto",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "ValorMeta",
                table: "Meta",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "TipoBeneficiario",
                table: "Indicador",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoBeneficiario",
                table: "Proyecto",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Beneficiarios",
                table: "Proyecto",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<float>(
                name: "PorcentajeBeneficiarios",
                table: "Proyecto",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "ValorMeta",
                table: "Meta",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<float>(
                name: "Porcentaje",
                table: "Meta",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "TipoBeneficiario",
                table: "Indicador",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);
        }
    }
}
