using SNS.Models;
using SNS.Utilities;

namespace SNS.Services
{
    public interface IMedicoService
    {
        Task<Result<Paciente>> GetPacienteByNumeroSNSAsync(int numeroSNS);
    }
}