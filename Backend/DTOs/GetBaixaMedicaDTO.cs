using SNS.Models;

namespace SNS.DTOs
{
    public class GetBaixaMedicaDTO
    {
        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public required string Diagnostico { get; set; }
        public required string PeriodoDeIncapacidade { get; set; }
        public string? Recomendacoes { get; set; }
        public GetMedicoDataParaBaixaDTO? Medico { get; set; }
        public GetPacienteParaBaixaDTO? Paciente { get; set; }
        public int tipoDeSetorId { get; set; }
    }
}
