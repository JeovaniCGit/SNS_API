using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SNS.Migrations
{
    /// <inheritdoc />
    public partial class AddedNamePropertyToMedicoAndPacienteEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Paciente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Medico");
        }
    }
}
