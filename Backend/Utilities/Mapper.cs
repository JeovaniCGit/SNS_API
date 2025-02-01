using SNS.DTOs;
using SNS.Models;

namespace SNS.Utilities
{
    public class Mapper
    {
        #region MapperUtilizador
        public static Utilizador MapperParaEntity (UtilizadorRegistrationDTO userDto)
        {
            return new Utilizador
            {
                Nome = userDto.Nome.FirstLetterToUpperCase()!,
                NTelefone = userDto.NTelefone,
                DataNascimento = userDto.DataNascimento,
                NumeroCc = userDto.NumeroCc,
                Sexo = userDto.Sexo,
                Morada = userDto.Morada.FirstLetterToUpperCase()!,
                TipoDeUtilizadorid = userDto.TipoDeUtilizadorid
            };
        }

        public static UtilizadorDTO MapperParaDTO (Utilizador utilizador)
        {
            return new UtilizadorDTO
            {
                Id = utilizador.Id,
                Nome = utilizador.Nome,
                NTelefone = utilizador.NTelefone,
                DataNascimento = utilizador.DataNascimento,
                NumeroCc = utilizador.NumeroCc,
                Sexo = utilizador.Sexo,
                Morada = utilizador.Morada
            };
        }

        public static UtilizadorResponseDTO MapperParaDTOResponseMedicoPaciente (Utilizador utilizador)
        {
            return new UtilizadorResponseDTO
            {
                Id = utilizador.Id,
                Nome = utilizador.Nome,
                NTelefone = utilizador.NTelefone,
                DataNascimento = utilizador.DataNascimento,
                NumeroCc = utilizador.NumeroCc,
                Sexo = utilizador.Sexo,
                Morada = utilizador.Morada
            };
        }
        #endregion

        #region MapperHistoricoLaboral
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
        #endregion

        #region MapperInstituicao
        public static GetInstituicaoDTO MapperParaDTO (Instituição instituicao)
        {
            return new GetInstituicaoDTO
            {
                Id = instituicao.Id,
                Descri = instituicao.Descri!,
                TipoDeSetor = instituicao.TipoDeSetor,
            };
        }
        #endregion

        #region MapperPaciente
        public static Paciente MapperParaEntity (CreatePacienteDTO pacienteDTO, Utilizador user)
        {
            return new Paciente
            {
                Profissao = pacienteDTO.Profissao,
                EntidadePatronal = pacienteDTO.EntidadePatronal,
                NumeroSns = pacienteDTO.NumeroSns,
                Utilizador = user
            };
        }

        public static GetPacienteDTO MapperParaDTO(Paciente paciente)
        {
            return new GetPacienteDTO
            {
                Id = paciente.Id,
                Profissao = paciente.Profissao,
                EntidadePatronal = paciente.EntidadePatronal,
                NumeroSns = paciente.NumeroSns,
            };
        }

        public static GetPacienteParaBaixaDTO MapperParaDTOParaBaixa(Paciente paciente)
        {
            return new GetPacienteParaBaixaDTO
            {
                Id = paciente.Id,
                Profissao = paciente.Profissao,
                EntidadePatronal = paciente.EntidadePatronal,
                NumeroSns = paciente.NumeroSns,
                Nome = paciente.Utilizador!.Nome,
                DataNascimento = paciente.Utilizador!.DataNascimento
            };
        }

        #endregion

        #region MapperMedico
        public static GetMedicoDataDTO MapperParaDTO (Medico medico)
        {
            return new GetMedicoDataDTO
            {
                Id = medico.Id,
                EspecialidadeId = medico.Especialidadeid,
                AllHistoricoLaboral = medico.HistoricoLaborals,
                NomeDoMedico = medico.Utilizador!.Nome
            };
        }
        public static GetMedicoDataParaBaixaDTO MapperParaDTOParaBaixa(Medico medico)
        {
            return new GetMedicoDataParaBaixaDTO
            {
                Id = medico.Id,
                EspecialidadeId = medico.Especialidadeid,
                AllHistoricoLaboral = medico.HistoricoLaborals,
                Nome = medico.Utilizador!.Nome,
                DataNascimento = medico.Utilizador!.DataNascimento
            };
        }
        #endregion
    }
}