using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaNuevoTablaEntrePlanDesagregacionSocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanSocioDesagregacion",
                columns: table => new
                {
                    PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto = table.Column<string>(nullable: false),
                    PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId = table.Column<int>(nullable: false),
                    PlanDesagregacionDesagregacionId = table.Column<int>(nullable: false),
                    ProyectoSocioSocioInternacionalId = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Trimestre = table.Column<int>(nullable: false),
                    ProyectoSocioSocioInternacionalId1 = table.Column<int>(nullable: true),
                    ProyectoSocioProyectoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSocioDesagregacion", x => new { x.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto, x.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId, x.ProyectoSocioSocioInternacionalId, x.PlanDesagregacionDesagregacionId });
                    table.ForeignKey(
                        name: "FK_PlanSocioDesagregacion_ProyectoSocio_ProyectoSocioSocioInternacionalId1_ProyectoSocioProyectoId",
                        columns: x => new { x.ProyectoSocioSocioInternacionalId1, x.ProyectoSocioProyectoId },
                        principalTable: "ProyectoSocio",
                        principalColumns: new[] { "SocioInternacionalId", "ProyectoId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanSocioDesagregacion_PlanDesagregacion_PlanDesagregacionDesagregacionId_PlanDesagregacionPlanMonitoreoEvaluacionIndicadorI~",
                        columns: x => new { x.PlanDesagregacionDesagregacionId, x.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId, x.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto },
                        principalTable: "PlanDesagregacion",
                        principalColumns: new[] { "DesagregacionId", "PlanMonitoreoEvaluacionIndicadorId", "PlanMonitoreoEvaluacionProyectoCodigoProyecto" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanSocioDesagregacion_ProyectoSocioSocioInternacionalId1_ProyectoSocioProyectoId",
                table: "PlanSocioDesagregacion",
                columns: new[] { "ProyectoSocioSocioInternacionalId1", "ProyectoSocioProyectoId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlanSocioDesagregacion_PlanDesagregacionDesagregacionId_PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId_PlanDesagregacio~",
                table: "PlanSocioDesagregacion",
                columns: new[] { "PlanDesagregacionDesagregacionId", "PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId", "PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanSocioDesagregacion");
        }
    }
}
