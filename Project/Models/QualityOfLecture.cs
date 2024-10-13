using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class QualityOfLecture
{
    public int Id { get; set; }

    public int LectureId { get; set; }

    public int StudentId { get; set; }

    public int QualityId { get; set; }

    public DateOnly CreateAt { get; set; }

    public virtual User Lecture { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
