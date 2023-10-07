using System;
using System.Collections.Generic;

namespace nirsendai.Models;

public partial class User
{
    public string Login { get; set; } = null!;

    public string? Passwd { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? SecondName { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Ball> Balls { get; set; } = new List<Ball>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Zayavl> Zayavls { get; set; } = new List<Zayavl>();
}
