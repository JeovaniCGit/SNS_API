using SNS.DTOs;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Services
{
    public interface IUtilizadorService
    {
        Task<List<Utilizador>> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<Result<Utilizador?>> GetUserByIdAsync(int id);
        Task<Result<Utilizador>> AddUserAsync(UtilizadorRegistrationDTO userDto);
        Task<Result<Utilizador?>> UpdateUserAsync(int id, UtilizadorUpdateDTO userDto);
        Task<Result<bool>> DeleteUserAsync(int id);
    }
}
