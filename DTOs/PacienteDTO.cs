using SNS.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SNS.DTOs
{
    public class PacienteDTO
    {
        [StringLength(50, ErrorMessage = "A profissão não pode ter mais de 50 caracteres")]
        public string? Profissao { get; set; }

        [StringLength(50, ErrorMessage = "A profissão não pode ter mais de 50 caracteres")]
        public string? EntidadePatronal { get; set; }
        public int? NumeroSns { get; set; }
    }
}
