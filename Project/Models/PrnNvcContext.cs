using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Project.Models;

public partial class PrnNvcContext : DbContext
{
    public static PrnNvcContext INSTANCE = new PrnNvcContext();
    public PrnNvcContext()
    {
    }

    public PrnNvcContext(DbContextOptions<PrnNvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Attitude> Attitudes { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<QnA> QnAs { get; set; }

    public virtual DbSet<Quality> Qualities { get; set; }

    public virtual DbSet<QualityOfLecture> QualityOfLectures { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var congfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(congfig.GetConnectionString("DBContext"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasOne(d => d.Attitude).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.AttitudeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_Attitude");

            entity.HasOne(d => d.Lecture).WithMany(p => p.AssessmentLectures)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_User");

            entity.HasOne(d => d.Quality).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.QualityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_Quality");

            entity.HasOne(d => d.Student).WithMany(p => p.AssessmentStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_User1");
        });

        modelBuilder.Entity<Attitude>(entity =>
        {
            entity.ToTable("Attitude");

            entity.Property(e => e.DisplayName).HasMaxLength(50);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.HasOne(d => d.Lecture).WithMany(p => p.CommentLectures)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_User");

            entity.HasOne(d => d.Student).WithMany(p => p.CommentStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_User1");
        });

        modelBuilder.Entity<QnA>(entity =>
        {
            entity.ToTable("QnA");

            entity.HasOne(d => d.Lecture).WithMany(p => p.QnALectures)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QnA_User");

            entity.HasOne(d => d.Student).WithMany(p => p.QnAStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QnA_User1");
        });

        modelBuilder.Entity<Quality>(entity =>
        {
            entity.ToTable("Quality");

            entity.Property(e => e.DisplayName).HasMaxLength(50);
        });

        modelBuilder.Entity<QualityOfLecture>(entity =>
        {
            entity.ToTable("QualityOfLecture");

            entity.HasOne(d => d.Lecture).WithMany(p => p.QualityOfLectureLectures)
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QualityOfLecture_User");

            entity.HasOne(d => d.Student).WithMany(p => p.QualityOfLectureStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QualityOfLecture_User1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.DisplayName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.DisplayName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
