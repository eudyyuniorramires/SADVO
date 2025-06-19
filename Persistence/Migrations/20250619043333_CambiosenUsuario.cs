using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SADVO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambiosenUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Candidatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_UsuarioId",
                table: "Candidatos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Usuario_UsuarioId",
                table: "Candidatos",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Usuario_UsuarioId",
                table: "Candidatos");

            migrationBuilder.DropIndex(
                name: "IX_Candidatos_UsuarioId",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Candidatos");
        }
    }
}
