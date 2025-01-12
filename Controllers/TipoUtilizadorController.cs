﻿using Microsoft.AspNetCore.Mvc;
using SNS.Data;
using SNS.Models;
using SNS.Services;

namespace SNS.Controllers
{
    public class TipoUtilizadorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITipoUtilizadorService _tipoUtilizadorService;

        public TipoUtilizadorController(ApplicationDbContext context, ITipoUtilizadorService tipoUtilizadorService)
        {
            _context = context;
            _tipoUtilizadorService = tipoUtilizadorService;
        }

        [HttpGet("GetAllTiposUtilizador")]
        public async Task<IActionResult> GetAllTiposUtilizador()
        {
            List<TipoDeUtilizador> tipos = await _tipoUtilizadorService.GetAllTiposUtilizador();
            if(tipos.Count == 0) return NotFound(tipos);
            return Ok(tipos);
        }
    }
}
