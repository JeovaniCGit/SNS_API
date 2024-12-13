using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SNS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaixaTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diagnostico",
                table: "BaixasMedicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PeriodoDeIncapacidade",
                table: "BaixasMedicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Recomendacoes",
                table: "BaixasMedicas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnostico",
                table: "BaixasMedicas");

            migrationBuilder.DropColumn(
                name: "PeriodoDeIncapacidade",
                table: "BaixasMedicas");

            migrationBuilder.DropColumn(
                name: "Recomendacoes",
                table: "BaixasMedicas");
        }
    }
}
