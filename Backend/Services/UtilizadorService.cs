using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SNS.Data;
using SNS.DTOs;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Services
{
    public class UtilizadorService : IUtilizadorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMedicoService _medicoService;
        private readonly IPacienteService _pacienteService;

        public UtilizadorService(ApplicationDbContext context, IMedicoService medicoService, IPacienteService pacienteService)
        {
            _context = context;
            _medicoService = medicoService;
            _pacienteService = pacienteService;
        }

        public async Task<List<UtilizadorDTO>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            if(pageNumber <= 0 || pageSize <= 0) return new List<UtilizadorDTO>();
            var totalCount = await _context.Utilizadores.CountAsync();
            if (totalCount == 0) return new List<UtilizadorDTO>();
            var users = await _context.Utilizadores
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new UtilizadorDTO
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    NTelefone = u.NTelefone,
                    DataNascimento = u.DataNascimento,
                    NumeroCc = u.NumeroCc,
                    Sexo = u.Sexo,
                    Morada = u.Morada,
                    Pacientes = u.Pacientes,
                    Medicos = u.Medicos
                })
                .ToListAsync();
            return users;
        }
        public async Task<Result<UtilizadorDTO?>> GetUserByIdAsync(int id)
        {
            var user = await _context.Utilizadores.Where(u => u.Id == id)
                .Select(u => new UtilizadorDTO
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    NTelefone = u.NTelefone,
                    DataNascimento = u.DataNascimento,
                    NumeroCc = u.NumeroCc,
                    Sexo = u.Sexo,
                    Morada = u.Morada,
                    Pacientes = u.Pacientes,
                    Medicos = u.Medicos
                }).FirstOrDefaultAsync();
            if (user != null)
            {
                return Result<UtilizadorDTO?>.IsValid(user);
            }
            return Result<UtilizadorDTO?>.NaoEncontrado();
        }
        public async Task<Result<UtilizadorDTO>> AddUserAsync(UtilizadorRegistrationDTO userDto)
        {
            var checkUserInDB = await _context.Utilizadores.FirstOrDefaultAsync(user => user.Nome == userDto.Nome);
            if (checkUserInDB != null) return Result<UtilizadorDTO>.ValorDuplicado();

            Utilizador utilizador = Mapper.MapperParaEntity(userDto);

            if (userDto.MedicoToAttributeId > 0)
            {
                var medicoToAttribute = await _medicoService.ValidateMedicoForUserRegistration(userDto);
                if (medicoToAttribute.IsSuccess == false) return Result<UtilizadorDTO>.ErroNoPedido();
                utilizador.Medicos.Add(medicoToAttribute.Data!);
            }

            if (!string.IsNullOrWhiteSpace(userDto.PacienteData!.Profissao)
                && !string.IsNullOrWhiteSpace(userDto.PacienteData!.EntidadePatronal)
                    && userDto.PacienteData.NumeroSns > 0)
            {
                var pacienteData = await _pacienteService.ValidatePacienteForRegistration(userDto);
                if (pacienteData.IsSuccess == false) return Result<UtilizadorDTO>.ValorDuplicado();
                utilizador.Pacientes.Add(pacienteData.Data!);
            }
            await _context.Utilizadores.AddAsync(utilizador);
            await _context.SaveChangesAsync();
            return Result<UtilizadorDTO>.IsValid(Mapper.MapperParaDTO(utilizador));
        }
        public async Task<Result<bool>> DeleteUserAsync(int id)
        {
            var userToDelete = await _context.Utilizadores.FindAsync(id);
            
            if (userToDelete == null) return Result<bool>.NaoApagado();
            
            userToDelete.IsActive = false;
            userToDelete.DataApagado = DateTime.Now;
            await _context.SaveChangesAsync();
            return Result<bool>.IsDeleted();
        }
        public async Task<Result<Utilizador?>> UpdateUserAsync(int id, UtilizadorUpdateDTO updatedUser)
        {
            var userToUpdate = await _context.Utilizadores.FindAsync(id);

            if (userToUpdate == null || !userToUpdate.IsActive)
            {
                return Result<Utilizador?>.NaoEncontrado();
            }

            userToUpdate.Nome = updatedUser.Nome;
            userToUpdate.NTelefone = updatedUser.NTelefone;
            userToUpdate.Sexo = updatedUser.Sexo;
            userToUpdate.Morada = updatedUser.Morada;

            await _context.SaveChangesAsync();
            return Result<Utilizador?>.IsUpdated(userToUpdate);
        }
    }
}
