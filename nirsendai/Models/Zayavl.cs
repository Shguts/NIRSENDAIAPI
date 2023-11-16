using System;
using System.Collections.Generic;

namespace Models;

public partial class Zayavl
{
    public int IdZayv { get; set; }

    public string Login { get; set; } = null!;

    public int IdFile { get; set; }

    public virtual FileUser IdFileNavigation { get; set; } = null!;

    public virtual User LoginNavigation { get; set; } = null!;
}
