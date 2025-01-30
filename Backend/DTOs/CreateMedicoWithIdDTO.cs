using SNS.Models;
using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class CreateMedicoWithIdDTO
    {
        [Required(ErrorMessage = "O utilizador é obrigatório.")]
        public required int MedicoUtilizadorId { get; set; }

        [Required(ErrorMessage = "O histórico laboral do médico é obrigatório.")]
        public HistoricoLaboralDTO? HistoricoLaboral { get; set; }

        [Required(ErrorMessage = "A especialidade do médico é obrigatória.")]
        public int EspecialidadeId { get; set; }

        [Required(ErrorMessage = "O número médico é obrigatório.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O número médico deve ter 9 dígitos.")]
        public int NMedico { get; set; }



    }
}
