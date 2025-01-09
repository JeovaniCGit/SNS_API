using SNS.Models;
using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class HistoricoLaboralDTO
    {
        [Required(ErrorMessage = "A instituição é obrigatória.")]
        public int Instituiçãoid { get; set; }

        [Required(ErrorMessage = "A data de inicio é obrigatória.")]
        public DateTime? DataInicio { get; set; }

        [Required(ErrorMessage = "A data de fim é obrigatória.")]
        public DateTime? DataFim { get; set; }
    }
}
