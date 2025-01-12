using Microsoft.AspNetCore.Mvc;
using SNS.Data;
using SNS.Models;
using SNS.Services;

namespace SNS.Controllers
{
    public class TipoSetorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITipoSetorService _tipoSetorService;

        public TipoSetorController (ApplicationDbContext context, ITipoSetorService tipoSetorService)
        {
            _context = context;
            _tipoSetorService = tipoSetorService;
        }
        [HttpGet("GetAllTiposSetor")]
        public async Task<IActionResult> GetAllTiposSetor()
        {
            List<TipoDeSetor> tipos = await _tipoSetorService.GetAllTiposSetor();
            if(tipos.Count == 0) return NotFound(tipos);
            return Ok(tipos);
        }

        
    }
}
