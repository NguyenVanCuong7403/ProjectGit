using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class User
{
    public int Id { get; set; }

    public string DisplayName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Assessment> AssessmentLectures { get; set; } = new List<Assessment>();

    public virtual ICollection<Assessment> AssessmentStudents { get; set; } = new List<Assessment>();

    public virtual ICollection<Comment> CommentLectures { get; set; } = new List<Comment>();

    public virtual ICollection<Comment> CommentStudents { get; set; } = new List<Comment>();

    public virtual ICollection<QnA> QnALectures { get; set; } = new List<QnA>();

    public virtual ICollection<QnA> QnAStudents { get; set; } = new List<QnA>();

    public virtual ICollection<QualityOfLecture> QualityOfLectureLectures { get; set; } = new List<QualityOfLecture>();

    public virtual ICollection<QualityOfLecture> QualityOfLectureStudents { get; set; } = new List<QualityOfLecture>();

    public virtual Role Role { get; set; } = null!;
}
