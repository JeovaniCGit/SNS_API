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

        public UtilizadorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Utilizador>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            if(pageNumber <= 0 || pageSize <= 0) return new List<Utilizador>();
            var totalCount = await _context.Utilizadores.CountAsync();
            if (totalCount == 0) return new List<Utilizador>();
            var users = await _context.Utilizadores
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return users;
        }
        public async Task<Result<Utilizador?>> GetUserByIdAsync(int id)
        {
            var user = await _context.Utilizadores.FindAsync(id);
            if (user != null)
            {
                return Result<Utilizador?>.IsValid(user);
            }
            return Result<Utilizador?>.NaoEncontrado();
        }
        public async Task<Result<Utilizador>> AddUserAsync(UtilizadorRegistrationDTO userDto)
        {
            var checkUserInDB = await _context.Utilizadores.FirstOrDefaultAsync(user => user.Nome == userDto.Nome);
            if (checkUserInDB != null)
            {
                Console.WriteLine("DB Name: " + checkUserInDB.Nome);
                Console.WriteLine("Input Name: " + userDto.Nome);
                return Result<Utilizador>.ValorDuplicado();
            }

            Utilizador utilizador = new Utilizador()
            {
                Nome = userDto.Nome,
                //PasswordHash = userDto.PasswordHash,
                NTelefone = userDto.NTelefone,
                DataNascimento = userDto.DataNascimento.Date,
                NumeroCc = userDto.NumeroCc,
                Sexo = userDto.Sexo,
                Morada = userDto.Morada,
               /*Teste only*/ TipoDeUtilizadorid = 1
            };

            await _context.Utilizadores.AddAsync(utilizador);
            await _context.SaveChangesAsync();
            return Result<Utilizador>.IsValid(utilizador);
        }
        public async Task<Result<bool>> DeleteUserAsync(int id)
        {
            var userToDelete = await _context.Utilizadores.FindAsync(id);
            if (userToDelete == null)
            {
                return Result<bool>.NaoApagado();
            }

            _context.Utilizadores.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return Result<bool>.IsDeleted();
        }
        public async Task<Result<Utilizador?>> UpdateUserAsync(int id, UtilizadorUpdateDTO updatedUser)
        {
            var userToUpdate = await _context.Utilizadores.FindAsync(id);

            if (userToUpdate == null)
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
