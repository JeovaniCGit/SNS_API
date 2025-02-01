using Microsoft.AspNetCore.Mvc;
using SNS.Data;
using SNS.DTOs;
using SNS.Interfaces;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Controllers
{
    public class InstituicaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstituicaoService _instituicaoService;

        public InstituicaoController(ApplicationDbContext context, IInstituicaoService instituicaoService)
        {
            _context = context;
            _instituicaoService = instituicaoService;
        }

        #region Create
        [HttpPost("CreateInstituicao")]
        public async Task<IActionResult> CreateInstituicao(CreateInstituicaoDTO instituicaoDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _instituicaoService.CreateInstituicao(instituicaoDTO);
            if (result.IsSuccess == false) return BadRequest(result.Message);
            return CreatedAtAction(nameof(GetInstituicaoById), new { id = result.Data!.Id }, result);
        }
        #endregion


        #region Read
        [HttpGet("GetAllInstituicoes")]
        public async Task<IActionResult> GetAllInstituicoes()
        {
            List<GetInstituicaoDTO> insti = await _instituicaoService.GetAllInstituicoes();
            if (insti.Count == 0) return NotFound(insti);
            return Ok(insti);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstituicaoById (int id)
        {
            if (id <= 0) return BadRequest();
            var result = await _instituicaoService.GetInstituicaoById(id);
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }
        #endregion
    }
}
