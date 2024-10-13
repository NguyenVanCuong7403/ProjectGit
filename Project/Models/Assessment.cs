using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class Assessment
{
    public int Id { get; set; }

    public int LectureId { get; set; }

    public int StudentId { get; set; }

    public int AttitudeId { get; set; }

    public DateOnly CreateAt { get; set; }

    public int QualityId { get; set; }

    public string? Commnet { get; set; }

    public virtual Attitude Attitude { get; set; } = null!;

    public virtual User Lecture { get; set; } = null!;

    public virtual Quality Quality { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
