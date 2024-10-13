﻿using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Role
{
    public int Id { get; set; }

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
