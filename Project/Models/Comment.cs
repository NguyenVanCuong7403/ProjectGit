using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int LectureId { get; set; }

    public int StudentId { get; set; }

    public string Content { get; set; } = null!;

    public virtual User Lecture { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
