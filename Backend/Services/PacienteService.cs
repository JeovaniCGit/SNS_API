using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.Utilities;
using SNS.Models;
using SNS.Interfaces;
using SNS.DTOs;

namespace SNS.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMedicoService _medicoService;


        public PacienteService (ApplicationDbContext context, IMedicoService medicoService)
        {
            _context = context;
            _medicoService = medicoService;
        }

        #region Read
        public async Task<List<GetPacienteDTO>> GetAllPacientes(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0) return new List<GetPacienteDTO>();
            var totalCount = await _context.Pacientes.CountAsync();
            if (totalCount == 0) return new List<GetPacienteDTO>();
            var pacientes = await _context.Pacientes
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.Utilizador)
                .Include(p => p.MedicoDoPaciente)
                .Include(p => p.MedicoDoPaciente!.Utilizador)
                .Select(p => new GetPacienteDTO
                {
                    Id = p.Id,
                    Profissao = p.Profissao,
                    EntidadePatronal = p.EntidadePatronal,
                    NumeroSns = p.NumeroSns,
                    UtilizadorDoPaciente = Mapper.MapperParaDTOResponseMedicoPaciente(p.Utilizador!),
                    MedicoDoPaciente = Mapper.MapperParaDTO(p.MedicoDoPaciente!)
                })
                .ToListAsync();
            return pacientes;
        }

        public async Task<Result<GetPacienteDTO>> GetPacienteById(int id)
        {
            var paciente = await _context.Pacientes.Include(p => p.Utilizador).Include(p => p.MedicoDoPaciente).Include(p => p.MedicoDoPaciente!.Utilizador).Select(p => new GetPacienteDTO
            {
                Id = p.Id,
                Profissao = p.Profissao,
                EntidadePatronal = p.EntidadePatronal,
                NumeroSns = p.NumeroSns,
                UtilizadorDoPaciente = Mapper.MapperParaDTOResponseMedicoPaciente(p.Utilizador!),
                MedicoDoPaciente = Mapper.MapperParaDTO(p.MedicoDoPaciente!),
            }).FirstOrDefaultAsync(p => p.Id == id);
            if (paciente != null)
            {
                return Result<GetPacienteDTO>.IsValid(paciente);
            }
            return Result<GetPacienteDTO>.NaoEncontrado();
        }
        #endregion

        #region Validation
        public async Task<Result<Paciente>> ValidatePacienteForRegistration(UtilizadorRegistrationDTO userDTO, CreatePacienteDTO pacienteDTO, Utilizador user)
        {
            var checkPacienteExists = await _context.Pacientes.FirstOrDefaultAsync(paciente => paciente.NumeroSns == userDTO.PacienteData!.NumeroSns);
            if (checkPacienteExists != null) return Result<Paciente>.ValorDuplicado();
            if (pacienteDTO.MedicoToAttributeId <= 0) return Result<Paciente>.ErroNoPedido();

            var check = await _medicoService.ValidateMedicoForUserRegistration(pacienteDTO);
            var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Id == pacienteDTO.MedicoToAttributeId);
            var newPaciente = new Paciente
            {
                Profissao = userDTO.PacienteData!.Profissao.FirstLetterToUpperCase(),
                EntidadePatronal = userDTO.PacienteData.EntidadePatronal.FirstLetterToUpperCase(),
                NumeroSns = userDTO.PacienteData.NumeroSns,
                MedicoDoPaciente = medico,
                Medicoid = medico!.Id,
                Utilizador = user
            };

            return Result<Paciente>.IsValid(newPaciente);
        }
        #endregion


    }
}
