using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaTablaArchivoDescripcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchivoDescripcion",
                columns: table => new
                {
                    CodigoArchivo = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    NombreArchivo = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: true),
                    TipoContenido = table.Column<string>(maxLength: 5, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoDescripcion", x => x.CodigoArchivo);
                    table.ForeignKey(
                        name: "FK_ArchivoDescripcion_Producto_CodigoArchivo",
                        column: x => x.CodigoArchivo,
                        principalTable: "Producto",
                        principalColumn: "codigoProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchivoDescripcion_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchivoDescripcion_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArchivoDescripcion_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoDescripcion_CreatedBy",
                table: "ArchivoDescripcion",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoDescripcion_DeletedBy",
                table: "ArchivoDescripcion",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoDescripcion_UpdatedBy",
                table: "ArchivoDescripcion",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivoDescripcion");
        }
    }
}
