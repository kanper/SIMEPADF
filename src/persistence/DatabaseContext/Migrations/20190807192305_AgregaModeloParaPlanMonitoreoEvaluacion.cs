using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaModeloParaPlanMonitoreoEvaluacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desagregacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    TipoDesagregacion = table.Column<string>(maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desagregacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desagregacion_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desagregacion_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desagregacion_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrecuenciaMedicion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    NombreFrecuencia = table.Column<string>(maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrecuenciaMedicion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FrecuenciaMedicion_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrecuenciaMedicion_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrecuenciaMedicion_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuenteDato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    NombreFuente = table.Column<string>(maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuenteDato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuenteDato_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuenteDato_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuenteDato_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NivelImpacto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    NombreNivelImpacto = table.Column<string>(maxLength: 100, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelImpacto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NivelImpacto_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NivelImpacto_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NivelImpacto_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanMonitoreoEvaluacion",
                columns: table => new
                {
                    ProyectoId = table.Column<string>(nullable: false),
                    IndicadorId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    ProyectoCodigoProyecto = table.Column<string>(nullable: true),
                    MetodologiaRecoleccion = table.Column<string>(maxLength: 50, nullable: false),
                    ValorLineaBase = table.Column<string>(maxLength: 50, nullable: false),
                    FuenteDatoId = table.Column<int>(nullable: false),
                    FrecuenciaMedicionId = table.Column<int>(nullable: false),
                    NivelImpactoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMonitoreoEvaluacion", x => new { x.ProyectoId, x.IndicadorId });
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_FrecuenciaMedicion_FrecuenciaMedicionId",
                        column: x => x.FrecuenciaMedicionId,
                        principalTable: "FrecuenciaMedicion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_FuenteDato_FuenteDatoId",
                        column: x => x.FuenteDatoId,
                        principalTable: "FuenteDato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_Indicador_IndicadorId",
                        column: x => x.IndicadorId,
                        principalTable: "Indicador",
                        principalColumn: "CodigoIndicador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_NivelImpacto_NivelImpactoId",
                        column: x => x.NivelImpactoId,
                        principalTable: "NivelImpacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto",
                        column: x => x.ProyectoCodigoProyecto,
                        principalTable: "Proyecto",
                        principalColumn: "CodigoProyecto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanDesagregacion",
                columns: table => new
                {
                    PlanProyectoId = table.Column<string>(nullable: false),
                    PlanIndicadorId = table.Column<int>(nullable: false),
                    DesagregacionId = table.Column<int>(nullable: false),
                    PlanMonitoreoEvaluacionProyectoId = table.Column<string>(nullable: true),
                    PlanMonitoreoEvaluacionIndicadorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDesagregacion", x => new { x.DesagregacionId, x.PlanProyectoId, x.PlanIndicadorId });
                    table.ForeignKey(
                        name: "FK_PlanDesagregacion_Desagregacion_DesagregacionId",
                        column: x => x.DesagregacionId,
                        principalTable: "Desagregacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoId_PlanMonitoreoEvaluacionIndicadorId",
                        columns: x => new { x.PlanMonitoreoEvaluacionProyectoId, x.PlanMonitoreoEvaluacionIndicadorId },
                        principalTable: "PlanMonitoreoEvaluacion",
                        principalColumns: new[] { "ProyectoId", "IndicadorId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desagregacion_CreatedBy",
                table: "Desagregacion",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Desagregacion_DeletedBy",
                table: "Desagregacion",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Desagregacion_UpdatedBy",
                table: "Desagregacion",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FrecuenciaMedicion_CreatedBy",
                table: "FrecuenciaMedicion",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FrecuenciaMedicion_DeletedBy",
                table: "FrecuenciaMedicion",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FrecuenciaMedicion_UpdatedBy",
                table: "FrecuenciaMedicion",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FuenteDato_CreatedBy",
                table: "FuenteDato",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FuenteDato_DeletedBy",
                table: "FuenteDato",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FuenteDato_UpdatedBy",
                table: "FuenteDato",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NivelImpacto_CreatedBy",
                table: "NivelImpacto",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NivelImpacto_DeletedBy",
                table: "NivelImpacto",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NivelImpacto_UpdatedBy",
                table: "NivelImpacto",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDesagregacion_PlanMonitoreoEvaluacionProyectoId_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                columns: new[] { "PlanMonitoreoEvaluacionProyectoId", "PlanMonitoreoEvaluacionIndicadorId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_CreatedBy",
                table: "PlanMonitoreoEvaluacion",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_DeletedBy",
                table: "PlanMonitoreoEvaluacion",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_FrecuenciaMedicionId",
                table: "PlanMonitoreoEvaluacion",
                column: "FrecuenciaMedicionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_FuenteDatoId",
                table: "PlanMonitoreoEvaluacion",
                column: "FuenteDatoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_IndicadorId",
                table: "PlanMonitoreoEvaluacion",
                column: "IndicadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_NivelImpactoId",
                table: "PlanMonitoreoEvaluacion",
                column: "NivelImpactoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_ProyectoCodigoProyecto",
                table: "PlanMonitoreoEvaluacion",
                column: "ProyectoCodigoProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMonitoreoEvaluacion_UpdatedBy",
                table: "PlanMonitoreoEvaluacion",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanDesagregacion");

            migrationBuilder.DropTable(
                name: "Desagregacion");

            migrationBuilder.DropTable(
                name: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropTable(
                name: "FrecuenciaMedicion");

            migrationBuilder.DropTable(
                name: "FuenteDato");

            migrationBuilder.DropTable(
                name: "NivelImpacto");
        }
    }
}
