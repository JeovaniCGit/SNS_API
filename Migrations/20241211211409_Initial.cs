using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SNS.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descri = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Especial__3213E83FF9DC20A7", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeSetor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descri = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoDeSe__3213E83F3BE0EEE6", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeUtilizador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descri = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoDeUt__3213E83FCD81D941", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Instituição",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descri = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TipoDeSetorid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Institui__3213E83FA39E834C", x => x.id);
                    table.ForeignKey(
                        name: "FKInstituiçã171310",
                        column: x => x.TipoDeSetorid,
                        principalTable: "TipoDeSetor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    nTelefone = table.Column<int>(type: "int", nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    numeroCC = table.Column<int>(type: "int", nullable: true),
                    sexo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    morada = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TipoDeUtilizadorid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Utilizad__3213E83F4B2A429E", x => x.id);
                    table.ForeignKey(
                        name: "FKUtilizador773635",
                        column: x => x.TipoDeUtilizadorid,
                        principalTable: "TipoDeUtilizador",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nMedico = table.Column<int>(type: "int", nullable: true),
                    Utilizadorid = table.Column<int>(type: "int", nullable: false),
                    Especialidadeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Medico__3213E83FE9155587", x => x.id);
                    table.ForeignKey(
                        name: "FKMedico588860",
                        column: x => x.Especialidadeid,
                        principalTable: "Especialidade",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FKMedico808163",
                        column: x => x.Utilizadorid,
                        principalTable: "Utilizador",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profissao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    entidadePatronal = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    numeroSNS = table.Column<int>(type: "int", nullable: true),
                    Utilizadorid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Paciente__3213E83FC7F14CDD", x => x.id);
                    table.ForeignKey(
                        name: "FKPaciente149628",
                        column: x => x.Utilizadorid,
                        principalTable: "Utilizador",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Historico_Laboral",
                columns: table => new
                {
                    Instituiçãoid = table.Column<int>(type: "int", nullable: false),
                    Medicoid = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Historic__6E11538B37C7ADFC", x => new { x.Instituiçãoid, x.Medicoid });
                    table.ForeignKey(
                        name: "FKHistorico_735488",
                        column: x => x.Instituiçãoid,
                        principalTable: "Instituição",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FKHistorico_875756",
                        column: x => x.Medicoid,
                        principalTable: "Medico",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "BaixasMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    tipoDeSetorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaixasMedicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaixasMedicas_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaixasMedicas_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaixasMedicas_TipoDeSetor_tipoDeSetorId",
                        column: x => x.tipoDeSetorId,
                        principalTable: "TipoDeSetor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaixasMedicas_MedicoId",
                table: "BaixasMedicas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_BaixasMedicas_PacienteId",
                table: "BaixasMedicas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_BaixasMedicas_tipoDeSetorId",
                table: "BaixasMedicas",
                column: "tipoDeSetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_Laboral_Medicoid",
                table: "Historico_Laboral",
                column: "Medicoid");

            migrationBuilder.CreateIndex(
                name: "IX_Instituição_TipoDeSetorid",
                table: "Instituição",
                column: "TipoDeSetorid");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_Especialidadeid",
                table: "Medico",
                column: "Especialidadeid");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_Utilizadorid",
                table: "Medico",
                column: "Utilizadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_Utilizadorid",
                table: "Paciente",
                column: "Utilizadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizador_TipoDeUtilizadorid",
                table: "Utilizador",
                column: "TipoDeUtilizadorid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaixasMedicas");

            migrationBuilder.DropTable(
                name: "Historico_Laboral");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Instituição");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "TipoDeSetor");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Utilizador");

            migrationBuilder.DropTable(
                name: "TipoDeUtilizador");
        }
    }
}
