﻿using System;
using System.Collections.Generic;

namespace SNS.Models;

public class Paciente
{
    public int Id { get; set; }

    public string? Profissao { get; set; }

    public string? EntidadePatronal { get; set; }

    public int? NumeroSns { get; set; }

    public int Utilizadorid { get; set; }

    public virtual Utilizador Utilizador { get; set; } = null!;
    public virtual ICollection<BaixaMedica> BaixasMedicas { get; set; } = new List<BaixaMedica>();
}
