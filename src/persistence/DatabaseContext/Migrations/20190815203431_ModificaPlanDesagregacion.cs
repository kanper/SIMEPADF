using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class ModificaPlanDesagregacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDesagregacion",
                table: "PlanDesagregacion");

            migrationBuilder.DropColumn(
                name: "PlanProyectoId",
                table: "PlanDesagregacion");

            migrationBuilder.DropColumn(
                name: "PlanIndicadorId",
                table: "PlanDesagregacion");

            migrationBuilder.AlterColumn<string>(
                name: "PlanMonitoreoEvaluacionProyectoCodigoProyecto",
                table: "PlanDesagregacion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDesagregacion",
                table: "PlanDesagregacion",
                columns: new[] { "DesagregacionId", "PlanMonitoreoEvaluacionIndicadorId", "PlanMonitoreoEvaluacionProyectoCodigoProyecto" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                columns: new[] { "PlanMonitoreoEvaluacionProyectoCodigoProyecto", "PlanMonitoreoEvaluacionIndicadorId" },
                principalTable: "PlanMonitoreoEvaluacion",
                principalColumns: new[] { "ProyectoCodigoProyecto", "IndicadorId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanDesagregacion",
                table: "PlanDesagregacion");

            migrationBuilder.AlterColumn<string>(
                name: "PlanMonitoreoEvaluacionProyectoCodigoProyecto",
                table: "PlanDesagregacion",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "PlanProyectoId",
                table: "PlanDesagregacion",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlanIndicadorId",
                table: "PlanDesagregacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanDesagregacion",
                table: "PlanDesagregacion",
                columns: new[] { "DesagregacionId", "PlanProyectoId", "PlanIndicadorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                columns: new[] { "PlanMonitoreoEvaluacionProyectoCodigoProyecto", "PlanMonitoreoEvaluacionIndicadorId" },
                principalTable: "PlanMonitoreoEvaluacion",
                principalColumns: new[] { "ProyectoCodigoProyecto", "IndicadorId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
