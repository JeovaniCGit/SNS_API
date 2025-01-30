using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class GetPacienteDTO
    {
        public int? Id { get; set; }

        [StringLength(50, ErrorMessage = "A profissão não pode ter mais de 50 caracteres")]
        public string? Profissao { get; set; }

        [StringLength(50, ErrorMessage = "A profissão não pode ter mais de 50 caracteres")]
        public string? EntidadePatronal { get; set; }
        public int? NumeroSns { get; set; }

        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]

        public UtilizadorResponseDTO? UtilizadorDoPaciente { get; set; }
        public GetMedicoDataDTO? MedicoDoPaciente { get; set; }
    }
}
