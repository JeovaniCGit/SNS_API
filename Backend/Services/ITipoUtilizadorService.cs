using SNS.Models;

namespace SNS.Services
{
    public interface ITipoUtilizadorService
    {
        Task<List<TipoDeUtilizador>> GetAllTiposUtilizador();
    }
}
