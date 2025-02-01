using SNS.DTOs;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Interfaces
{
    public interface IBaixaMedicaService
    {
        #region BaixasMedicas
        Task<List<GetBaixaMedicaDTO>> GetAllBaixasAsync(int pageNumber, int pageSize);
        Task<List<GetBaixaMedicaDTO>> GetAllBaixasBySetorIdAsync(int tipoSetorId, int pageNumber, int pageSize);
        Task<List<GetBaixaMedicaDTO>> GetAllBaixasByPacienteAsync(int pacienteId);
        Task<Result<GetBaixaMedicaDTO?>> GetBaixaMedicaByIdAsync(int id);
        Task<Result<BaixaMedica?>> UpdateBaixaMedicaAsync(int id, BaixaMedicaUpdateDTO baixaAtualizada);
        Task<Result<bool>> DeleteBaixaMedicaAsync(int baixaMedicaId);
        Task<Result<BaixaMedica>> CreateBaixaMedicaAsync(BaixaMedicaCreateDTO baixaMedica);
        #endregion

        #region Relatorios
        Task<Result<int>> GetAllBaixasTotalCount();
        Task<Result<int>> GetAllBaixasSetorPrivadoTotalCount();
        Task<Result<int>> GetAllBaixasSetorPublicoTotalCount();
        Task<Result<int>> GetAllBaixasSetorPrivadoIdadeJovemCount();
        Task<Result<int>> GetAllBaixasSetorPublicoIdadeJovemCount();
        Task<Result<int>> GetAllBaixasSetorPrivadoIdadeJovemAdultoCount();
        Task<Result<int>> GetAllBaixasSetorPublicoIdadeJovemAdultoCount();
        Task<Result<int>> GetAllBaixasSetorPrivadoIdadeAdultoCount();
        Task<Result<int>> GetAllBaixasSetorPublicoIdadeAdultoCount();
        Task<ResultTypes<string, int>> GetAllBaixasSetorPrivadoEntidadePatronalCount();
        Task<ResultTypes<string, int>> GetAllBaixasSetorPublicoEntidadePatronalCount();
        Task<ResultTypes<string, int>> GetAllBaixasSetorPrivadoProfissaoCount();
        Task<ResultTypes<string, int>> GetAllBaixasSetorPublicoProfissaoCount();

        #endregion
    }
}
