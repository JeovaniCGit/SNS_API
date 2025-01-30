using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SNS.Data;
using SNS.DTOs;
using SNS.Interfaces;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Services
{
    public class UtilizadorService : IUtilizadorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPacienteService _pacienteService;
        private readonly PasswordHasher<Utilizador> _passwordHasher;

        public UtilizadorService(ApplicationDbContext context, IPacienteService pacienteService)
        {
            _context = context;
            _pacienteService = pacienteService;
            _passwordHasher = new PasswordHasher<Utilizador>();
        }

        public async Task<List<UtilizadorResponseDTO>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            if(pageNumber <= 0 || pageSize <= 0) return new List<UtilizadorResponseDTO>();
            var totalCount = await _context.Utilizadores.CountAsync();
            if (totalCount == 0) return new List<UtilizadorResponseDTO>();
            var users = await _context.Utilizadores
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new UtilizadorResponseDTO
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    NTelefone = u.NTelefone,
                    DataNascimento = u.DataNascimento,
                    NumeroCc = u.NumeroCc,
                    Sexo = u.Sexo,
                    Morada = u.Morada,
                })
                .ToListAsync();
            return users;
        }
        public async Task<Result<UtilizadorResponseDTO?>> GetUserByIdAsync(int id)
        {
            var user = await _context.Utilizadores.Where(u => u.Id == id).Select(u => new UtilizadorResponseDTO
            {
                Id = u.Id,
                Nome = u.Nome,
                NTelefone = u.NTelefone,
                DataNascimento = u.DataNascimento,
                NumeroCc = u.NumeroCc,
                Sexo = u.Sexo,
                Morada = u.Morada
            }).FirstOrDefaultAsync();
            if (user != null)
            {
                return Result<UtilizadorResponseDTO?>.IsValid(user);
            }
            return Result<UtilizadorResponseDTO?>.NaoEncontrado();
        }
        public async Task<Result<UtilizadorDTO>> AddUserAsync(UtilizadorRegistrationDTO userDto)
        {
            var checkUserInDB = await _context.Utilizadores.FirstOrDefaultAsync(user => user.Nome == userDto.Nome);
            if (checkUserInDB != null) return Result<UtilizadorDTO>.ValorDuplicado();

            Utilizador utilizador = Mapper.MapperParaEntity(userDto);

            var passwordHasher = new PasswordHasher<Utilizador>();
            var hashedPassword = passwordHasher.HashPassword(utilizador, userDto.Password);
            utilizador.Password = hashedPassword;

            await _context.Utilizadores.AddAsync(utilizador);
            await _context.SaveChangesAsync();

           if (userDto.PacienteData!.MedicoToAttributeId != 0)
            {
                if (!string.IsNullOrWhiteSpace(userDto.PacienteData!.Profissao) && !string.IsNullOrWhiteSpace(userDto.PacienteData!.EntidadePatronal) && userDto.PacienteData.NumeroSns > 0)
                {
                    var userAddedId = await _context.Utilizadores.FirstOrDefaultAsync(u => u.NumeroCc == userDto.NumeroCc);
                    var pacienteData = await _pacienteService.ValidatePacienteForRegistration(userDto, userDto.PacienteData, userAddedId!);

                    await _context.Pacientes.AddAsync(pacienteData.Data!);
                    await _context.SaveChangesAsync();
                }
            }

            return Result<UtilizadorDTO>.IsValid(Mapper.MapperParaDTO(utilizador));
        }

        public async Task<Result<UtilizadorDTO>> LoginAsync(string nome, string password)
        {
            var utilizador = await _context.Utilizadores.FirstOrDefaultAsync(u => u.Nome == nome);
            if (utilizador == null)
            {
                return Result<UtilizadorDTO>.NaoEncontrado("Utilizador não encontrado");
            }

            var result = _passwordHasher.VerifyHashedPassword(utilizador, utilizador.Password, password);

            if (result == PasswordVerificationResult.Success)
            {
                return Result<UtilizadorDTO>.IsValid(Mapper.MapperParaDTO(utilizador));
            }
            else
            {
                return Result<UtilizadorDTO>.PasswordErrada();
            }
        }

        public async Task<Result<bool>> DeleteUserAsync(int id)
        {
            var userToDelete = await _context.Utilizadores.FindAsync(id);
            var medicoAssociated = await _context.Medicos.FirstOrDefaultAsync(m => m.Utilizadorid == id);
            var pacienteAssociated = await _context.Pacientes.FirstOrDefaultAsync(p => p.Utilizadorid == id);
            
            if (userToDelete == null) return Result<bool>.NaoApagado();

            if (medicoAssociated != null) medicoAssociated.IsActive = false;
            if (pacienteAssociated != null) pacienteAssociated.IsActive = false;


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
