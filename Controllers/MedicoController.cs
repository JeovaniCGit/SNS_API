using Microsoft.AspNetCore.Mvc;
using SNS.Data;
using SNS.Models;
using SNS.Services;

namespace SNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMedicoService _medicoService;

        public MedicoController(ApplicationDbContext context, IMedicoService medicoService)
        {
            _context = context;
            _medicoService = medicoService;
        }

        [HttpGet("GetPacientesByNumeroSNS")]
        public async Task<IActionResult> GetPacienteByNumeroSNSAsync(int numeroSNS)
        {
            if (numeroSNS <= 0) return BadRequest("Número SNS inválido");
            var result = await _medicoService.GetPacienteByNumeroSNSAsync(numeroSNS);
            if (result.IsSuccess == false) return NotFound(result?.Message);
            return Ok(result);
        }
    }
}
