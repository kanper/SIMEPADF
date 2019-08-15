using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class ModificaPlanMonitoreoEvaluacionProyectoIdentificador3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_FrecuenciaMedicion_FrecuenciaMedicionId",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_FuenteDato_FuenteDatoId",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_NivelImpacto_NivelImpactoId",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "NivelImpactoId",
                table: "PlanMonitoreoEvaluacion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FuenteDatoId",
                table: "PlanMonitoreoEvaluacion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FrecuenciaMedicionId",
                table: "PlanMonitoreoEvaluacion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_FrecuenciaMedicion_FrecuenciaMedicionId",
                table: "PlanMonitoreoEvaluacion",
                column: "FrecuenciaMedicionId",
                principalTable: "FrecuenciaMedicion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_FuenteDato_FuenteDatoId",
                table: "PlanMonitoreoEvaluacion",
                column: "FuenteDatoId",
                principalTable: "FuenteDato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_NivelImpacto_NivelImpactoId",
                table: "PlanMonitoreoEvaluacion",
                column: "NivelImpactoId",
                principalTable: "NivelImpacto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_FrecuenciaMedicion_FrecuenciaMedicionId",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_FuenteDato_FuenteDatoId",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_NivelImpacto_NivelImpactoId",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.AlterColumn<int>(
                name: "NivelImpactoId",
                table: "PlanMonitoreoEvaluacion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuenteDatoId",
                table: "PlanMonitoreoEvaluacion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FrecuenciaMedicionId",
                table: "PlanMonitoreoEvaluacion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_FrecuenciaMedicion_FrecuenciaMedicionId",
                table: "PlanMonitoreoEvaluacion",
                column: "FrecuenciaMedicionId",
                principalTable: "FrecuenciaMedicion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_FuenteDato_FuenteDatoId",
                table: "PlanMonitoreoEvaluacion",
                column: "FuenteDatoId",
                principalTable: "FuenteDato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_NivelImpacto_NivelImpactoId",
                table: "PlanMonitoreoEvaluacion",
                column: "NivelImpactoId",
                principalTable: "NivelImpacto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
