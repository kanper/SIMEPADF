﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoEstado = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoProyecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NombrePersonal = table.Column<string>(maxLength: 50, nullable: false),
                    ApellidoPersonal = table.Column<string>(maxLength: 50, nullable: false),
                    Cargo = table.Column<string>(maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    FechaAfilacion = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objetivo",
                columns: table => new
                {
                    CodigoObjetivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    NombreObjetivo = table.Column<string>(maxLength: 500, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objetivo", x => x.CodigoObjetivo);
                    table.ForeignKey(
                        name: "FK_Objetivo_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objetivo_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objetivo_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizacionResponsable",
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
                    NombreOrganizacion = table.Column<string>(maxLength: 70, nullable: false),
                    SiglasOrganizacion = table.Column<string>(maxLength: 8, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizacionResponsable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizacionResponsable_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizacionResponsable_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizacionResponsable_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
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
                    NombrePais = table.Column<string>(maxLength: 30, nullable: false),
                    SiglaPais = table.Column<string>(maxLength: 5, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pais_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pais_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pais_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    CodigoProyecto = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    NombreProyecto = table.Column<string>(maxLength: 100, nullable: false),
                    FechaAprobacion = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    MontoProyecto = table.Column<float>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    EstadoProyectoId = table.Column<int>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.CodigoProyecto);
                    table.ForeignKey(
                        name: "FK_Proyecto_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyecto_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyecto_EstadoProyecto_EstadoProyectoId",
                        column: x => x.EstadoProyectoId,
                        principalTable: "EstadoProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyecto_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocioInternacional",
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
                    NombreSocio = table.Column<string>(maxLength: 50, nullable: false),
                    SiglasSocio = table.Column<string>(maxLength: 8, nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocioInternacional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocioInternacional_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocioInternacional_Usuario_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocioInternacional_Usuario_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoOrganizacion",
                columns: table => new
                {
                    OrganizacionId = table.Column<int>(nullable: false),
                    ProyectoId = table.Column<string>(nullable: false),
                    OrganizacionResponsableId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoOrganizacion", x => new { x.OrganizacionId, x.ProyectoId });
                    table.ForeignKey(
                        name: "FK_ProyectoOrganizacion_OrganizacionResponsable_OrganizacionResponsableId",
                        column: x => x.OrganizacionResponsableId,
                        principalTable: "OrganizacionResponsable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProyectoOrganizacion_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "CodigoProyecto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoPais",
                columns: table => new
                {
                    PaisId = table.Column<int>(nullable: false),
                    ProyectoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoPais", x => new { x.PaisId, x.ProyectoId });
                    table.ForeignKey(
                        name: "FK_ProyectoPais_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoPais_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "CodigoProyecto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoUsuario",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    ProyectoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoUsuario", x => new { x.UsuarioId, x.ProyectoId });
                    table.ForeignKey(
                        name: "FK_ProyectoUsuario_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "CodigoProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoSocio",
                columns: table => new
                {
                    SocioId = table.Column<int>(nullable: false),
                    ProyectoId = table.Column<string>(nullable: false),
                    SocioInternacionalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoSocio", x => new { x.SocioId, x.ProyectoId });
                    table.ForeignKey(
                        name: "FK_ProyectoSocio_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "CodigoProyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoSocio_SocioInternacional_SocioInternacionalId",
                        column: x => x.SocioInternacionalId,
                        principalTable: "SocioInternacional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_CreatedBy",
                table: "Objetivo",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_DeletedBy",
                table: "Objetivo",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_UpdatedBy",
                table: "Objetivo",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacionResponsable_CreatedBy",
                table: "OrganizacionResponsable",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacionResponsable_DeletedBy",
                table: "OrganizacionResponsable",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizacionResponsable_UpdatedBy",
                table: "OrganizacionResponsable",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_CreatedBy",
                table: "Pais",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_DeletedBy",
                table: "Pais",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_UpdatedBy",
                table: "Pais",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_CreatedBy",
                table: "Proyecto",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_DeletedBy",
                table: "Proyecto",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_EstadoProyectoId",
                table: "Proyecto",
                column: "EstadoProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_UpdatedBy",
                table: "Proyecto",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoOrganizacion_OrganizacionResponsableId",
                table: "ProyectoOrganizacion",
                column: "OrganizacionResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoOrganizacion_ProyectoId",
                table: "ProyectoOrganizacion",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoPais_ProyectoId",
                table: "ProyectoPais",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoSocio_ProyectoId",
                table: "ProyectoSocio",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoSocio_SocioInternacionalId",
                table: "ProyectoSocio",
                column: "SocioInternacionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoUsuario_ProyectoId",
                table: "ProyectoUsuario",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_SocioInternacional_CreatedBy",
                table: "SocioInternacional",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SocioInternacional_DeletedBy",
                table: "SocioInternacional",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SocioInternacional_UpdatedBy",
                table: "SocioInternacional",
                column: "UpdatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objetivo");

            migrationBuilder.DropTable(
                name: "ProyectoOrganizacion");

            migrationBuilder.DropTable(
                name: "ProyectoPais");

            migrationBuilder.DropTable(
                name: "ProyectoSocio");

            migrationBuilder.DropTable(
                name: "ProyectoUsuario");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "OrganizacionResponsable");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "SocioInternacional");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "EstadoProyecto");
        }
    }
}