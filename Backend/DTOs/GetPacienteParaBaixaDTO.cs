using SNS.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class GetPacienteParaBaixaDTO
    {
        public int? Id { get; set; }
        public string? Profissao { get; set; }
        public string? EntidadePatronal { get; set; }
        public int? NumeroSns { get; set; }
        public UtilizadorResponseDTO? UtilizadorDoPaciente { get; set; }
        public GetMedicoDataDTO? MedicoDoPaciente { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
