namespace SNS.DTOs
{
    public class BaixaMedicaUpdateDTO
    {
        public required string Diagnostico { get; set; }
        public required string PeriodoDeIncapacidade { get; set; }
        public string? Recomendacoes { get; set; }
    }
}
