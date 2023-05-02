using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Models.Models;

public partial class DpmsContext : DbContext
{
    public DpmsContext()
    {
    }

    public DpmsContext(DbContextOptions<DpmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Companie> Companies { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Plataform> Plataforms { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<TechStack> TechStacks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DELL\\SQLEXPRESS; Database=DPMS; Trusted_Connection=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Companie>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK_Companies");

            entity.ToTable("Companie");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateEnd).HasColumnType("date");
            entity.Property(e => e.DateStart).HasColumnType("date");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Course");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateEnd)
                .HasDefaultValueSql("('1900-01-01')")
                .HasColumnType("date");
            entity.Property(e => e.Path)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('-')");
            entity.Property(e => e.PathCertificated)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('-')");
            entity.Property(e => e.PathImages)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('-')");
            entity.Property(e => e.Plataform)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PlataformNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.Plataform)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Plataform");

            entity.HasMany(d => d.TechStacks).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "RtCourseStack",
                    r => r.HasOne<TechStack>().WithMany()
                        .HasForeignKey("TechStack")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RT_Course_Stack_TechStack"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("Course")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RT_Course_Stack_Course"),
                    j =>
                    {
                        j.HasKey("Course", "TechStack");
                        j.ToTable("RT_Course_Stack");
                        j.IndexerProperty<string>("Course")
                            .HasMaxLength(50)
                            .IsUnicode(false);
                        j.IndexerProperty<string>("TechStack")
                            .HasMaxLength(50)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<Plataform>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Plataform");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK_Projects");

            entity.ToTable("Project");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Others)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Path)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PathImages)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ToPerfect)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.TechStacks).WithMany(p => p.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "RtProjectStack",
                    r => r.HasOne<TechStack>().WithMany()
                        .HasForeignKey("TechStack")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RT_Project_Stack_TechStack"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("Project")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RT_Project_Stack_Project"),
                    j =>
                    {
                        j.HasKey("Project", "TechStack");
                        j.ToTable("RT_Project_Stack");
                        j.IndexerProperty<string>("Project")
                            .HasMaxLength(50)
                            .IsUnicode(false);
                        j.IndexerProperty<string>("TechStack")
                            .HasMaxLength(50)
                            .IsUnicode(false);
                    });
        });

        modelBuilder.Entity<TechStack>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK_Tech");

            entity.ToTable("TechStack");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
