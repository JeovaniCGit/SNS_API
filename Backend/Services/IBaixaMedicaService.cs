using SNS.DTOs;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Services
{
    public interface IBaixaMedicaService
    {
        Task<List<BaixaMedica>> GetAllBaixasAsync(int pageNumber, int pageSize);
        Task<List<BaixaMedica>> GetAllBaixasBySetorAsync(string tipoSetor);
        Task<List<BaixaMedica>> GetAllBaixasByPacienteAsync(int pacienteId);
        Task<Result<BaixaMedica?>> GetBaixaMedicaByIdAsync(int id);
        Task<Result<BaixaMedica?>> UpdateBaixaMedicaAsync(int id, BaixaMedicaUpdateDTO baixaAtualizada);
        Task<Result<bool>> DeleteBaixaMedicaAsync(int baixaMedicaId);
        Task<Result<BaixaMedica>> CreateBaixaMedicaAsync(BaixaMedicaCreateDTO baixaMedica);
    }
}
