using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.DTOs;
using SNS.Interfaces;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Services
{
    public class BaixaMedicaService : IBaixaMedicaService
    {
        private readonly ApplicationDbContext _context;
        public BaixaMedicaService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region BaixasMedicas

            #region Create
            public async Task<Result<BaixaMedica>> CreateBaixaMedicaAsync(BaixaMedicaCreateDTO baixaMedicaDTO)
            {
                var check = await _context.BaixasMedicas.FirstOrDefaultAsync(baixa => baixa.MedicoId == baixaMedicaDTO.MedicoId && baixa.PacienteId == baixaMedicaDTO.PacienteId && baixa.Diagnostico == baixaMedicaDTO.Diagnostico && baixa.PeriodoDeIncapacidade == baixaMedicaDTO.PeriodoDeIncapacidade);
                if (check != null) return Result<BaixaMedica>.ValorDuplicado();

                BaixaMedica baixaParaCriar = new BaixaMedica()
                {
                    MedicoId = baixaMedicaDTO.MedicoId,
                    PacienteId = baixaMedicaDTO.PacienteId,
                    Diagnostico = baixaMedicaDTO.Diagnostico,
                    PeriodoDeIncapacidade = baixaMedicaDTO.PeriodoDeIncapacidade,
                    Recomendacoes = baixaMedicaDTO.Recomendacoes,
                    tipoDeSetorId = baixaMedicaDTO.TipoDeSetorId,
                    tipoDeSetor = _context.TiposDeSetor.FirstOrDefault(tp => tp.Id == baixaMedicaDTO.TipoDeSetorId)!
                };
                await _context.AddAsync(baixaParaCriar);
                await _context.SaveChangesAsync();

                var fromMedico = await _context.Medicos.FirstOrDefaultAsync(medico => medico.Id == baixaParaCriar.MedicoId);
                var toPaciente = await _context.Pacientes.FirstOrDefaultAsync(paciente => paciente.Id == baixaParaCriar.PacienteId);
                if (fromMedico == null || toPaciente == null) return Result<BaixaMedica>.ErroNoPedido();
                fromMedico.BaixasMedicas.Add(baixaParaCriar);
                toPaciente.BaixasMedicas.Add(baixaParaCriar);
                return Result<BaixaMedica>.IsValid(baixaParaCriar);
            }
            #endregion

            #region Read
            public async Task<List<GetBaixaMedicaDTO>> GetAllBaixasAsync(int pageNumber, int pageSize)
            {
                if(pageNumber <= 0 || pageSize <= 0) return new List<GetBaixaMedicaDTO>();
                var totalCount = await _context.BaixasMedicas.CountAsync();
                if (totalCount == 0) return new List<GetBaixaMedicaDTO>();
                var baixas = await _context.BaixasMedicas
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(b => new GetBaixaMedicaDTO
                    {
                        Id = b.Id,
                        DataEmissao = b.DataEmissao,
                        Diagnostico = b.Diagnostico,
                        PeriodoDeIncapacidade = b.PeriodoDeIncapacidade,
                        Recomendacoes = b.Recomendacoes,
                        Medico = _context.Medicos.Include(m => m.Utilizador).Where(m => m.BaixasMedicas.Any(bm => bm.Id == b.Id)).Select(m => Mapper.MapperParaDTOParaBaixa(m)).FirstOrDefault(),
                        Paciente = _context.Pacientes.Include(p => p.Utilizador).Where(p => p.BaixasMedicas.Any(bm => bm.Id == b.Id)).Select(p => Mapper.MapperParaDTOParaBaixa(p)).FirstOrDefault(),
                        tipoDeSetorId = b.tipoDeSetorId
                    })
                    .ToListAsync();
                return baixas;
            }
            public async Task<List<GetBaixaMedicaDTO>> GetAllBaixasByPacienteAsync(int pacienteId)
            {
                return await _context.BaixasMedicas.Where(baixa => baixa.PacienteId == pacienteId).Select(b => new GetBaixaMedicaDTO
                {
                    Id = b.Id,
                    DataEmissao = b.DataEmissao,
                    Diagnostico = b.Diagnostico,
                    PeriodoDeIncapacidade = b.PeriodoDeIncapacidade,
                    Recomendacoes = b.Recomendacoes,
                    Medico = _context.Medicos.Include(m => m.Utilizador).Where(m => m.BaixasMedicas.Any(bm => bm.Id == b.Id)).Select(m => Mapper.MapperParaDTOParaBaixa(m)).FirstOrDefault(),
                    Paciente = _context.Pacientes.Include(p => p.Utilizador).Where(p => p.BaixasMedicas.Any(bm => bm.Id == b.Id)).Select(p => Mapper.MapperParaDTOParaBaixa(p)).FirstOrDefault(),
                    tipoDeSetorId = b.tipoDeSetorId
                }).ToListAsync();
            }
            public async Task<List<GetBaixaMedicaDTO>> GetAllBaixasBySetorIdAsync(int tipoSetorId, int pageNumber, int pageSize)
            {
                if (tipoSetorId <= 0 || pageNumber <= 0 || pageSize <= 0)
                    return new List<GetBaixaMedicaDTO>();

                return await _context.BaixasMedicas
                    .Where(b => b.tipoDeSetorId == tipoSetorId)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(b => new GetBaixaMedicaDTO
                    {
                        Id = b.Id,
                        DataEmissao = b.DataEmissao,
                        Diagnostico = b.Diagnostico,
                        PeriodoDeIncapacidade = b.PeriodoDeIncapacidade,
                        Recomendacoes = b.Recomendacoes,
                        Medico = _context.Medicos.Include(m => m.Utilizador).Where(m => m.BaixasMedicas.Any(bm => bm.Id == b.Id)).Select(m => Mapper.MapperParaDTOParaBaixa(m)).FirstOrDefault(),
                        Paciente = _context.Pacientes.Include(p => p.Utilizador).Where(p => p.BaixasMedicas.Any(bm => bm.Id == b.Id)).Select(p => Mapper.MapperParaDTOParaBaixa(p)).FirstOrDefault(),
                        tipoDeSetorId = b.tipoDeSetorId
                    })
                    .ToListAsync();
            }
            public async Task<Result<GetBaixaMedicaDTO?>> GetBaixaMedicaByIdAsync(int id)
            {
                var baixa = await _context.BaixasMedicas.Where(b => b.Id == id).Select(b => new GetBaixaMedicaDTO
                {
                    Id = b.Id,
                    DataEmissao = b.DataEmissao,
                    Diagnostico = b.Diagnostico,
                    PeriodoDeIncapacidade = b.PeriodoDeIncapacidade,
                    Recomendacoes = b.Recomendacoes,
                    Medico = _context.Medicos.Include(m => m.Utilizador).Where(m => m.BaixasMedicas.Any(bm => bm.Id == b.Id)).Select(m => Mapper.MapperParaDTOParaBaixa(m)).FirstOrDefault(),
                    Paciente = _context.Pacientes.Include(p => p.Utilizador).Where(p => p.BaixasMedicas.Any(bm => bm.Id == b.Id)).Select(p => Mapper.MapperParaDTOParaBaixa(p)).FirstOrDefault(),
                    tipoDeSetorId = b.tipoDeSetorId
                }).FirstOrDefaultAsync();
                if (baixa == null)
                {
                    return Result<GetBaixaMedicaDTO?>.NaoEncontrado();
                }
                return Result<GetBaixaMedicaDTO?>.IsValid(baixa);
            }
            #endregion

            #region Update
            public async Task<Result<BaixaMedica?>> UpdateBaixaMedicaAsync(int id, BaixaMedicaUpdateDTO baixaAtualizada)
            {
                var baixaParaAtualizar = await _context.BaixasMedicas
                    .FirstOrDefaultAsync(baixa => baixa.Id == id);
                if (baixaParaAtualizar == null) return Result<BaixaMedica?>.NaoEncontrado();
                baixaParaAtualizar.DataAtualizacao = DateTime.Now;
                baixaParaAtualizar.Diagnostico = baixaAtualizada.Diagnostico;
                baixaParaAtualizar.PeriodoDeIncapacidade = baixaAtualizada.PeriodoDeIncapacidade;
                baixaParaAtualizar.Recomendacoes = baixaAtualizada?.Recomendacoes;

                await _context.SaveChangesAsync();
                return Result<BaixaMedica?>.IsUpdated(baixaParaAtualizar);
            }
            #endregion

            #region Delete
            public async Task<Result<bool>> DeleteBaixaMedicaAsync(int baixaMedicaId)
            {
                var baixaToDelete = await _context.BaixasMedicas.FindAsync(baixaMedicaId);
                if (baixaToDelete == null)
                {
                    return Result<bool>.NaoApagado();
                }
                _context.BaixasMedicas.Remove(baixaToDelete);
                await _context.SaveChangesAsync();
                return Result<bool>.IsDeleted();
            }
            #endregion

        #endregion

        #region Relatorios
        public async Task<Result<int>> GetAllBaixasTotalCount()
        {
            var count = await _context.BaixasMedicas.CountAsync();
            if (count == 0) return Result<int>.NaoEncontrado();
            return Result<int>.IsValid(count);
        }

        public async Task<Result<int>> GetAllBaixasSetorPrivadoTotalCount()
        {
            var count = await _context.BaixasMedicas.Where(b => b.tipoDeSetorId == 2).CountAsync();
            if (count == 0) return Result<int>.NaoEncontrado();
            return Result<int>.IsValid(count);
        }

        public async Task<Result<int>> GetAllBaixasSetorPublicoTotalCount()
        {
            var count = await _context.BaixasMedicas.Where(b => b.tipoDeSetorId == 1).CountAsync();
            if (count == 0) return Result<int>.NaoEncontrado();
            return Result<int>.IsValid(count);
        }

        public async Task<Result<int>> GetAllBaixasSetorPrivadoIdadeJovemCount()
        {
            var count = await _context.Pacientes.Include(p => p.Utilizador).Where(p => EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) < 25 && p.BaixasMedicas.Any(b => b.tipoDeSetorId == 2)).CountAsync();
            if (count == 0) return Result<int>.NaoEncontrado();
            return Result<int>.IsValid(count);
        }

        public async Task<Result<int>> GetAllBaixasSetorPublicoIdadeJovemCount()
        {
            var count = await _context.Pacientes.Include(p => p.Utilizador).Where(p => EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) < 25 && p.BaixasMedicas.Any(b => b.tipoDeSetorId == 1)).CountAsync();
            if (count == 0) return Result<int>.NaoEncontrado();
            return Result<int>.IsValid(count);
        }

        public async Task<Result<int>> GetAllBaixasSetorPrivadoIdadeJovemAdultoCount()
        {
            var count = await _context.Pacientes.Include(p => p.Utilizador).Where(p => EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) > 25 && EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) < 35 && p.BaixasMedicas.Any(b => b.tipoDeSetorId == 2)).CountAsync();
            if (count == 0) return Result<int>.NaoEncontrado();
            return Result<int>.IsValid(count);
        }

        public async Task<Result<int>> GetAllBaixasSetorPublicoIdadeJovemAdultoCount()
        {
            var count = await _context.Pacientes.Include(p => p.Utilizador).Where(p => EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) > 25 && EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) < 35 && p.BaixasMedicas.Any(b => b.tipoDeSetorId == 1)).CountAsync();
            if (count == 0) return Result<int>.NaoEncontrado();
            return Result<int>.IsValid(count);
        }

        public async Task<Result<int>> GetAllBaixasSetorPrivadoIdadeAdultoCount()
        {
            var count = await _context.Pacientes.Include(p => p.Utilizador).Where(p => EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) > 35 && EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) < 65 && p.BaixasMedicas.Any(b => b.tipoDeSetorId == 2)).CountAsync();
            if (count == 0) return Result<int>.NaoEncontrado();
            return Result<int>.IsValid(count);
        }

        public async Task<Result<int>> GetAllBaixasSetorPublicoIdadeAdultoCount()
        {
            var count = await _context.Pacientes.Include(p => p.Utilizador).Where(p => EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) > 35 && EF.Functions.DateDiffYear(p.Utilizador!.DataNascimento, DateTime.UtcNow) < 65 && p.BaixasMedicas.Any(b => b.tipoDeSetorId == 1)).CountAsync();
            if (count == 0) return Result<int>.NaoEncontrado();
            return Result<int>.IsValid(count);
        }

        public async Task<ResultTypes<string, int>> GetAllBaixasSetorPrivadoEntidadePatronalCount()
        {
            var result = await _context.Pacientes.SelectMany(p => p.BaixasMedicas.Where(b => b.tipoDeSetorId == 2).Select(b => new { p.EntidadePatronal, BaixaId = b.Id })) .GroupBy(x => x.EntidadePatronal) .Select(g => new { Entidade = g.Key, Count = g.Count() }) .OrderByDescending(g => g.Count) .FirstOrDefaultAsync();

            if (result == null) return ResultTypes<string, int>.NotValid();
            return ResultTypes<string, int>.IsValid(result!.Entidade!, result.Count);
        }

        public async Task<ResultTypes<string, int>> GetAllBaixasSetorPublicoEntidadePatronalCount()
        {
            var result = await _context.Pacientes.SelectMany(p => p.BaixasMedicas.Where(b => b.tipoDeSetorId == 1).Select(b => new { p.EntidadePatronal, BaixaId = b.Id })).GroupBy(x => x.EntidadePatronal).Select(g => new { Entidade = g.Key, Count = g.Count() }).OrderByDescending(g => g.Count).FirstOrDefaultAsync();

            if (result == null) return ResultTypes<string, int>.NotValid();
            return ResultTypes<string, int>.IsValid(result!.Entidade!, result.Count);
        }

        public async Task<ResultTypes<string, int>> GetAllBaixasSetorPrivadoProfissaoCount()
        {
            var result = await _context.Pacientes.SelectMany(p => p.BaixasMedicas.Where(b => b.tipoDeSetorId == 2).Select(b => new { p.Profissao, BaixaId = b.Id })).GroupBy(x => x.Profissao).Select(g => new { Profissao = g.Key, Count = g.Count() }).OrderByDescending(g => g.Count).FirstOrDefaultAsync();

            if (result == null) return ResultTypes<string, int>.NotValid();
            return ResultTypes<string, int>.IsValid(result!.Profissao!, result.Count);
        }

        public async Task<ResultTypes<string, int>> GetAllBaixasSetorPublicoProfissaoCount()
        {
            var result = await _context.Pacientes.SelectMany(p => p.BaixasMedicas.Where(b => b.tipoDeSetorId == 1).Select(b => new { p.Profissao, BaixaId = b.Id })).GroupBy(x => x.Profissao).Select(g => new { Profissao = g.Key, Count = g.Count() }).OrderByDescending(g => g.Count).FirstOrDefaultAsync();

            if (result == null) return ResultTypes<string, int>.NotValid();
            return ResultTypes<string, int>.IsValid(result!.Profissao!, result.Count);
        }
        #endregion
    }
}
