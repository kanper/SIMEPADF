using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class AgregaFechaAlPlanSocioDesagregado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anio",
                table: "PlanSocioDesagregacion");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "PlanSocioDesagregacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "PlanSocioDesagregacion");

            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "PlanSocioDesagregacion",
                nullable: false,
                defaultValue: 0);
        }
    }
}
