using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class initialize : Migration
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
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Enabled = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    ProviderKey = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.UserId, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
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
                    FechaAfilacion = table.Column<DateTime>(nullable: false),
                    Pais = table.Column<string>(maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RolId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    TipoDesagregacion = table.Column<string>(maxLength: 100, nullable: false),
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
                    NombreFuente = table.Column<string>(maxLength: 500, nullable: false),
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
                    NombreObjetivo = table.Column<string>(maxLength: 1000, nullable: false),
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
                    NombreOrganizacion = table.Column<string>(maxLength: 100, nullable: false),
                    SiglasOrganizacion = table.Column<string>(maxLength: 20, nullable: false),
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
                    NombrePais = table.Column<string>(maxLength: 50, nullable: false),
                    SiglaPais = table.Column<string>(maxLength: 10, nullable: false),
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
                    NombreProyecto = table.Column<string>(maxLength: 500, nullable: false),
                    FechaAprobacion = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    MontoProyecto = table.Column<double>(nullable: false),
                    Beneficiarios = table.Column<int>(nullable: false),
                    EstadoProyectoId = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                    NombreSocio = table.Column<string>(maxLength: 100, nullable: false),
                    SiglasSocio = table.Column<string>(maxLength: 20, nullable: false),
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
                    NombreResultado = table.Column<string>(maxLength: 1000, nullable: false),
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
                name: "ProyectoOrganizacion",
                columns: table => new
                {
                    OrganizacionResponsableId = table.Column<int>(nullable: false),
                    ProyectoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoOrganizacion", x => new { x.OrganizacionResponsableId, x.ProyectoId });
                    table.ForeignKey(
                        name: "FK_ProyectoOrganizacion_OrganizacionResponsable_OrganizacionResponsableId",
                        column: x => x.OrganizacionResponsableId,
                        principalTable: "OrganizacionResponsable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    SocioInternacionalId = table.Column<int>(nullable: false),
                    ProyectoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoSocio", x => new { x.SocioInternacionalId, x.ProyectoId });
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
                        onDelete: ReferentialAction.Cascade);
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
                    NombreActividad = table.Column<string>(maxLength: 1000, nullable: false),
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
                    NombreIndicador = table.Column<string>(maxLength: 1000, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "PlanMonitoreoEvaluacion",
                columns: table => new
                {
                    ProyectoCodigoProyecto = table.Column<string>(nullable: false),
                    IndicadorId = table.Column<int>(nullable: false),
                    MetodologiaRecoleccion = table.Column<string>(maxLength: 1000, nullable: false),
                    ValorLineaBase = table.Column<string>(maxLength: 1000, nullable: false),
                    FuenteDatoId = table.Column<int>(nullable: true),
                    FrecuenciaMedicionId = table.Column<int>(nullable: true),
                    NivelImpactoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMonitoreoEvaluacion", x => new { x.ProyectoCodigoProyecto, x.IndicadorId });
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_FrecuenciaMedicion_FrecuenciaMedicionId",
                        column: x => x.FrecuenciaMedicionId,
                        principalTable: "FrecuenciaMedicion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_FuenteDato_FuenteDatoId",
                        column: x => x.FuenteDatoId,
                        principalTable: "FuenteDato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlanMonitoreoEvaluacion_Proyecto_ProyectoCodigoProyecto",
                        column: x => x.ProyectoCodigoProyecto,
                        principalTable: "Proyecto",
                        principalColumn: "CodigoProyecto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanDesagregacion",
                columns: table => new
                {
                    PlanMonitoreoEvaluacionProyectoCodigoProyecto = table.Column<string>(nullable: false),
                    PlanMonitoreoEvaluacionIndicadorId = table.Column<int>(nullable: false),
                    DesagregacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDesagregacion", x => new { x.DesagregacionId, x.PlanMonitoreoEvaluacionIndicadorId, x.PlanMonitoreoEvaluacionProyectoCodigoProyecto });
                    table.ForeignKey(
                        name: "FK_PlanDesagregacion_Desagregacion_DesagregacionId",
                        column: x => x.DesagregacionId,
                        principalTable: "Desagregacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanDesagregacion_PlanMonitoreoEvaluacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId",
                        columns: x => new { x.PlanMonitoreoEvaluacionProyectoCodigoProyecto, x.PlanMonitoreoEvaluacionIndicadorId },
                        principalTable: "PlanMonitoreoEvaluacion",
                        principalColumns: new[] { "ProyectoCodigoProyecto", "IndicadorId" },
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Indicador_CreatedBy",
                table: "Indicador",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_DeletedBy",
                table: "Indicador",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Indicador_UpdatedBy",
                table: "Indicador",
                column: "UpdatedBy");

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
                name: "IX_Objetivo_CreatedBy",
                table: "Objetivo",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_DeletedBy",
                table: "Objetivo",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_NombreObjetivo",
                table: "Objetivo",
                column: "NombreObjetivo",
                unique: true);

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
                name: "IX_PlanDesagregacion_PlanMonitoreoEvaluacionProyectoCodigoProyecto_PlanMonitoreoEvaluacionIndicadorId",
                table: "PlanDesagregacion",
                columns: new[] { "PlanMonitoreoEvaluacionProyectoCodigoProyecto", "PlanMonitoreoEvaluacionIndicadorId" });

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
                name: "IX_ProyectoUsuario_ProyectoId",
                table: "ProyectoUsuario",
                column: "ProyectoId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meta");

            migrationBuilder.DropTable(
                name: "PlanDesagregacion");

            migrationBuilder.DropTable(
                name: "ProyectoOrganizacion");

            migrationBuilder.DropTable(
                name: "ProyectoPais");

            migrationBuilder.DropTable(
                name: "ProyectoSocio");

            migrationBuilder.DropTable(
                name: "ProyectoUsuario");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Desagregacion");

            migrationBuilder.DropTable(
                name: "PlanMonitoreoEvaluacion");

            migrationBuilder.DropTable(
                name: "OrganizacionResponsable");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "SocioInternacional");

            migrationBuilder.DropTable(
                name: "FrecuenciaMedicion");

            migrationBuilder.DropTable(
                name: "FuenteDato");

            migrationBuilder.DropTable(
                name: "Indicador");

            migrationBuilder.DropTable(
                name: "NivelImpacto");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "EstadoProyecto");

            migrationBuilder.DropTable(
                name: "Resultado");

            migrationBuilder.DropTable(
                name: "Objetivo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
