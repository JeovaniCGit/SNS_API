using System;
using System.Collections.Generic;

namespace SNS.Models;

public class Utilizador
{
    public int Id { get; set; }
    //public required string PasswordHash { get; set; }
    public required string Nome { get; set; }
    public required int NTelefone { get; set; }
    public required DateTime DataNascimento { get; set; }
    public required int NumeroCc { get; set; }
    public required string Sexo { get; set; }
    public required string Morada { get; set; }
    public required int TipoDeUtilizadorid { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? DataApagado { get; set; }
    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
    public virtual TipoDeUtilizador TipoDeUtilizador { get; set; } = null!;
}
