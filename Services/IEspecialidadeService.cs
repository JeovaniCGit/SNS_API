using SNS.Models;

namespace SNS.Services
{
    public interface IEspecialidadeService
    {
        Task<List<Especialidade>> GetAllEspecialidades(int pageNumber, int pageSize);
    }
}
