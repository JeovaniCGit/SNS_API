using System;
using System.Collections.Generic;

namespace SNS.Models;

public class Especialidade
{
    public int Id { get; set; }

    public string? Descri { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
