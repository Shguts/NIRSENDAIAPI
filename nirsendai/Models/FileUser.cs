using System;
using System.Collections.Generic;

namespace nirsendai.Models;

public partial class FileUser
{
    public int IdFile { get; set; }

    public string? Login { get; set; }

    public byte[]? FileData { get; set; }

    public string? FileName { get; set; }

    public virtual User? LoginNavigation { get; set; }

    public virtual ICollection<Zayavl> Zayavls { get; set; } = new List<Zayavl>();
}
