using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class BaixaMedicaUpdateDTO
    {
        [StringLength(2000, ErrorMessage = "O diagnóstico não pode ter mais de 2000 caracteres")]
        public required string Diagnostico { get; set; }

        [StringLength(50, ErrorMessage = "O período não pode ter mais de 50 caracteres")]
        public required string PeriodoDeIncapacidade { get; set; }

        [StringLength(200, ErrorMessage = "As recomendações não podem ter mais de 200 caracteres")]
        public string? Recomendacoes { get; set; }
    }
}
