using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class ModificaIdentificadoresTablaIntermediSocioProyecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoOrganizacion_OrganizacionResponsable_OrganizacionResponsableId",
                table: "ProyectoOrganizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoSocio_SocioInternacional_SocioInternacionalId",
                table: "ProyectoSocio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProyectoSocio",
                table: "ProyectoSocio");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoSocio_SocioInternacionalId",
                table: "ProyectoSocio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProyectoOrganizacion",
                table: "ProyectoOrganizacion");

            migrationBuilder.DropIndex(
                name: "IX_ProyectoOrganizacion_OrganizacionResponsableId",
                table: "ProyectoOrganizacion");

            migrationBuilder.DropColumn(
                name: "SocioId",
                table: "ProyectoSocio");

            migrationBuilder.DropColumn(
                name: "OrganizacionId",
                table: "ProyectoOrganizacion");

            migrationBuilder.AlterColumn<int>(
                name: "SocioInternacionalId",
                table: "ProyectoSocio",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizacionResponsableId",
                table: "ProyectoOrganizacion",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProyectoSocio",
                table: "ProyectoSocio",
                columns: new[] { "SocioInternacionalId", "ProyectoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProyectoOrganizacion",
                table: "ProyectoOrganizacion",
                columns: new[] { "OrganizacionResponsableId", "ProyectoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoOrganizacion_OrganizacionResponsable_OrganizacionResponsableId",
                table: "ProyectoOrganizacion",
                column: "OrganizacionResponsableId",
                principalTable: "OrganizacionResponsable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoSocio_SocioInternacional_SocioInternacionalId",
                table: "ProyectoSocio",
                column: "SocioInternacionalId",
                principalTable: "SocioInternacional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoOrganizacion_OrganizacionResponsable_OrganizacionResponsableId",
                table: "ProyectoOrganizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ProyectoSocio_SocioInternacional_SocioInternacionalId",
                table: "ProyectoSocio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProyectoSocio",
                table: "ProyectoSocio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProyectoOrganizacion",
                table: "ProyectoOrganizacion");

            migrationBuilder.AlterColumn<int>(
                name: "SocioInternacionalId",
                table: "ProyectoSocio",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SocioId",
                table: "ProyectoSocio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "OrganizacionResponsableId",
                table: "ProyectoOrganizacion",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OrganizacionId",
                table: "ProyectoOrganizacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProyectoSocio",
                table: "ProyectoSocio",
                columns: new[] { "SocioId", "ProyectoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProyectoOrganizacion",
                table: "ProyectoOrganizacion",
                columns: new[] { "OrganizacionId", "ProyectoId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoSocio_SocioInternacionalId",
                table: "ProyectoSocio",
                column: "SocioInternacionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoOrganizacion_OrganizacionResponsableId",
                table: "ProyectoOrganizacion",
                column: "OrganizacionResponsableId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoOrganizacion_OrganizacionResponsable_OrganizacionResponsableId",
                table: "ProyectoOrganizacion",
                column: "OrganizacionResponsableId",
                principalTable: "OrganizacionResponsable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProyectoSocio_SocioInternacional_SocioInternacionalId",
                table: "ProyectoSocio",
                column: "SocioInternacionalId",
                principalTable: "SocioInternacional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
