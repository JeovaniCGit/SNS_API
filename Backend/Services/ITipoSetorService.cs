using SNS.Models;

namespace SNS.Services
{
    public interface ITipoSetorService
    {
        Task<List<TipoDeSetor>> GetAllTiposSetor();
    }
}
