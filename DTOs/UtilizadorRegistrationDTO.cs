using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class UtilizadorRegistrationDTO
    {
        public string Nome { get; set; }
        //public string PasswordHash { get; set; }
        public int NTelefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public int NumeroCc { get; set; }
        public string Sexo { get; set; }
        public string Morada { get; set; }
    }
}
