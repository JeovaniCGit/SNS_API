using SNS.Models;

namespace SNS.Interfaces
{
    public interface ITipoUtilizadorService
    {
        Task<List<TipoDeUtilizador>> GetAllTiposUtilizador();
    }
}
