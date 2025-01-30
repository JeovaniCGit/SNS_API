using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SNS.Migrations
{
    /// <inheritdoc />
    public partial class AddedFkMedicoidToPacienteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Paciente",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Medicoid",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Medico",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_Medicoid",
                table: "Paciente",
                column: "Medicoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Medico_Medicoid",
                table: "Paciente",
                column: "Medicoid",
                principalTable: "Medico",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Medico_Medicoid",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_Medicoid",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Medicoid",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Medico");

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
    }
}
