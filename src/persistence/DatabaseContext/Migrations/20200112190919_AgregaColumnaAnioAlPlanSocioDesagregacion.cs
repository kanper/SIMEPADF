using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaColumnaAnioAlPlanSocioDesagregacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroRevision_Usuario_CreatedBy",
                table: "RegistroRevision");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroRevision_Usuario_DeletedBy",
                table: "RegistroRevision");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroRevision_Usuario_UpdatedBy",
                table: "RegistroRevision");

            migrationBuilder.DropIndex(
                name: "IX_RegistroRevision_CreatedBy",
                table: "RegistroRevision");

            migrationBuilder.DropIndex(
                name: "IX_RegistroRevision_DeletedBy",
                table: "RegistroRevision");

            migrationBuilder.DropIndex(
                name: "IX_RegistroRevision_UpdatedBy",
                table: "RegistroRevision");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RegistroRevision");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RegistroRevision");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "RegistroRevision");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "RegistroRevision");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RegistroRevision");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "RegistroRevision");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPais",
                table: "PlanSocioDesagregacion",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "PlanSocioDesagregacion",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anio",
                table: "PlanSocioDesagregacion");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RegistroRevision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RegistroRevision",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "RegistroRevision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "RegistroRevision",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RegistroRevision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "RegistroRevision",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodigoPais",
                table: "PlanSocioDesagregacion",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroRevision_CreatedBy",
                table: "RegistroRevision",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroRevision_DeletedBy",
                table: "RegistroRevision",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroRevision_UpdatedBy",
                table: "RegistroRevision",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroRevision_Usuario_CreatedBy",
                table: "RegistroRevision",
                column: "CreatedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroRevision_Usuario_DeletedBy",
                table: "RegistroRevision",
                column: "DeletedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroRevision_Usuario_UpdatedBy",
                table: "RegistroRevision",
                column: "UpdatedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
