using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class UtilizadorUpdateDTO
    {
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }

        [RegularExpression(@"^[2-9][0-9]{8}$", ErrorMessage = "Número de telefone inválido.")]
        public int NTelefone { get; set; }

        [RegularExpression("^(Masculino|Feminino)$", ErrorMessage = "O sexo deve ser 'Masculino' ou 'Feminino'.")]
        public string Sexo { get; set; }

        [StringLength(200, ErrorMessage = "O nome não pode ter mais de 200 caracteres")]
        public string Morada { get; set; }
    }
}
