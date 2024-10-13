using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Quality
{
    public int Id { get; set; }

    public string DisplayName { get; set; } = null!;

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
}
