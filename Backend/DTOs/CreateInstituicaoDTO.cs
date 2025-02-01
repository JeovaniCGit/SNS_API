using SNS.Models;
using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class CreateInstituicaoDTO
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(40, ErrorMessage = "A descrição não pode ter mais de 40 caracteres")]
        public string Descri { get; set; } = null!;

        [Required(ErrorMessage = "O tipo de setor é obrigatório.")]
        public int TipoSetorId { get; set; }
    }
}
