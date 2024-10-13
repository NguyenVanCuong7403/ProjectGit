using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class QnA
{
    public int Id { get; set; }

    public int LectureId { get; set; }

    public int StudentId { get; set; }

    public string Question { get; set; } = null!;

    public string? Answer { get; set; }

    public virtual User Lecture { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
