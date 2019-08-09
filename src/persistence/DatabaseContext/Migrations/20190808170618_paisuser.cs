using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class paisuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Usuario",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Usuario");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Usuario",
                nullable: false,
                defaultValue: false);
        }
    }
}
