using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.DTOs;
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

        public async Task<Result<BaixaMedica>> CreateBaixaMedicaAsync(BaixaMedicaCreateDTO baixaMedica)
        {
            var check = await _context.BaixasMedicas.FirstOrDefaultAsync(baixa => baixa.MedicoId == baixaMedica.MedicoId
                                                                                  && baixa.PacienteId == baixaMedica.PacienteId
                                                                                  && baixa.Diagnostico == baixaMedica.Diagnostico
                                                                                  && baixa.PeriodoDeIncapacidade == baixaMedica.PeriodoDeIncapacidade);
            if (check != null) return Result<BaixaMedica>.ValorDuplicado();

            BaixaMedica baixaParaCriar = new BaixaMedica()
            {
                MedicoId = baixaMedica.MedicoId,
                PacienteId = baixaMedica.PacienteId,
                Diagnostico = baixaMedica.Diagnostico,
                PeriodoDeIncapacidade = baixaMedica.PeriodoDeIncapacidade,
                Recomendacoes = baixaMedica.Recomendacoes,
                tipoDeSetorId = baixaMedica.TipoDeSetorId,
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
        public async Task<List<BaixaMedica>> GetAllBaixasAsync(int pageNumber, int pageSize)
        {
            if(pageNumber <= 0 || pageSize <= 0) return new List<BaixaMedica>();
            var totalCount = await _context.BaixasMedicas.CountAsync();
            if (totalCount == 0) return new List<BaixaMedica>();
            var baixas = await _context.BaixasMedicas
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return baixas;
        }
        public async Task<List<BaixaMedica>> GetAllBaixasByPacienteAsync(int pacienteId)
        {
            return await _context.BaixasMedicas.Where(baixa => baixa.PacienteId == pacienteId).ToListAsync();
        }
        public async Task<List<BaixaMedica>> GetAllBaixasBySetorAsync(string tipoSetor)
        {
            return await _context.BaixasMedicas.Where(baixaMedica => baixaMedica.tipoDeSetor.Descri == tipoSetor).ToListAsync();
        }
        public async Task<Result<BaixaMedica?>> UpdateBaixaMedicaAsync(int id, BaixaMedicaUpdateDTO baixaAtualizada)
        {
            var baixaParaAtualizar = await _context.BaixasMedicas
                .Include(e => e.Medico)
                .Include(f => f.Paciente)
                .FirstOrDefaultAsync(baixa => baixa.Id == id);
            if (baixaParaAtualizar == null) return Result<BaixaMedica?>.NaoEncontrado();
            baixaParaAtualizar.DataAtualizacao = DateTime.Now;
            baixaParaAtualizar.Diagnostico = baixaAtualizada.Diagnostico;
            baixaParaAtualizar.PeriodoDeIncapacidade = baixaAtualizada.PeriodoDeIncapacidade;
            baixaParaAtualizar.Recomendacoes = baixaAtualizada?.Recomendacoes;

            await _context.SaveChangesAsync();
            return Result<BaixaMedica?>.IsUpdated(baixaParaAtualizar);
        }
        public async Task<Result<BaixaMedica?>> GetBaixaMedicaByIdAsync(int id)
        {
            var baixa = await _context.BaixasMedicas.FirstOrDefaultAsync(baixa => baixa.Id == id);
            if(baixa == null)
            {
                return Result<BaixaMedica?>.NaoEncontrado();
            }
            return Result<BaixaMedica?>.IsValid(baixa);
        }
    }
}
