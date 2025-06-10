using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SADVO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class QuintaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirigentePartido_Usuarios_UsuarioId",
                table: "DirigentePartido");

            migrationBuilder.DropForeignKey(
                name: "FK_DirigentePartido_Usuarios_UsuarioId1",
                table: "DirigentePartido");

            migrationBuilder.DropIndex(
                name: "IX_DirigentePartido_UsuarioId",
                table: "DirigentePartido");

            migrationBuilder.DropIndex(
                name: "IX_DirigentePartido_UsuarioId1",
                table: "DirigentePartido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "DirigentePartido");

            migrationBuilder.DropColumn(
                name: "NombreUsuario",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContrasenaHash",
                table: "Usuario",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Usuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DirigentePartido_UsuarioId",
                table: "DirigentePartido",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DirigentePartido_Usuario_UsuarioId",
                table: "DirigentePartido",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirigentePartido_Usuario_UsuarioId",
                table: "DirigentePartido");

            migrationBuilder.DropIndex(
                name: "IX_DirigentePartido_UsuarioId",
                table: "DirigentePartido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "DirigentePartido",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "ContrasenaHash",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "NombreUsuario",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DirigentePartido_UsuarioId",
                table: "DirigentePartido",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DirigentePartido_UsuarioId1",
                table: "DirigentePartido",
                column: "UsuarioId1",
                unique: true,
                filter: "[UsuarioId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DirigentePartido_Usuarios_UsuarioId",
                table: "DirigentePartido",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirigentePartido_Usuarios_UsuarioId1",
                table: "DirigentePartido",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
