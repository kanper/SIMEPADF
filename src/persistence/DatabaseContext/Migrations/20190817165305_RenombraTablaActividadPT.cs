using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class RenombraTablaActividadPT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActividadRt_Usuario_CreatedBy",
                table: "ActividadRt");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadRt_Usuario_DeletedBy",
                table: "ActividadRt");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadRt_PlanTrabajo_PlanTrabajoCodigoPlanTrabajo",
                table: "ActividadRt");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadRt_Usuario_UpdatedBy",
                table: "ActividadRt");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_ActividadRt_ActividadPTId",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActividadRt",
                table: "ActividadRt");

            migrationBuilder.RenameTable(
                name: "ActividadRt",
                newName: "ActividadPT");

            migrationBuilder.RenameIndex(
                name: "IX_ActividadRt_UpdatedBy",
                table: "ActividadPT",
                newName: "IX_ActividadPT_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ActividadRt_PlanTrabajoCodigoPlanTrabajo",
                table: "ActividadPT",
                newName: "IX_ActividadPT_PlanTrabajoCodigoPlanTrabajo");

            migrationBuilder.RenameIndex(
                name: "IX_ActividadRt_DeletedBy",
                table: "ActividadPT",
                newName: "IX_ActividadPT_DeletedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ActividadRt_CreatedBy",
                table: "ActividadPT",
                newName: "IX_ActividadPT_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActividadPT",
                table: "ActividadPT",
                column: "CodigoActividadPT");

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadPT_Usuario_CreatedBy",
                table: "ActividadPT",
                column: "CreatedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadPT_Usuario_DeletedBy",
                table: "ActividadPT",
                column: "DeletedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadPT_PlanTrabajo_PlanTrabajoCodigoPlanTrabajo",
                table: "ActividadPT",
                column: "PlanTrabajoCodigoPlanTrabajo",
                principalTable: "PlanTrabajo",
                principalColumn: "CodigoPlanTrabajo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadPT_Usuario_UpdatedBy",
                table: "ActividadPT",
                column: "UpdatedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_ActividadPT_ActividadPTId",
                table: "Producto",
                column: "ActividadPTId",
                principalTable: "ActividadPT",
                principalColumn: "CodigoActividadPT",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActividadPT_Usuario_CreatedBy",
                table: "ActividadPT");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadPT_Usuario_DeletedBy",
                table: "ActividadPT");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadPT_PlanTrabajo_PlanTrabajoCodigoPlanTrabajo",
                table: "ActividadPT");

            migrationBuilder.DropForeignKey(
                name: "FK_ActividadPT_Usuario_UpdatedBy",
                table: "ActividadPT");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_ActividadPT_ActividadPTId",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActividadPT",
                table: "ActividadPT");

            migrationBuilder.RenameTable(
                name: "ActividadPT",
                newName: "ActividadRt");

            migrationBuilder.RenameIndex(
                name: "IX_ActividadPT_UpdatedBy",
                table: "ActividadRt",
                newName: "IX_ActividadRt_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ActividadPT_PlanTrabajoCodigoPlanTrabajo",
                table: "ActividadRt",
                newName: "IX_ActividadRt_PlanTrabajoCodigoPlanTrabajo");

            migrationBuilder.RenameIndex(
                name: "IX_ActividadPT_DeletedBy",
                table: "ActividadRt",
                newName: "IX_ActividadRt_DeletedBy");

            migrationBuilder.RenameIndex(
                name: "IX_ActividadPT_CreatedBy",
                table: "ActividadRt",
                newName: "IX_ActividadRt_CreatedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActividadRt",
                table: "ActividadRt",
                column: "CodigoActividadPT");

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadRt_Usuario_CreatedBy",
                table: "ActividadRt",
                column: "CreatedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadRt_Usuario_DeletedBy",
                table: "ActividadRt",
                column: "DeletedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadRt_PlanTrabajo_PlanTrabajoCodigoPlanTrabajo",
                table: "ActividadRt",
                column: "PlanTrabajoCodigoPlanTrabajo",
                principalTable: "PlanTrabajo",
                principalColumn: "CodigoPlanTrabajo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActividadRt_Usuario_UpdatedBy",
                table: "ActividadRt",
                column: "UpdatedBy",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_ActividadRt_ActividadPTId",
                table: "Producto",
                column: "ActividadPTId",
                principalTable: "ActividadRt",
                principalColumn: "CodigoActividadPT",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
