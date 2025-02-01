using System.ComponentModel.DataAnnotations.Schema;

namespace SNS.Models
{
    public class BaixaMedica
    {
        public int Id { get; set; }
        public DateTime DataEmissao { get; } = DateTime.Now;
        public DateTime? DataAtualizacao { get; set; }
        public required string Diagnostico { get; set; }
        public required string PeriodoDeIncapacidade { get; set; }
        public string? Recomendacoes { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public int tipoDeSetorId { get; set; }
        public virtual TipoDeSetor tipoDeSetor { get; set; } = null!;
    }
}
