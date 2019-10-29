using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class ModificaTrimestreTablaRegistroRevicion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Trimestre",
                table: "RegistroRevision",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RegistroRevision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RegistroRevision",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RegistroRevision",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Deleted",
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

            migrationBuilder.AlterColumn<int>(
                name: "Trimestre",
                table: "RegistroRevision",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
