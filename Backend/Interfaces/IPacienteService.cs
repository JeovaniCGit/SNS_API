using SNS.DTOs;
using SNS.Utilities;
using SNS.Models;

namespace SNS.Interfaces
{
    public interface IPacienteService
    {
        Task<Result<Paciente>> ValidatePacienteForRegistration(UtilizadorRegistrationDTO userDTO, CreatePacienteDTO pacienteDTO, Utilizador user);
        Task<Result<GetPacienteDTO>> GetPacienteById(int id);
        Task<List<GetPacienteDTO>> GetAllPacientes(int pageNumber, int pageSize);
    }
}
