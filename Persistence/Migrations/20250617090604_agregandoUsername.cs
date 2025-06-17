using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SADVO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class agregandoUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Usuario");
        }
    }
}
