using Microsoft.AspNetCore.Mvc;
using SNS.Data;
using SNS.Interfaces;
using SNS.Models;

namespace SNS.Controllers
{
    public class EspecialidadeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEspecialidadeService _especialidadeService;
        public EspecialidadeController(ApplicationDbContext context, IEspecialidadeService especialidadeService)
        {
            _context = context;
            _especialidadeService = especialidadeService;
        }

        #region Read
        [HttpGet("GetAllEspecialidades")]
        public async Task<IActionResult> GetAllEspecialidades(int pageNumber, int pageSize)
        {
            List<Especialidade> especialidades = await _especialidadeService.GetAllEspecialidades(pageNumber, pageSize);
            if(especialidades.Count == 0) return NotFound(especialidades);
            if(pageNumber <= 0 || pageSize <= 0) return BadRequest();
            return Ok(especialidades);
        }
        #endregion
    }
}
