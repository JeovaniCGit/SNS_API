using SNS.Models;
using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class AddAndGetMedicoDataDTO
    {
        public int? Id { get; set; }
        public string MedicoName { get; set; }

        [Required(ErrorMessage = "O número médico é obrigatório.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O número médico deve ter 9 dígitos.")]
        public int NMedico { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória.")]
        public int EspecialidadeId { get; set; }
        public Especialidade? Especialidade { get; set; }
        public ICollection<HistoricoLaboral>? AllHistoricoLaboral { get; set; }
        public HistoricoLaboralDTO? HistoricoLaboral { get; set; }
    }
}