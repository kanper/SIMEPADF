using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaNuevaTablaRegistroRevicion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRevisado",
                table: "ProyectoPais");

            migrationBuilder.DropColumn(
                name: "Revisado",
                table: "ProyectoPais");

            migrationBuilder.CreateTable(
                name: "RegistroRevision",
                columns: table => new
                {
                    RegistroRevisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Revisado = table.Column<bool>(nullable: false),
                    FechaRevisado = table.Column<DateTime>(nullable: false),
                    NumeroRevision = table.Column<int>(nullable: false),
                    ProyectoPaisPaisId = table.Column<int>(nullable: true),
                    ProyectoPaisProyectoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroRevision", x => x.RegistroRevisionId);
                    table.ForeignKey(
                        name: "FK_RegistroRevision_ProyectoPais_ProyectoPaisPaisId_ProyectoPaisProyectoId",
                        columns: x => new { x.ProyectoPaisPaisId, x.ProyectoPaisProyectoId },
                        principalTable: "ProyectoPais",
                        principalColumns: new[] { "PaisId", "ProyectoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroRevision_ProyectoPaisPaisId_ProyectoPaisProyectoId",
                table: "RegistroRevision",
                columns: new[] { "ProyectoPaisPaisId", "ProyectoPaisProyectoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroRevision");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRevisado",
                table: "ProyectoPais",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Revisado",
                table: "ProyectoPais",
                nullable: false,
                defaultValue: false);
        }
    }
}
