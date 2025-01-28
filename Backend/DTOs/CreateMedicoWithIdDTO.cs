using SNS.Models;
using System.ComponentModel.DataAnnotations;

namespace SNS.DTOs
{
    public class CreateMedicoWithIdDTO
    {
        [Required(ErrorMessage = "O utilizador é obrigatório.")]
        public required int MedicoUtilizadorId { get; set; }

        [Required(ErrorMessage = "O os dados do médico são obrigatórios.")]
        public required AddAndGetMedicoDataDTO MedicoDTO { get; set; }
    }
}
