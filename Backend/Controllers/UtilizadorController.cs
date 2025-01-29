using Microsoft.AspNetCore.Mvc;
using SNS.Data;
using SNS.DTOs;
using SNS.Models;
using SNS.Services;

namespace SNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUtilizadorService _utilizadorService;

        public UtilizadorController(ApplicationDbContext context, IUtilizadorService utilizadorService)
        {
            _context = context;
            _utilizadorService = utilizadorService;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UtilizadorRegistrationDTO userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _utilizadorService.AddUserAsync(userDto);
            if (result.IsSuccess == false) return BadRequest(result.Message);
            return CreatedAtAction(nameof(GetUserById), new { id = result.Data!.Id }, result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UtilizadorLoginDTO loginDto)
        {
            var resultado = await _utilizadorService.LoginAsync(loginDto.Nome, loginDto.Password);

            if (resultado.IsSuccess)
            {
                return Ok(resultado.Data);
            }
            else
            {
                return Unauthorized(resultado.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (id <= 0) return BadRequest("Id inválido");
            var result = await _utilizadorService.GetUserByIdAsync(id);
            if (!result.IsSuccess) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers( int pageNumber, int pageSize)
        {
            List<UtilizadorDTO> users = await _utilizadorService.GetAllUsersAsync(pageNumber, pageSize);
            if (users.Count == 0) return NotFound(users);
            if (pageSize <= 0 || pageSize <= 0) return BadRequest();
            return Ok(users);
        }

        [HttpPut("UpdateUser_{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, UtilizadorUpdateDTO userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id <= 0) return BadRequest("Id inválido");
            var result = await _utilizadorService.UpdateUserAsync(id, userDto);
            if(result.IsSuccess == true) return Ok(result);
            return NotFound(result.Message);
        }

        [HttpDelete("DeleteUser_{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (id <= 0) return BadRequest("Id inválido");
            var result = await _utilizadorService.DeleteUserAsync(id);
            if (result.IsSuccess) return Ok(result);
            return NotFound(result.Message);
        }
    }
}
