using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class CambiaLlavePrimariaDesagregadoSocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanSocioDesagregacion",
                table: "PlanSocioDesagregacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanSocioDesagregacion",
                table: "PlanSocioDesagregacion",
                columns: new[] { "PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto", "PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId", "SocioInternacionalId", "PlanDesagregacionDesagregacionId", "Fecha" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanSocioDesagregacion",
                table: "PlanSocioDesagregacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanSocioDesagregacion",
                table: "PlanSocioDesagregacion",
                columns: new[] { "PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto", "PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId", "SocioInternacionalId", "PlanDesagregacionDesagregacionId" });
        }
    }
}
