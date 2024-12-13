using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly ApplicationDbContext _context;

        public MedicoService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Result<Paciente>> GetPacienteByNumeroSNSAsync(int numeroSNS)
        {
            if (numeroSNS <= 0) return Result<Paciente>.ErroNoPedido();
            var pacienteBySNS = await _context.Pacientes.FirstOrDefaultAsync(paciente => paciente.NumeroSns == numeroSNS);
            if (pacienteBySNS == null) return Result<Paciente>.NaoEncontrado();
            return Result<Paciente>.IsValid(pacienteBySNS);
        }
    }
}
