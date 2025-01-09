using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class BaixaMedicaCreateDTO
    {
        [Required(ErrorMessage = "O médico é obrigatório.")]
        public int MedicoId { get; set; }

        [Required(ErrorMessage = "O paciente é obrigatório.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O tipo de setor é obrigatório.")]
        public int TipoDeSetorId { get; set; }

        [Required(ErrorMessage = "O diagnóstico é obrigatório.")]
        [StringLength(2000, ErrorMessage = "O diagnóstico não pode ter mais de 2000 caracteres")]
        public required string Diagnostico { get; set; }

        [Required(ErrorMessage = "O período de incapacidade é obrigatório.")]
        [StringLength(50, ErrorMessage = "O período não pode ter mais de 50 caracteres")]
        public required string PeriodoDeIncapacidade { get; set; }

        [StringLength(200, ErrorMessage = "As recomendações não podem ter mais de 200 caracteres")]
        public string? Recomendacoes { get; set; }
    }
}
