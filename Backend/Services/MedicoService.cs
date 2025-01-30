using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.DTOs;
using SNS.Interfaces;
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
        public async Task<Result<Medico>> ValidateMedicoForUserRegistration(CreatePacienteDTO pacienteDTO)
        {
            var checkMedicoExists = await _context.Medicos.FirstOrDefaultAsync(medico => medico.Id == pacienteDTO.MedicoToAttributeId);
            if (checkMedicoExists == null) return Result<Medico>.NaoEncontrado("Medico não encontrado.");
            return Result<Medico>.IsValid(checkMedicoExists);
        }
        public async Task<Result<Medico>> ValidateMedicoForMedicoRegistration (CreateMedicoWithIdDTO userDTO)
        {
            var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.NMedico == userDTO.NMedico);
            if (medico == null) return Result<Medico>.IsValid();
            return Result<Medico>.ValorDuplicado();
        }
        public async Task<Result<Medico>> AddMedico(CreateMedicoWithIdDTO addMedico)
        {
            var user = await _context.Utilizadores.FirstOrDefaultAsync(user => user.Id == addMedico.MedicoUtilizadorId);
            if(user == null) return Result<Medico>.NaoEncontrado("Utilizador não encontrado");

            var checkMedicoInDB = ValidateMedicoForMedicoRegistration(addMedico);
            if (checkMedicoInDB.Result.IsSuccess == false) return Result<Medico>.ValorDuplicado();

            var especialidade = await _context.Especialidades.FirstOrDefaultAsync(esp => esp.Id == addMedico.EspecialidadeId);
            
            Medico newMedico = new Medico()
            {
              NMedico = addMedico.NMedico,
              Especialidadeid = addMedico.EspecialidadeId,
              Utilizadorid = addMedico.MedicoUtilizadorId,
              Especialidade = especialidade!,
              Utilizador = user
            };

            if (addMedico.HistoricoLaboral != null)
            {
                var insti = await _context.Instituicoes.FirstOrDefaultAsync(i => i.Id == addMedico.HistoricoLaboral.Instituiçãoid);
                var historicoToAdd = Mapper.MapperParaEntity(addMedico.HistoricoLaboral);
                historicoToAdd.Instituição = insti!;
                newMedico.HistoricoLaborals.Add(historicoToAdd);
            }
            await _context.Medicos.AddAsync(newMedico);
            await _context.SaveChangesAsync();
            return Result<Medico>.IsValid(newMedico);
        }
        public async Task<Result<GetMedicoDataDTO>> GetMedicoById(int id)
        {
            var medico = await _context.Medicos.Where(m => m.Id == id)
                .Include(m => m.Especialidade)
                .Include(m => m.HistoricoLaborals)
                .Include(m => m.Utilizador)
                .FirstOrDefaultAsync();
            if (medico == null) return Result<GetMedicoDataDTO>.NaoEncontrado("Medico não encontrado");
            var medicoDTO = new GetMedicoDataDTO
            {
                Id = medico.Id,
                EspecialidadeId = medico.Especialidadeid,
                AllHistoricoLaboral = medico.HistoricoLaborals,
                UtilizadorDoMedico = Mapper.MapperParaDTOResponseMedicoPaciente(medico.Utilizador!)
            };
            return Result<GetMedicoDataDTO>.IsValid(medicoDTO);
        }
        public async Task<Result<HistoricoLaboralDTO>> UpdateHistoricoLaboral(int medicoId, HistoricoLaboralDTO historicoDTO)
        {
            var medico = await _context.Medicos.FirstOrDefaultAsync(medico => medico.Id == medicoId);
            if (medico == null) return Result<HistoricoLaboralDTO>.NaoEncontrado("Medico não encontrado");

            var historicoToAdd = Mapper.MapperParaEntity(historicoDTO);
            if (medico.HistoricoLaborals.Contains(historicoToAdd)) return Result<HistoricoLaboralDTO>.ValorDuplicado();
            if (historicoToAdd == null) return Result<HistoricoLaboralDTO>.ErroNoPedido();

            medico.HistoricoLaborals.Add(historicoToAdd);
            await _context.SaveChangesAsync();
            return Result<HistoricoLaboralDTO>.IsUpdated(Mapper.MapperParaDTO(historicoToAdd));
        }
        public async Task<List<GetMedicoDataDTO>> GetAllMedicos(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0) return new List<GetMedicoDataDTO>();
            var totalCount = await _context.Medicos.CountAsync();
            if (totalCount == 0) return new List<GetMedicoDataDTO>();
            var medicos = await _context.Medicos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new GetMedicoDataDTO
                {
                    Id = m.Id,
                    EspecialidadeId = m.Especialidadeid,
                    UtilizadorDoMedico = Mapper.MapperParaDTOResponseMedicoPaciente(m.Utilizador!),
                    AllHistoricoLaboral = m.HistoricoLaborals.Select(h => new HistoricoLaboral
                    {
                        DataInicio = h.DataInicio,
                        DataFim = h.DataFim,
                        Instituição = h.Instituição
                    }).ToList()
                })
                .ToListAsync();
            return medicos!;
        }
    }
}
