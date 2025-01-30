using SNS.Models;

namespace SNS.Interfaces
{
    public interface IEspecialidadeService
    {
        Task<List<Especialidade>> GetAllEspecialidades(int pageNumber, int pageSize);
    }
}
