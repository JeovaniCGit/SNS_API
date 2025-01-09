using SNS.DTOs;
using SNS.Utilities;
using SNS.Models;

namespace SNS.Services
{
    public interface IPacienteService
    {
        Task<Result<Paciente>> ValidatePacienteForRegistration(UtilizadorRegistrationDTO userDTO);
    }
}
