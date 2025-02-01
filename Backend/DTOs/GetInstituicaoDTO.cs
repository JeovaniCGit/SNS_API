using SNS.Models;
using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class GetInstituicaoDTO
    {
        public int Id { get; set; }
        public string Descri { get; set; } = null!;
        public int TipoSetorId { get; set; }
        public TipoDeSetor? TipoDeSetor { get; set; }
    }
}
