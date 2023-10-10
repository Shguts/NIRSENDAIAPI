using System;
using System.Collections.Generic;

namespace nirsendai.Models;

public partial class Ball
{
    public string Login { get; set; } = null!;

    public int IdCriterie { get; set; }

    public float? Mark { get; set; }

    public int IdZayv { get; set; }

    public virtual Critery IdCriterieNavigation { get; set; } = null!;

    public virtual User LoginNavigation { get; set; } = null!;
}
