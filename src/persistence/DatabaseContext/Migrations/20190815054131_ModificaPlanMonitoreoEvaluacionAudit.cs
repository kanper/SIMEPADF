using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class ModificaPlanMonitoreoEvaluacionAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Usuario_CreatedBy",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Usuario_DeletedBy",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Usuario_UpdatedBy",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PlanMonitoreoEvaluacion_CreatedBy",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PlanMonitoreoEvaluacion_DeletedBy",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropIndex(
                name: "IX_PlanMonitoreoEvaluacion_UpdatedBy",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PlanMonitoreoEvaluacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PlanMonitoreoEvaluacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PlanMonitoreoEvaluacion",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PlanMonitoreoEvaluacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "PlanMonitoreoEvaluacion",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PlanMonitoreoEvaluacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PlanMonitoreoEvaluacion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_CreatedBy",
                table: "PlanMonitoreoEvaluacion",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_DeletedBy",
                table: "PlanMonitoreoEvaluacion",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_UpdatedBy",
                table: "PlanMonitoreoEvaluacion",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Usuario_CreatedBy",
                table: "PlanMonitoreoEvaluacion",
                column: "CreatedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Usuario_DeletedBy",
                table: "PlanMonitoreoEvaluacion",
                column: "DeletedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanMonitoreoEvaluacion_Usuario_UpdatedBy",
                table: "PlanMonitoreoEvaluacion",
                column: "UpdatedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
