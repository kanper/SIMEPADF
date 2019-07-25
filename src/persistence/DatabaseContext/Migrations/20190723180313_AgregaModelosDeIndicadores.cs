using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaModelosDeIndicadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    CodigoResultado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    NombreResultado = table.Column<string>(maxLength: 500, nullable: false),
                    ObjetivoId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.CodigoResultado);
                    table.ForeignKey(
                        name: "FK_Resultado_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resultado_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resultado_Objetivo_ObjetivoId",
                        column: x => x.ObjetivoId,
                        principalTable: "Objetivo",
                        principalColumn: "CodigoObjetivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultado_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    CodigoActividad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    NombreActividad = table.Column<string>(maxLength: 500, nullable: false),
                    ResultadoId = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.CodigoActividad);
                    table.ForeignKey(
                        name: "FK_Actividad_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividad_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actividad_Resultado_ResultadoId",
                        column: x => x.ResultadoId,
                        principalTable: "Resultado",
                        principalColumn: "CodigoResultado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actividad_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Indicador",
                columns: table => new
                {
                    CodigoIndicador = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    NombreIndicador = table.Column<string>(maxLength: 500, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicador", x => x.CodigoIndicador);
                    table.ForeignKey(
                        name: "FK_Indicador_Actividad_CodigoIndicador",
                        column: x => x.CodigoIndicador,
                        principalTable: "Actividad",
                        principalColumn: "CodigoActividad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Indicador_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indicador_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indicador_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_NombreObjetivo",
                table: "Objetivo",
                column: "NombreObjetivo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_CreatedBy",
                table: "Actividad",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_DeletedBy",
                table: "Actividad",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_NombreActividad",
                table: "Actividad",
                column: "NombreActividad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_ResultadoId",
                table: "Actividad",
                column: "ResultadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_UpdatedBy",
                table: "Actividad",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_CreatedBy",
                table: "Indicador",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_DeletedBy",
                table: "Indicador",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_NombreIndicador",
                table: "Indicador",
                column: "NombreIndicador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_UpdatedBy",
                table: "Indicador",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_CreatedBy",
                table: "Resultado",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_DeletedBy",
                table: "Resultado",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_NombreResultado",
                table: "Resultado",
                column: "NombreResultado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_ObjetivoId",
                table: "Resultado",
                column: "ObjetivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_UpdatedBy",
                table: "Resultado",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indicador");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Resultado");

            migrationBuilder.DropIndex(
                name: "IX_Objetivo_NombreObjetivo",
                table: "Objetivo");
        }
    }
}
