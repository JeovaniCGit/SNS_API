using SNS.Models;
using SNS.Utilities;
using SNS.DTOs;

namespace SNS.Interfaces
{
    public interface IInstituicaoService
    {
        Task<Result<GetInstituicaoDTO>> CreateInstituicao(CreateInstituicaoDTO institutoDTO);
        Task<List<GetInstituicaoDTO>> GetAllInstituicoes();
        Task<Result<GetInstituicaoDTO>> GetInstituicaoById(int id);
    }
}
