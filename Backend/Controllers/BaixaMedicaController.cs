using Microsoft.AspNetCore.Mvc;
using SNS.Services;
using SNS.Models;
using SNS.Utilities;
using SNS.Data;
using SNS.DTOs;

namespace SNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaixaMedicaController : ControllerBase
    {
        private readonly IBaixaMedicaService _baixaMedicaService;
        private readonly ApplicationDbContext _context;

        public BaixaMedicaController(IBaixaMedicaService baixaMedicaService, ApplicationDbContext context)
        {
            _baixaMedicaService = baixaMedicaService;
            _context = context;
        }

        [HttpPost("CreateBaixaMedica")]
        public async Task<IActionResult> CreateBaixaMedica([FromBody] BaixaMedicaCreateDTO baixa)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _baixaMedicaService.CreateBaixaMedicaAsync(baixa);
            if(result.IsSuccess == false) return BadRequest(result.Message);
            return CreatedAtAction(nameof(GetBaixaMedicaById), new {id = result.Data!.Id}, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBaixaMedicaById(int id)
        {
            var result = await _baixaMedicaService.GetBaixaMedicaByIdAsync(id);
            if (result.IsSuccess == false) return NotFound(result.Message);
            if (id <= 0) return BadRequest();
            return Ok(result);
        }

        [HttpGet("GetAllBaixas")]
        public async Task<IActionResult> GetAllBaixas(int pageNumber, int pageSize)
        {
            List<BaixaMedica> baixas = await _baixaMedicaService.GetAllBaixasAsync(pageNumber, pageSize);
            if (baixas.Count == 0) return NotFound();
            if (pageNumber <= 0 || pageSize <= 0) return BadRequest();
            return Ok(baixas);
        }

        [HttpGet("GetAllBaixasPaciente")]
        public async Task<IActionResult> GetAllBaixasByPaciente(int pacienteId)
        {
            List<BaixaMedica> baixasByPaciente = await _baixaMedicaService.GetAllBaixasByPacienteAsync(pacienteId);
            if (baixasByPaciente.Count == 0) return NotFound();
            if (pacienteId <= 0) return BadRequest();
            return Ok(baixasByPaciente);
        }

        [HttpGet("GetAllBaixasSetor")]
        public async Task<IActionResult> GetAllBaixasBySetor(string tipoSetor)
        {
            List<BaixaMedica> baixasPorSetor = await _baixaMedicaService.GetAllBaixasBySetorAsync(tipoSetor);
            if(baixasPorSetor.Count == 0) return NotFound();
            if(tipoSetor == string.Empty) return BadRequest();
            return Ok(baixasPorSetor);
        }

        [HttpPut("UpdateBaixa/{id}")]
        public async Task<IActionResult> UpdateBaixaMedicaAsync([FromRoute] int id, [FromBody] BaixaMedicaUpdateDTO baixaAtualizada)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id <= 0) return BadRequest("Id inválido.");
            var result = await _baixaMedicaService.UpdateBaixaMedicaAsync(id, baixaAtualizada);
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpDelete("DeleteBaixa/{baixaMedicaId}")]
        public async Task<IActionResult> DeleteBaixaMedicaAsync([FromRoute] int baixaMedicaId)
        {
            if (baixaMedicaId <= 0) return BadRequest("Id inváido.");
            var result = await _baixaMedicaService.DeleteBaixaMedicaAsync(baixaMedicaId);
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }
    }
}
