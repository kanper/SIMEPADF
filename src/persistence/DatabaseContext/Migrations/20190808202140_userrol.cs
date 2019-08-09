using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseContext.Migrations
{
    public partial class userrol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Rol",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rol_UsuarioId",
                table: "Rol",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_Usuario_UsuarioId",
                table: "Rol",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_Usuario_UsuarioId",
                table: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Rol_UsuarioId",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Rol");

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    RolId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_RolId",
                table: "UsuarioRol",
                column: "RolId");
        }
    }
}
