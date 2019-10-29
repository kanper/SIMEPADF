using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class ModificaRegistroRevisionRetornado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumeroRevision",
                table: "RegistroRevision",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AddColumn<bool>(
                name: "Retornado",
                table: "RegistroRevision",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Retornado",
                table: "RegistroRevision");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroRevision",
                table: "RegistroRevision",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
