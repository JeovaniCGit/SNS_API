using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.DTOs;
using SNS.Utilities;
using SNS.Models;

namespace SNS.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly ApplicationDbContext _context;

        public PacienteService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Result<Paciente>> ValidatePacienteForRegistration(UtilizadorRegistrationDTO userDTO)
        {
            var checkPacienteExists = await _context.Pacientes.FirstOrDefaultAsync(paciente => paciente.NumeroSns == userDTO.PacienteData!.NumeroSns);
            if (checkPacienteExists != null) return Result<Paciente>.ValorDuplicado();
            var newPaciente = new Paciente
            {
                Profissao = userDTO.PacienteData!.Profissao,
                EntidadePatronal = userDTO.PacienteData.EntidadePatronal,
                NumeroSns = userDTO.PacienteData.NumeroSns
            };
            return Result<Paciente>.IsValid(newPaciente);
        }
    }
}
