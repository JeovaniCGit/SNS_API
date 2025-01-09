using System;
using System.Collections.Generic;

namespace SNS.Models;

public class HistoricoLaboral
{
    public int? Id { get; set; }

    public int Instituiçãoid { get; set; }

    public int Medicoid { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public virtual Instituição Instituição { get; set; } = null!;
}
