using System;
using System.Collections.Generic;

namespace SNS.Models;

public class Instituição
{
    public int Id { get; set; }

    public string? Descri { get; set; }

    public int TipoDeSetorid { get; set; }

    public virtual ICollection<HistoricoLaboral> HistoricoLaborals { get; set; } = new List<HistoricoLaboral>();

    public virtual TipoDeSetor TipoDeSetor { get; set; } = null!;
}
