using SNS.DTOs;
using SNS.Models;

namespace SNS.DTOs
{
    public class GetMedicoDataParaBaixaDTO
    {
        public int? Id { get; set; }
        public int EspecialidadeId { get; set; }
        public ICollection<HistoricoLaboral>? AllHistoricoLaboral { get; set; }
        public UtilizadorResponseDTO? UtilizadorDoMedico { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
