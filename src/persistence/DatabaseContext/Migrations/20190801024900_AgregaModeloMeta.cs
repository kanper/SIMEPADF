using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaModeloMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meta",
                columns: table => new
                {
                    CodigoMeta = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    ValorMeta = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meta", x => x.CodigoMeta);
                    table.ForeignKey(
                        name: "FK_Meta_Indicador_CodigoMeta",
                        column: x => x.CodigoMeta,
                        principalTable: "Indicador",
                        principalColumn: "CodigoIndicador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meta_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meta_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meta_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meta_CreatedBy",
                table: "Meta",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_DeletedBy",
                table: "Meta",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_UpdatedBy",
                table: "Meta",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meta");
        }
    }
}
