using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.DTOs;
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
        public async Task<Result<Medico>> ValidateMedicoForUserRegistration(UtilizadorRegistrationDTO userDTO)
        {
            var checkMedicoExists = await _context.Medicos.FirstOrDefaultAsync(medico => medico.Id == userDTO.MedicoToAttributeId);
            if (checkMedicoExists == null) return Result<Medico>.NaoEncontrado("Medico não encontrado.");

            return Result<Medico>.IsValid(checkMedicoExists);
        }
        public async Task<Result<Medico>> ValidateMedicoForMedicoRegistration (AddAndGetMedicoDataDTO userDTO)
        {
            var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.NMedico == userDTO.NMedico);
            if (medico == null) return Result<Medico>.IsValid();
            return Result<Medico>.ValorDuplicado();
        }
        public async Task<Result<Medico>> AddMedico(CreateMedicoWithIdDTO addMedico)
        {
            var user = await _context.Utilizadores.FirstOrDefaultAsync(user => user.Id == addMedico.MedicoUtilizadorId);
            if(user == null) return Result<Medico>.NaoEncontrado("Utilizador não encontrado");

            var medicoDTO = addMedico.MedicoDTO;
            var checkMedicoInDB = ValidateMedicoForMedicoRegistration(medicoDTO);
            if (checkMedicoInDB.Result.IsSuccess == false) return Result<Medico>.ValorDuplicado();

            var especialidade = await _context.Especialidades.FirstOrDefaultAsync(esp => esp.Id == medicoDTO.EspecialidadeId);
            
            Medico newMedico = new Medico()
            {
              NMedico = medicoDTO.NMedico,
              Especialidadeid = medicoDTO.EspecialidadeId,
              Utilizadorid = addMedico.MedicoUtilizadorId,
              Especialidade = especialidade!
            };

            if (medicoDTO.HistoricoLaboral != null)
            {
                var insti = await _context.Instituicoes.FirstOrDefaultAsync(i => i.Id == medicoDTO.HistoricoLaboral.Instituiçãoid);
                var historicoToAdd = Mapper.MapperParaEntity(medicoDTO.HistoricoLaboral);
                historicoToAdd.Instituição = insti!;
                newMedico.HistoricoLaborals.Add(historicoToAdd);
            }
            await _context.Medicos.AddAsync(newMedico);
            await _context.SaveChangesAsync();
            return Result<Medico>.IsValid(newMedico);
        }
        public async Task<Result<AddAndGetMedicoDataDTO>> GetMedicoById(int id)
        {
            var medico = await _context.Medicos.Where(m => m.Id == id)
                .Include(e => e.Especialidade)
                .Include(h => h.HistoricoLaborals)
                .FirstOrDefaultAsync();
            var medicoUser = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Id == medico.Utilizadorid);
            if (medico == null) return Result<AddAndGetMedicoDataDTO>.NaoEncontrado("Medico não encontrado");
            var medicoDTO = new AddAndGetMedicoDataDTO
            {
                MedicoName = medicoUser!.Nome,
                Id = medico.Id,
                NMedico = medico.NMedico,
                Especialidade = medico.Especialidade,
                AllHistoricoLaboral = medico.HistoricoLaborals
            };
            return Result<AddAndGetMedicoDataDTO>.IsValid(medicoDTO);
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
        public async Task<List<AddAndGetMedicoDataDTO>> GetAllMedicos(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0) return new List<AddAndGetMedicoDataDTO>();
            var totalCount = await _context.Medicos.CountAsync();
            if (totalCount == 0) return new List<AddAndGetMedicoDataDTO>();
            var medicos = await _context.Medicos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new AddAndGetMedicoDataDTO
                {
                    MedicoName = _context.Utilizadores.Where(u => u.Id == m.Utilizadorid)
                        .Select(u => u.Nome)
                            .FirstOrDefault()!,
                    Id = m.Id,
                    NMedico = m.NMedico,
                    Especialidade = m.Especialidade,
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
