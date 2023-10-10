using System;
using System.Collections.Generic;

namespace nirsendai.Models;

public partial class Zayavl
{
    public int IdZayv { get; set; }

    public string Login { get; set; } = null!;

    public int IdFile { get; set; }

    public virtual FileUser IdFileNavigation { get; set; } = null!;

    public virtual User LoginNavigation { get; set; } = null!;
    public byte[]? File { get; set; }

    public virtual ICollection<Ball> Balls { get; set; } = new List<Ball>();

}
