﻿using System.ComponentModel.DataAnnotations;
using SNS.Models;

namespace SNS.DTOs
{
    public class UtilizadorDTO
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required int NTelefone { get; set; }
        public required DateTime DataNascimento { get; set; }
        public required int NumeroCc { get; set; }
        public required string Sexo { get; set; }
        public required string Morada { get; set; }
        public int? MedicoAttributedId { get; set; }
    }
}
