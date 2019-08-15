using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class ModificaPlanMonitoreoEvaluacionProyectoIdentificador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoId_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyecto_EstadoProyecto_EstadoProyectoId",
                table: "Proyecto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanMonitoreoEvaluacion",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PlanMonitoreoEvaluacion_ProyectoCodigoProyecto",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "ProyectoId",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.RenameColumn(
                name: "PlanMonitoreoEvaluacionProyectoId",
                table: "PlanDesagregacion",
                newName: "PlanMonitoreoEvaluacionProyectoCodigoProyecto");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDesagregacion_PlanMonitoreoEvaluacionProyectoId_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                newName: "IX_PlanDesagregacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoProyectoId",
                table: "Proyecto",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProyectoCodigoProyecto",
                table: "PlanMonitoreoEvaluacion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanMonitoreoEvaluacion",
                table: "PlanMonitoreoEvaluacion",
                columns: new[] { "ProyectoCodigoProyecto", "IndicadorId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion",
                column: "ProyectoCodigoProyecto1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                columns: new[] { "PlanMonitoreoEvaluacionProyectoCodigoProyecto", "PlanMonitoreoEvaluacionIndicadorId" },
                principalTable: "PlanMonitoreoEvaluacion",
                principalColumns: new[] { "ProyectoCodigoProyecto", "IndicadorId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion",
                column: "ProyectoCodigoProyecto1",
                principalTable: "Proyecto",
                principalColumn: "CodigoProyecto",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyecto_EstadoProyecto_EstadoProyectoId",
                table: "Proyecto",
                column: "EstadoProyectoId",
                principalTable: "EstadoProyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyecto_EstadoProyecto_EstadoProyectoId",
                table: "Proyecto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanMonitoreoEvaluacion",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PlanMonitoreoEvaluacion_ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropColumn(
                name: "ProyectoCodigoProyecto1",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.RenameColumn(
                name: "PlanMonitoreoEvaluacionProyectoCodigoProyecto",
                table: "PlanDesagregacion",
                newName: "PlanMonitoreoEvaluacionProyectoId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanDesagregacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                newName: "IX_PlanDesagregacion_PlanMonitoreoEvaluacionProyectoId_PlanMonitoreoEvaluacionIndicadorId");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoProyectoId",
                table: "Proyecto",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Proyecto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProyectoCodigoProyecto",
                table: "PlanMonitoreoEvaluacion",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ProyectoId",
                table: "PlanMonitoreoEvaluacion",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanMonitoreoEvaluacion",
                table: "PlanMonitoreoEvaluacion",
                columns: new[] { "ProyectoId", "IndicadorId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_ProyectoCodigoProyecto",
                table: "PlanMonitoreoEvaluacion",
                column: "ProyectoCodigoProyecto");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoId_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                columns: new[] { "PlanMonitoreoEvaluacionProyectoId", "PlanMonitoreoEvaluacionIndicadorId" },
                principalTable: "PlanMonitoreoEvaluacion",
                principalColumns: new[] { "ProyectoId", "IndicadorId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto",
                table: "PlanMonitoreoEvaluacion",
                column: "ProyectoCodigoProyecto",
                principalTable: "Proyecto",
                principalColumn: "CodigoProyecto",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyecto_EstadoProyecto_EstadoProyectoId",
                table: "Proyecto",
                column: "EstadoProyectoId",
                principalTable: "EstadoProyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
