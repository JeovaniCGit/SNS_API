﻿using Microsoft.AspNetCore.Mvc;
using SNS.Data;
using SNS.Models;
using Microsoft.EntityFrameworkCore;
using SNS.Interfaces;
using SNS.DTOs;

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

        #region Create
        [HttpPost("AddMedico")]
        public async Task<IActionResult> AddMedico([FromBody] CreateMedicoWithIdDTO createMedicoDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _medicoService.AddMedico(createMedicoDTO);
            if (result.IsSuccess == false) return BadRequest(result.Message);
            return CreatedAtAction(nameof(GetMedicoById), new { id = result.Data!.Id }, result);
        }
        #endregion

        #region Read
        [HttpGet("GetPacientesByNumeroSNS")]
        public async Task<IActionResult> GetPacienteByNumeroSNSAsync(int numeroSNS)
        {
            if (numeroSNS <= 0) return BadRequest("Número SNS inválido");
            var result = await _medicoService.GetPacienteByNumeroSNSAsync(numeroSNS);
            if (result.IsSuccess == false) return NotFound(result?.Message);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicoById(int id)
        {
            if (id <= 0) return BadRequest("Id inválido");
            var result = await _medicoService.GetMedicoById(id);
            if (result.IsSuccess == false) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllMedicos")]
        public async Task<IActionResult> GetAllMedicos(int pageNumber, int pageSize)
        {
            List<GetMedicoDataDTO> medicos = await _medicoService.GetAllMedicos(pageNumber, pageSize);
            if (medicos.Count == 0) return NotFound(medicos);
            if (pageNumber <= 0 || pageSize <= 0) return BadRequest();
            return Ok(medicos);
        }
        #endregion

        #region Update
        [HttpPut("UpdateHistoricoMedico_{medicoId}")]
        public async Task<IActionResult> UpdateHistoricoLaboral([FromRoute]int medicoId, HistoricoLaboralDTO historicoDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (medicoId <= 0) return BadRequest("Id inválido");
            var result = await _medicoService.UpdateHistoricoLaboral(medicoId, historicoDTO);
            if (result.IsSuccess == false) return BadRequest(result.Message);
            return Ok(result);
        }
        #endregion
    }
}
