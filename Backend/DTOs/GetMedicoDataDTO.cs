using SNS.Models;
using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class GetMedicoDataDTO
    {
        public int? Id { get; set; }
        public int EspecialidadeId { get; set; }
        public ICollection<HistoricoLaboral>? AllHistoricoLaboral { get; set; }
        public UtilizadorResponseDTO? UtilizadorDoMedico {  get; set; }
    }
}