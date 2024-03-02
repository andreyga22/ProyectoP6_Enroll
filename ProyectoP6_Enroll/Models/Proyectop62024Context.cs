using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoP6_Enroll.Models;

public partial class Proyectop62024Context : DbContext
{
    public Proyectop62024Context()
    {
    }

    public Proyectop62024Context(DbContextOptions<Proyectop62024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public virtual DbSet<CourseProfessor> CourseProfessors { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Payement> Payements { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3213E83FB43207E1");

            entity.ToTable("Course");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Faculty)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("faculty");
            entity.Property(e => e.IdCourse)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("idCourse");
            entity.Property(e => e.IdLocation).HasColumnName("idLocation");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdLocationNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCourse775035");
        });

        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => new { e.IdCourse, e.IdEnrollment }).HasName("PK__Course_E__FC16D12A30C707DE");

            entity.ToTable("Course_Enrollment");

            entity.Property(e => e.IdCourse).HasColumnName("idCourse");
            entity.Property(e => e.IdEnrollment).HasColumnName("idEnrollment");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCourse_Enr669160");

            entity.HasOne(d => d.IdEnrollmentNavigation).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.IdEnrollment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCourse_Enr324772");
        });

        modelBuilder.Entity<CourseProfessor>(entity =>
        {
            entity.HasKey(e => new { e.IdCourse, e.IdProfessor }).HasName("PK__Course_P__4D6520CF552AF952");

            entity.ToTable("Course_Professor");

            entity.Property(e => e.IdCourse).HasColumnName("idCourse");
            entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.CourseProfessors)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCourse_Pro107642");

            entity.HasOne(d => d.IdProfessorNavigation).WithMany(p => p.CourseProfessors)
                .HasForeignKey(d => d.IdProfessor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCourse_Pro170388");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enrollme__3213E83F629AD9A6");

            entity.ToTable("Enrollment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdEnrollment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("idEnrollment");
            entity.Property(e => e.IdStudent).HasColumnName("idStudent");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

            entity.HasOne(d => d.IdStudentNavigation).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.IdStudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEnrollment211630");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3213E83F2B25BDC5");

            entity.ToTable("Location");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.IdLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("idLocation");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Payement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payement__3213E83F371F4E0E");

            entity.ToTable("Payement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.IdEnrollment).HasColumnName("idEnrollment");
            entity.Property(e => e.IdPayment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("idPayment");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdEnrollmentNavigation).WithMany(p => p.Payements)
                .HasForeignKey(d => d.IdEnrollment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKPayement381863");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professo__3213E83FF5F27407");

            entity.ToTable("Professor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Assignment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("assignment");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdProfessor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("idProfessor");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3213E83F05B731EC");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate).HasColumnName("birthDate");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdStudent)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("idStudent");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
