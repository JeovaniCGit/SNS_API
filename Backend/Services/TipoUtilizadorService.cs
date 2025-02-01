using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.Interfaces;
using SNS.Models;

namespace SNS.Services
{
    public class TipoUtilizadorService : ITipoUtilizadorService
    {
        private readonly ApplicationDbContext _context;

        public TipoUtilizadorService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Read
        public async Task<List<TipoDeUtilizador>> GetAllTiposUtilizador()
        {
            List<TipoDeUtilizador> tiposDeUtilizador = await _context.TiposDeUtilizador.Select(t => new TipoDeUtilizador
            {
                Id = t.Id,
                Descri = t.Descri
            }).ToListAsync();
            if (tiposDeUtilizador.Count == 0) return new List<TipoDeUtilizador>();
            return tiposDeUtilizador;
        }
        #endregion
    }
}
