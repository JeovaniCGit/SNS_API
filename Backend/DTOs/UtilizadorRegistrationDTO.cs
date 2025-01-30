using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class UtilizadorRegistrationDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "A password é obrigatória")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "O numero de telefone é obrigatório.")]
        [RegularExpression(@"^[2-9][0-9]{8}$", ErrorMessage = "Número de telefone inválido.")]
        public required int NTelefone { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public required DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O número de CC é obrigatório.")]
        [Range(100000000, 999999999, ErrorMessage = "O número de CC deve ter exatamente 9 dígitos e não pode começar com 0.")]
        public required int NumeroCc { get; set; }

        [Required(ErrorMessage = "O sexo é obrigatório.")]
        [RegularExpression("^(Masculino|Feminino)$", ErrorMessage = "O sexo deve ser 'Masculino' ou 'Feminino'.")]
        public required string Sexo { get; set; }

        [Required(ErrorMessage = "A morada é obrigatória.")]
        [StringLength(200, ErrorMessage = "O nome não pode ter mais de 200 caracteres")]
        public required string Morada { get; set; }

        [Required(ErrorMessage = "O tipo de utilizador é obrigatório.")]
        public required int TipoDeUtilizadorid {  get; set; }

        public CreatePacienteDTO? PacienteData { get; set; }
    }
}
