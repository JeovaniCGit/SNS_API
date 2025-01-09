using Microsoft.EntityFrameworkCore;
using SNS.Data;
using SNS.DTOs;
using SNS.Models;

namespace SNS.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly ApplicationDbContext _context;
        public EspecialidadeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Especialidade>> GetAllEspecialidades(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0) return new List<Especialidade>();
            var totalCount = await _context.Especialidades.CountAsync();
            if (totalCount == 0) return new List<Especialidade>();
            var especialidades = await _context.Especialidades
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new Especialidade
                {
                    Id = e.Id,
                    Descri = e.Descri
                })
                .ToListAsync();
            return especialidades;
        }
    }
}
