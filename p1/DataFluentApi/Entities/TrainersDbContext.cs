using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataFluentApi.Entities;

public partial class TrainersDbContext : DbContext
{
    public TrainersDbContext()
    {
    }

    public TrainersDbContext(DbContextOptions<TrainersDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TrainerCompany> TrainerCompanies { get; set; }

    public virtual DbSet<TrainerDetail> TrainerDetails { get; set; }

    public virtual DbSet<TrainerEducation> TrainerEducations { get; set; }

    public virtual DbSet<TrainerLocation> TrainerLocations { get; set; }

    public virtual DbSet<TrainerSkill> TrainerSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Manoj;Database=TrainersDb;User Id=test; Password=pass123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrainerCompany>(entity =>
        {
            entity.ToTable("trainer_company");

            entity.Property(e => e.Companyname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("companyname");
            entity.Property(e => e.Endyear)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("endyear");
            entity.Property(e => e.Startyear)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("startyear");
            entity.Property(e => e.Title)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Trainercompanyid).HasColumnName("trainercompanyid");

            entity.HasOne(d => d.Trainercompany).WithMany(p => p.TrainerCompanies)
                .HasForeignKey(d => d.Trainercompanyid)
                .HasConstraintName("FK_trainer_company_id");
        });

        modelBuilder.Entity<TrainerDetail>(entity =>
        {
            entity.HasKey(e => e.Trainerid).HasName("PK_trainer_id");

            entity.ToTable("trainer_details");

            entity.Property(e => e.Trainerid)
                .ValueGeneratedNever()
                .HasColumnName("trainerid");
            entity.Property(e => e.Aboutme)
                .IsUnicode(false)
                .HasColumnName("aboutme");
            entity.Property(e => e.Age)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("website");
        });

        modelBuilder.Entity<TrainerEducation>(entity =>
        {
            entity.ToTable("trainer_education");

            entity.Property(e => e.Degreename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("degreename");
            entity.Property(e => e.Enddate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("enddate");
            entity.Property(e => e.Gpa)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("gpa");
            entity.Property(e => e.Institute)
                .IsUnicode(false)
                .HasColumnName("institute");
            entity.Property(e => e.Startdate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("startdate");
            entity.Property(e => e.Trainereducationid).HasColumnName("trainereducationid");

            entity.HasOne(d => d.Trainereducation).WithMany(p => p.TrainerEducations)
                .HasForeignKey(d => d.Trainereducationid)
                .HasConstraintName("FK_trainer_education_id");
        });

        modelBuilder.Entity<TrainerLocation>(entity =>
        {
            entity.ToTable("trainer_location");

            entity.HasIndex(e => e.Trainerlocationid, "UQ__trainer___482A24FE973CB35C").IsUnique();

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Trainerlocationid).HasColumnName("trainerlocationid");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("zipcode");

            entity.HasOne(d => d.Trainerlocation).WithOne(p => p.TrainerLocation)
                .HasForeignKey<TrainerLocation>(d => d.Trainerlocationid)
                .HasConstraintName("FK_trainer_location_id");
        });

        modelBuilder.Entity<TrainerSkill>(entity =>
        {
            entity.ToTable("trainer_skill");

            entity.Property(e => e.Skill)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skill");
            entity.Property(e => e.Trainerskillid).HasColumnName("trainerskillid");

            entity.HasOne(d => d.Trainerskill).WithMany(p => p.TrainerSkills)
                .HasForeignKey(d => d.Trainerskillid)
                .HasConstraintName("FK_trainer_skill_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
