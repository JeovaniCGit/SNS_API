using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SNS.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNavigationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicoDoPacienteId",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_MedicoDoPacienteId",
                table: "Paciente",
                column: "MedicoDoPacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Medico_MedicoDoPacienteId",
                table: "Paciente",
                column: "MedicoDoPacienteId",
                principalTable: "Medico",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Medico_MedicoDoPacienteId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_MedicoDoPacienteId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "MedicoDoPacienteId",
                table: "Paciente");
        }
    }
}
