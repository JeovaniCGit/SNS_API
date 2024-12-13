namespace SNS.DTOs
{
    public class BaixaMedicaCreateDTO
    {
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public int TipoDeSetorId { get; set; }
        public required string Diagnostico { get; set; }
        public required string PeriodoDeIncapacidade { get; set; }
        public string? Recomendacoes { get; set; }
    }
}
