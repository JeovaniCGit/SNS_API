using Microsoft.AspNetCore.Mvc;
using SNS.Data;
using SNS.Interfaces;
using SNS.Models;

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

        #region Read
        [HttpGet("GetAllTiposSetor")]
        public async Task<IActionResult> GetAllTiposSetor()
        {
            List<TipoDeSetor> tipos = await _tipoSetorService.GetAllTiposSetor();
            if(tipos.Count == 0) return NotFound(tipos);
            return Ok(tipos);
        }
        #endregion
    }
}
