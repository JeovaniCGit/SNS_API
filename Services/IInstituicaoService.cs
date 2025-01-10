﻿using SNS.Models;
using SNS.Utilities;
using SNS.DTOs;

namespace SNS.Services
{
    public interface IInstituicaoService
    {
        Task<Result<InstituicaoDTO>> CreateInstituicao(InstituicaoDTO institutoDTO);
        Task<List<InstituicaoDTO>> GetAllInstituicoes();
        Task<Result<InstituicaoDTO>> GetInstituicaoById(int id);
    }
}
