using System;
using System.Collections.Generic;

namespace nirsendai.Models;

public partial class Zayavl
{
    public int IdZayv { get; set; }

    public byte[]? File { get; set; }

    public string? Login { get; set; }

    public virtual ICollection<Ball> Balls { get; set; } = new List<Ball>();

    public virtual User? LoginNavigation { get; set; }
}
