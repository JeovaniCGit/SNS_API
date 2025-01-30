using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.Interfaces;
using SNS.Models;

namespace SNS.Services
{
    public class TipoSetorService : ITipoSetorService
    {
        private readonly ApplicationDbContext _context;

        public TipoSetorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoDeSetor>> GetAllTiposSetor()
        {
            List<TipoDeSetor> tiposSetor = await _context.TiposDeSetor.Select(x => new TipoDeSetor
            {
                Id = x.Id,
                Descri = x.Descri
            }).ToListAsync();
            if(tiposSetor.Count == 0) return new List<TipoDeSetor>();
            return tiposSetor;
        }
    }
}
