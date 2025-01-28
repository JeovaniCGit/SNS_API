using System;
using System.Collections.Generic;

namespace SNS.Models;

public class TipoDeUtilizador
{
    public int Id { get; set; }

    public string? Descri { get; set; }

    public virtual ICollection<Utilizador> Utilizadors { get; set; } = new List<Utilizador>();
}
