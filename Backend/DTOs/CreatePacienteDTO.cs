using SNS.Models;
using SNS.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SNS.DTOs
{
    public class CreatePacienteDTO
    {

        [StringLength(50, ErrorMessage = "A profissão não pode ter mais de 50 caracteres")]
        public string? Profissao { get; set; }

        [StringLength(50, ErrorMessage = "A profissão não pode ter mais de 50 caracteres")]
        public string? EntidadePatronal { get; set; }
        public int? NumeroSns { get; set; }

        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        public int? MedicoToAttributeId { get; set; }

    }
}
