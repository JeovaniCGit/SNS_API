using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.DTOs;
using SNS.Interfaces;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Services
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly ApplicationDbContext _context;

        public InstituicaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Create
        public async Task<Result<InstituicaoDTO>> CreateInstituicao (InstituicaoDTO institutoDTO)
        {
            var checkInsti = await _context.Instituicoes.FirstOrDefaultAsync(instituto => instituto.Descri == institutoDTO.Descri
            && instituto.TipoDeSetorid == institutoDTO.TipoSetorId);

            if (checkInsti != null) return Result<InstituicaoDTO>.ValorDuplicado();
            var tipoSetor = await _context.TiposDeSetor.FirstOrDefaultAsync(tipo => tipo.Id == institutoDTO.TipoSetorId);

            var insti = new Instituição
            {
                Descri = institutoDTO.Descri,
                TipoDeSetorid = institutoDTO.TipoSetorId,
                TipoDeSetor = tipoSetor!
            };

            await _context.Instituicoes.AddAsync(insti);
            await _context.SaveChangesAsync();
            return Result<InstituicaoDTO>.IsValid(Mapper.MapperParaDTO(insti));
        }
        #endregion

        #region Read
        public async Task<List<InstituicaoDTO>> GetAllInstituicoes()
        {
            List<InstituicaoDTO> institutos = await _context.Instituicoes.Select(i => new InstituicaoDTO
            {
                Id = i.Id,
                Descri = i.Descri!,
                TipoDeSetor = i.TipoDeSetor
            }).ToListAsync();

            if(institutos.Count == 0) return new List<InstituicaoDTO>();
            return institutos;
        }
        public async Task<Result<InstituicaoDTO>> GetInstituicaoById(int id)
        {
            if (id <= 0) return Result<InstituicaoDTO>.ErroNoPedido();
            var insti = await _context.Instituicoes.Where(i => i.Id == id)
                .Select(i => new InstituicaoDTO
                {
                    Id = i.Id,
                    Descri = i.Descri!,
                    TipoDeSetor= i.TipoDeSetor
                }).FirstOrDefaultAsync();
            if(insti == null) return Result<InstituicaoDTO>.NaoEncontrado();
            return Result<InstituicaoDTO>.IsValid(insti);
        }
        #endregion
    }
}

