using SNS.Models;
using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class InstituicaoDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(40, ErrorMessage = "A descrição não pode ter mais de 40 caracteres")]
        public string Descri { get; set; } = null!;

        [Required(ErrorMessage = "O tipo de setor é obrigatório.")]
        public int TipoSetorId { get; set; }
        public TipoDeSetor? TipoDeSetor { get; set; }
    }
}
