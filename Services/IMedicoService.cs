using SNS.DTOs;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Services
{
    public interface IMedicoService
    {
        Task<Result<Paciente>> GetPacienteByNumeroSNSAsync(int numeroSNS);
        Task<Result<Medico>> ValidateMedicoForUserRegistration(UtilizadorRegistrationDTO userDTO);
        Task<Result<Medico>> AddMedico(CreateMedicoWithIdDTO createMedicoDTO);
        Task<Result<AddAndGetMedicoDataDTO>> GetMedicoById(int id);
        Task<Result<Medico>> ValidateMedicoForMedicoRegistration(AddAndGetMedicoDataDTO createMedicoDTO);
        Task<Result<HistoricoLaboralDTO>> UpdateHistoricoLaboral(int medicoId, HistoricoLaboralDTO historicoDTO);
        Task<List<AddAndGetMedicoDataDTO>> GetAllMedicos(int pageNumber, int pageSize);
    }
}