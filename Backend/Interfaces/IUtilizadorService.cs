﻿using Microsoft.AspNetCore.Mvc;
using SNS.DTOs;
using SNS.Models;
using SNS.Utilities;

namespace SNS.Interfaces
{
    public interface IUtilizadorService
    {
        Task<List<UtilizadorResponseDTO>> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<Result<UtilizadorResponseDTO?>> GetUserByIdAsync(int id);
        Task<Result<UtilizadorDTO>> AddUserAsync(UtilizadorRegistrationDTO userDto);
        Task<Result<Utilizador?>> UpdateUserAsync(int id, UtilizadorUpdateDTO userDto);
        Task<Result<bool>> DeleteUserAsync(int id);
        Task<Result<UtilizadorDTO>> LoginAsync(string nome, string password);
    }
}
