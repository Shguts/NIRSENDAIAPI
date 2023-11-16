using System;
using System.Collections.Generic;

namespace Models;

public partial class Critery
{
    public int IdCriterie { get; set; }

    public string? NameCriterie { get; set; }

    public virtual ICollection<Ball> Balls { get; set; } = new List<Ball>();
}
