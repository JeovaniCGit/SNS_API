using Microsoft.AspNetCore.Mvc;
using SNS.Models;
using SNS.Utilities;
using SNS.Data;
using SNS.Interfaces;
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


        #region BaixasMedicas
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
            List<GetBaixaMedicaDTO> baixas = await _baixaMedicaService.GetAllBaixasAsync(pageNumber, pageSize);
            if (baixas.Count == 0) return NotFound();
            if (pageNumber <= 0 || pageSize <= 0) return BadRequest();
            return Ok(baixas);
        }

        [HttpGet("GetAllBaixasPaciente")]
        public async Task<IActionResult> GetAllBaixasByPaciente(int pacienteId)
        {
            List<GetBaixaMedicaDTO> baixasByPaciente = await _baixaMedicaService.GetAllBaixasByPacienteAsync(pacienteId);
            if (baixasByPaciente.Count == 0) return NotFound();
            if (pacienteId <= 0) return BadRequest();
            return Ok(baixasByPaciente);
        }

        [HttpGet("GetAllBaixasSetorId")]
        public async Task<IActionResult> GetAllBaixasBySetorId(int tipoSetorId, int pageNumber, int pageSize)
        {
            if (tipoSetorId <= 0) return BadRequest();
            List<GetBaixaMedicaDTO> baixasPorSetor = await _baixaMedicaService.GetAllBaixasBySetorIdAsync(tipoSetorId, pageNumber, pageSize);
            if(baixasPorSetor.Count == 0) return NotFound();
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
        #endregion

        #region Relatorios
        [HttpGet("GetAllBaixasTotalCount")]
        public async Task<IActionResult> GetAllBaixasTotalCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasTotalCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPrivadoTotalCount")]
        public async Task<IActionResult> GetAllBaixasSetorPrivadoTotalCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPrivadoTotalCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPublicoTotalCount")]
        public async Task<IActionResult> GetAllBaixasSetorPublicoTotalCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPublicoTotalCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPrivadoIdadeJovemCount")]
        public async Task<IActionResult> GetAllBaixasSetorPrivadoIdadeJovemCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPrivadoIdadeJovemCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPublicoIdadeJovemCount")]
        public async Task<IActionResult> GetAllBaixasSetorPublicoIdadeJovemCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPublicoIdadeJovemCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPrivadoIdadeJovemAdultoCount")]
        public async Task<IActionResult> GetAllBaixasSetorPrivadoIdadeJovemAdultoCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPrivadoIdadeJovemAdultoCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPublicoIdadeJovemAdultoCount")]
        public async Task<IActionResult> GetAllBaixasSetorPublicoIdadeJovemAdultoCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPublicoIdadeJovemAdultoCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPrivadoIdadeAdultoCount")]
        public async Task<IActionResult> GetAllBaixasSetorPrivadoIdadeAdultoCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPrivadoIdadeAdultoCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPublicoIdadeAdultoCount")]
        public async Task<IActionResult> GetAllBaixasSetorPublicoIdadeAdultoCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPublicoIdadeAdultoCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPrivadoEntidadePatronalCount")]
        public async Task<IActionResult> GetAllBaixasSetorPrivadoEntidadePatronalCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPrivadoEntidadePatronalCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPublicoEntidadePatronalCount")]
        public async Task<IActionResult> GetAllBaixasSetorPublicoEntidadePatronalCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPublicoEntidadePatronalCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPrivadoProfissaoCount")]
        public async Task<IActionResult> GetAllBaixasSetorPrivadoProfissaoCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPrivadoProfissaoCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllBaixasSetorPublicoProfissaoCount")]
        public async Task<IActionResult> GetAllBaixasSetorPublicoProfissaoCount()
        {
            var result = await _baixaMedicaService.GetAllBaixasSetorPublicoProfissaoCount();
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        #endregion
    }
}
