using SNS.DTOs;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Interfaces
{
    public interface IMedicoService
    {
        Task<Result<Paciente>> GetPacienteByNumeroSNSAsync(int numeroSNS);
        Task<Result<Medico>> ValidateMedicoForUserRegistration(CreatePacienteDTO pacienteDTO);
        Task<Result<GetMedicoDataDTO>> AddMedico(CreateMedicoWithIdDTO createMedicoDTO);
        Task<Result<GetMedicoDataDTO>> GetMedicoById(int id);
        Task<Result<Medico>> ValidateMedicoForMedicoRegistration(CreateMedicoWithIdDTO createMedicoDTO);
        Task<Result<HistoricoLaboralDTO>> UpdateHistoricoLaboral(int medicoId, HistoricoLaboralDTO historicoDTO);
        Task<List<GetMedicoDataDTO>> GetAllMedicos(int pageNumber, int pageSize);
    }
}