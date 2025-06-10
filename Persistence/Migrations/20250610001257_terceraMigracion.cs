using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SADVO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class terceraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlianzaPolitica_PartidoPoliticos_PartidoPoliticoId",
                table: "AlianzaPolitica");

            migrationBuilder.DropForeignKey(
                name: "FK_AlianzaPolitica_PartidoPoliticos_PartidoPoliticoId1",
                table: "AlianzaPolitica");

            migrationBuilder.DropForeignKey(
                name: "FK_AlianzaPolitica_PartidoPoliticos_PartidoReceptorId",
                table: "AlianzaPolitica");

            migrationBuilder.DropForeignKey(
                name: "FK_AlianzaPolitica_PartidoPoliticos_PartidoSolicitanteId",
                table: "AlianzaPolitica");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatoPuestos_Candidatos_CandidatoId",
                table: "CandidatoPuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatoPuestos_PuestoElectivos_PuestoElectivoId",
                table: "CandidatoPuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_PartidoPoliticos_PartidoPoliticoId",
                table: "Candidatos");

            migrationBuilder.DropForeignKey(
                name: "FK_DirigentePartidos_PartidoPoliticos_PartidoPoliticoId",
                table: "DirigentePartidos");

            migrationBuilder.DropForeignKey(
                name: "FK_DirigentePartidos_Usuarios_UsuarioId",
                table: "DirigentePartidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Voto_CandidatoPuestos_CandidatoPuestoId",
                table: "Voto");

            migrationBuilder.DropForeignKey(
                name: "FK_Voto_Elecciones_EleccionId",
                table: "Voto");

            migrationBuilder.DropIndex(
                name: "IX_AlianzaPolitica_PartidoPoliticoId",
                table: "AlianzaPolitica");

            migrationBuilder.DropIndex(
                name: "IX_AlianzaPolitica_PartidoPoliticoId1",
                table: "AlianzaPolitica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PuestoElectivos",
                table: "PuestoElectivos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartidoPoliticos",
                table: "PartidoPoliticos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Elecciones",
                table: "Elecciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DirigentePartidos",
                table: "DirigentePartidos");

            migrationBuilder.DropIndex(
                name: "IX_DirigentePartidos_UsuarioId",
                table: "DirigentePartidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatoPuestos",
                table: "CandidatoPuestos");

            migrationBuilder.DropColumn(
                name: "PartidoPoliticoId",
                table: "AlianzaPolitica");

            migrationBuilder.DropColumn(
                name: "PartidoPoliticoId1",
                table: "AlianzaPolitica");

            migrationBuilder.RenameTable(
                name: "PuestoElectivos",
                newName: "PuestoElectivo");

            migrationBuilder.RenameTable(
                name: "PartidoPoliticos",
                newName: "PartidoPolitico");

            migrationBuilder.RenameTable(
                name: "Elecciones",
                newName: "Eleccion");

            migrationBuilder.RenameTable(
                name: "DirigentePartidos",
                newName: "DirigentePartido");

            migrationBuilder.RenameTable(
                name: "CandidatoPuestos",
                newName: "CandidatoPuesto");

            migrationBuilder.RenameIndex(
                name: "IX_DirigentePartidos_PartidoPoliticoId",
                table: "DirigentePartido",
                newName: "IX_DirigentePartido_PartidoPoliticoId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatoPuestos_PuestoElectivoId",
                table: "CandidatoPuesto",
                newName: "IX_CandidatoPuesto_PuestoElectivoId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatoPuestos_CandidatoId",
                table: "CandidatoPuesto",
                newName: "IX_CandidatoPuesto_CandidatoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Ciudadano",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Ciudadano",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoIdentidad",
                table: "Ciudadano",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Ciudadano",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Candidatos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FotoPath",
                table: "Candidatos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Candidatos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PuestoElectivo",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "EstaActivo",
                table: "PuestoElectivo",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "PuestoElectivo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Siglas",
                table: "PartidoPolitico",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PartidoPolitico",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LogoPath",
                table: "PartidoPolitico",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "EstaActivo",
                table: "PartidoPolitico",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "PartidoPolitico",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Eleccion",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "DirigentePartido",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PuestoElectivo",
                table: "PuestoElectivo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartidoPolitico",
                table: "PartidoPolitico",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eleccion",
                table: "Eleccion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DirigentePartido",
                table: "DirigentePartido",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatoPuesto",
                table: "CandidatoPuesto",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PartidoPolitico_Siglas",
                table: "PartidoPolitico",
                column: "Siglas",
                unique: true);

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
                name: "FK_AlianzaPolitica_PartidoPolitico_PartidoReceptorId",
                table: "AlianzaPolitica",
                column: "PartidoReceptorId",
                principalTable: "PartidoPolitico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlianzaPolitica_PartidoPolitico_PartidoSolicitanteId",
                table: "AlianzaPolitica",
                column: "PartidoSolicitanteId",
                principalTable: "PartidoPolitico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatoPuesto_Candidatos_CandidatoId",
                table: "CandidatoPuesto",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatoPuesto_PuestoElectivo_PuestoElectivoId",
                table: "CandidatoPuesto",
                column: "PuestoElectivoId",
                principalTable: "PuestoElectivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_PartidoPolitico_PartidoPoliticoId",
                table: "Candidatos",
                column: "PartidoPoliticoId",
                principalTable: "PartidoPolitico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirigentePartido_PartidoPolitico_PartidoPoliticoId",
                table: "DirigentePartido",
                column: "PartidoPoliticoId",
                principalTable: "PartidoPolitico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Voto_CandidatoPuesto_CandidatoPuestoId",
                table: "Voto",
                column: "CandidatoPuestoId",
                principalTable: "CandidatoPuesto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voto_Eleccion_EleccionId",
                table: "Voto",
                column: "EleccionId",
                principalTable: "Eleccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlianzaPolitica_PartidoPolitico_PartidoReceptorId",
                table: "AlianzaPolitica");

            migrationBuilder.DropForeignKey(
                name: "FK_AlianzaPolitica_PartidoPolitico_PartidoSolicitanteId",
                table: "AlianzaPolitica");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatoPuesto_Candidatos_CandidatoId",
                table: "CandidatoPuesto");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatoPuesto_PuestoElectivo_PuestoElectivoId",
                table: "CandidatoPuesto");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_PartidoPolitico_PartidoPoliticoId",
                table: "Candidatos");

            migrationBuilder.DropForeignKey(
                name: "FK_DirigentePartido_PartidoPolitico_PartidoPoliticoId",
                table: "DirigentePartido");

            migrationBuilder.DropForeignKey(
                name: "FK_DirigentePartido_Usuarios_UsuarioId",
                table: "DirigentePartido");

            migrationBuilder.DropForeignKey(
                name: "FK_DirigentePartido_Usuarios_UsuarioId1",
                table: "DirigentePartido");

            migrationBuilder.DropForeignKey(
                name: "FK_Voto_CandidatoPuesto_CandidatoPuestoId",
                table: "Voto");

            migrationBuilder.DropForeignKey(
                name: "FK_Voto_Eleccion_EleccionId",
                table: "Voto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PuestoElectivo",
                table: "PuestoElectivo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartidoPolitico",
                table: "PartidoPolitico");

            migrationBuilder.DropIndex(
                name: "IX_PartidoPolitico_Siglas",
                table: "PartidoPolitico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eleccion",
                table: "Eleccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DirigentePartido",
                table: "DirigentePartido");

            migrationBuilder.DropIndex(
                name: "IX_DirigentePartido_UsuarioId",
                table: "DirigentePartido");

            migrationBuilder.DropIndex(
                name: "IX_DirigentePartido_UsuarioId1",
                table: "DirigentePartido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatoPuesto",
                table: "CandidatoPuesto");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "DirigentePartido");

            migrationBuilder.RenameTable(
                name: "PuestoElectivo",
                newName: "PuestoElectivos");

            migrationBuilder.RenameTable(
                name: "PartidoPolitico",
                newName: "PartidoPoliticos");

            migrationBuilder.RenameTable(
                name: "Eleccion",
                newName: "Elecciones");

            migrationBuilder.RenameTable(
                name: "DirigentePartido",
                newName: "DirigentePartidos");

            migrationBuilder.RenameTable(
                name: "CandidatoPuesto",
                newName: "CandidatoPuestos");

            migrationBuilder.RenameIndex(
                name: "IX_DirigentePartido_PartidoPoliticoId",
                table: "DirigentePartidos",
                newName: "IX_DirigentePartidos_PartidoPoliticoId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatoPuesto_PuestoElectivoId",
                table: "CandidatoPuestos",
                newName: "IX_CandidatoPuestos_PuestoElectivoId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatoPuesto_CandidatoId",
                table: "CandidatoPuestos",
                newName: "IX_CandidatoPuestos_CandidatoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Ciudadano",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Ciudadano",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentoIdentidad",
                table: "Ciudadano",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Ciudadano",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Candidatos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FotoPath",
                table: "Candidatos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Candidatos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "PartidoPoliticoId",
                table: "AlianzaPolitica",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartidoPoliticoId1",
                table: "AlianzaPolitica",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PuestoElectivos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<bool>(
                name: "EstaActivo",
                table: "PuestoElectivos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "PuestoElectivos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Siglas",
                table: "PartidoPoliticos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PartidoPoliticos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "LogoPath",
                table: "PartidoPoliticos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<bool>(
                name: "EstaActivo",
                table: "PartidoPoliticos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "PartidoPoliticos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Elecciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PuestoElectivos",
                table: "PuestoElectivos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartidoPoliticos",
                table: "PartidoPoliticos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elecciones",
                table: "Elecciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DirigentePartidos",
                table: "DirigentePartidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatoPuestos",
                table: "CandidatoPuestos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlianzaPolitica_PartidoPoliticoId",
                table: "AlianzaPolitica",
                column: "PartidoPoliticoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlianzaPolitica_PartidoPoliticoId1",
                table: "AlianzaPolitica",
                column: "PartidoPoliticoId1");

            migrationBuilder.CreateIndex(
                name: "IX_DirigentePartidos_UsuarioId",
                table: "DirigentePartidos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlianzaPolitica_PartidoPoliticos_PartidoPoliticoId",
                table: "AlianzaPolitica",
                column: "PartidoPoliticoId",
                principalTable: "PartidoPoliticos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlianzaPolitica_PartidoPoliticos_PartidoPoliticoId1",
                table: "AlianzaPolitica",
                column: "PartidoPoliticoId1",
                principalTable: "PartidoPoliticos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlianzaPolitica_PartidoPoliticos_PartidoReceptorId",
                table: "AlianzaPolitica",
                column: "PartidoReceptorId",
                principalTable: "PartidoPoliticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlianzaPolitica_PartidoPoliticos_PartidoSolicitanteId",
                table: "AlianzaPolitica",
                column: "PartidoSolicitanteId",
                principalTable: "PartidoPoliticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatoPuestos_Candidatos_CandidatoId",
                table: "CandidatoPuestos",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatoPuestos_PuestoElectivos_PuestoElectivoId",
                table: "CandidatoPuestos",
                column: "PuestoElectivoId",
                principalTable: "PuestoElectivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_PartidoPoliticos_PartidoPoliticoId",
                table: "Candidatos",
                column: "PartidoPoliticoId",
                principalTable: "PartidoPoliticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirigentePartidos_PartidoPoliticos_PartidoPoliticoId",
                table: "DirigentePartidos",
                column: "PartidoPoliticoId",
                principalTable: "PartidoPoliticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirigentePartidos_Usuarios_UsuarioId",
                table: "DirigentePartidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voto_CandidatoPuestos_CandidatoPuestoId",
                table: "Voto",
                column: "CandidatoPuestoId",
                principalTable: "CandidatoPuestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voto_Elecciones_EleccionId",
                table: "Voto",
                column: "EleccionId",
                principalTable: "Elecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
