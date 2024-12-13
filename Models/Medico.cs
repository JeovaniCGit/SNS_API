using System;
using System.Collections.Generic;

namespace SNS.Models;

public class Medico
{
    public int Id { get; set; }

    public int? NMedico { get; set; }

    public int Utilizadorid { get; set; }

    public int Especialidadeid { get; set; }

    public virtual Especialidade Especialidade { get; set; } = null!;

    public virtual ICollection<HistoricoLaboral> HistoricoLaborals { get; set; } = new List<HistoricoLaboral>();

    public virtual Utilizador Utilizador { get; set; } = null!;
    public virtual ICollection<BaixaMedica> BaixasMedicas { get; set; } = new List<BaixaMedica>();
}
