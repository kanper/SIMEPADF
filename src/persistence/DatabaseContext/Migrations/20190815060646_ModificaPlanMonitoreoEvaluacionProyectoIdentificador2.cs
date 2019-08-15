using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class ModificaPlanMonitoreoEvaluacionProyectoIdentificador2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PlanMonitoreoEvaluacion_ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropColumn(
                name: "ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto",
                table: "PlanMonitoreoEvaluacion",
                column: "ProyectoCodigoProyecto",
                principalTable: "Proyecto",
                principalColumn: "CodigoProyecto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.AddColumn<string>(
                name: "ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion",
                column: "ProyectoCodigoProyecto1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion",
                column: "ProyectoCodigoProyecto1",
                principalTable: "Proyecto",
                principalColumn: "CodigoProyecto",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
