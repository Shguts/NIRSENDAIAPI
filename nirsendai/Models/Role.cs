using System;
using System.Collections.Generic;

namespace Models;

public partial class Role
{
    public int IdD { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
