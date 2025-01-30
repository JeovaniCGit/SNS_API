using SNS.Models;

namespace SNS.Interfaces
{
    public interface ITipoSetorService
    {
        Task<List<TipoDeSetor>> GetAllTiposSetor();
    }
}
