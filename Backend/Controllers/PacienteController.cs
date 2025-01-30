using Microsoft.AspNetCore.Mvc;
using SNS.Data;
using SNS.DTOs;
using SNS.Interfaces;

namespace SNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPacienteService _pacienteService;

        public PacienteController(ApplicationDbContext context, IPacienteService pacienteService)
        {
            _context = context;
            _pacienteService = pacienteService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPacienteById(int id)
        {
            if (id <= 0) return BadRequest("Id inválido");
            var result = await _pacienteService.GetPacienteById(id);
            if (!result.IsSuccess) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllPacientes")]
        public async Task<IActionResult> GetAllPacientes(int pageNumber, int pageSize)
        {
            List<GetPacienteDTO> pacientes = await _pacienteService.GetAllPacientes(pageNumber, pageSize);
            if (pacientes.Count == 0) return NotFound(pacientes);
            if (pageSize <= 0 || pageSize <= 0) return BadRequest();
            return Ok(pacientes);
        }

    }
}
