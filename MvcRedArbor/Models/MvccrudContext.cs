using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MvcRedArbor.Models;

public partial class MvccrudContext : DbContext
{
    public MvccrudContext()
    {
    }

    public MvccrudContext(DbContextOptions<MvccrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<CandidateExperience> CandidateExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.IdCandidate).HasName("PK__Candidat__D5598973E58C0405");

            entity.HasIndex(e => e.Email, "UQ__Candidat__A9D10534ED7F7991").IsUnique();

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CandidateExperience>(entity =>
        {
            entity.HasKey(e => e.IdCandidateExperiences).HasName("PK__Candidat__42305D29DDD3AC61");

            entity.Property(e => e.BeginDate).HasColumnType("datetime");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.Job)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Salary).HasColumnType("numeric(8, 2)");

            entity.HasOne(d => d.IdCandidateNavigation).WithMany(p => p.CandidateExperiences)
                .HasForeignKey(d => d.IdCandidate)
                .HasConstraintName("FK__Candidate__IdCan__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
