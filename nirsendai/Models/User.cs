﻿using System;
using System.Collections.Generic;

namespace Models;

public partial class User
{
    public string Login { get; set; } = null!;

    public string? Passwd { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? SecondName { get; set; }

    public DateTime? DateBirth { get; set; }

    public int RoleId { get; set; }

    public string? Region { get; set; }

    public string? CategoryMo { get; set; }

    public virtual ICollection<Ball> Balls { get; set; } = new List<Ball>();

    public virtual ICollection<FileUser> FileUsers { get; set; } = new List<FileUser>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Zayavl> Zayavls { get; set; } = new List<Zayavl>();
}
