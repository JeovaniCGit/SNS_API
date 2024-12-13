using System;
using System.Collections.Generic;

namespace SNS.Models;

public class Utilizador
{
    public int Id { get; set; }

    //public required string PasswordHash { get; set; }

    public string? Nome { get; set; }

    public int? NTelefone { get; set; }

    public DateTime? DataNascimento { get; set; }

    public int? NumeroCc { get; set; }

    public string? Sexo { get; set; }

    public string? Morada { get; set; }

    public int TipoDeUtilizadorid { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual TipoDeUtilizador TipoDeUtilizador { get; set; } = null!;
}
