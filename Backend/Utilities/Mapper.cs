using SNS.DTOs;
using SNS.Models;

namespace SNS.Utilities
{
    public class Mapper
    {
        public static Utilizador MapperParaEntity (UtilizadorRegistrationDTO userDto)
        {
            return new Utilizador
            {
                Nome = userDto.Nome,
                NTelefone = userDto.NTelefone,
                DataNascimento = userDto.DataNascimento,
                NumeroCc = userDto.NumeroCc,
                Sexo = userDto.Sexo,
                Morada = userDto.Morada,
                TipoDeUtilizadorid = userDto.TipoDeUtilizadorid
            };
        }

        public static UtilizadorDTO MapperParaDTO (Utilizador utilizador)
        {
            return new UtilizadorDTO
            {
                Nome = utilizador.Nome,
                Password = utilizador.Password,
                NTelefone = utilizador.NTelefone,
                DataNascimento = utilizador.DataNascimento,
                NumeroCc = utilizador.NumeroCc,
                Sexo = utilizador.Sexo,
                Morada = utilizador.Morada,
                Medicos = utilizador.Medicos,
                Pacientes = utilizador.Pacientes
            };
        }

        public static HistoricoLaboral MapperParaEntity (HistoricoLaboralDTO historicoDTO)
        {
            return new HistoricoLaboral
            {
                Instituiçãoid = historicoDTO.Instituiçãoid,
                DataInicio = historicoDTO.DataInicio,
                DataFim = historicoDTO.DataFim
            };
        }

        public static HistoricoLaboralDTO MapperParaDTO (HistoricoLaboral historico)
        {
            return new HistoricoLaboralDTO
            {
                Instituiçãoid = historico.Instituiçãoid,
                DataInicio = historico.DataInicio,
                DataFim = historico.DataFim
            };
        }

        public static InstituicaoDTO MapperParaDTO (Instituição instituicao)
        {
            return new InstituicaoDTO
            {
                Id = instituicao.Id,
                Descri = instituicao.Descri!,
                TipoDeSetor = instituicao.TipoDeSetor,
            };
        }
    }
}