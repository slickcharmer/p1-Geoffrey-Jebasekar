using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer.Entities;

public partial class TutorAppContext : DbContext
{
    public TutorAppContext()
    {
    }

    public TutorAppContext(DbContextOptions<TutorAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Signup> Signups { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\Project-1; Database=TutorApp; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_COMPANIES");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("companyName");
            entity.Property(e => e.Emailid)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("emailid");
            entity.Property(e => e.Experience).HasColumnName("experience");
            entity.Property(e => e.Location)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Email).WithMany(p => p.Companies)
                .HasForeignKey(d => d.Emailid)
                .HasConstraintName("FK_Companies");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EDUCATION");

            entity.ToTable("Education");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EducationType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("educationType");
            entity.Property(e => e.Emailid)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("emailid");
            entity.Property(e => e.EndYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("endYear");
            entity.Property(e => e.InstituteName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("instituteName");
            entity.Property(e => e.Percentage)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("percentage");
            entity.Property(e => e.StartYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("startYear");
            entity.Property(e => e.Stream)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("stream");

            entity.HasOne(d => d.Email).WithMany(p => p.Educations)
                .HasForeignKey(d => d.Emailid)
                .HasConstraintName("FK_Education");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Emailid).HasName("PK_LOGIN");

            entity.ToTable("Login");

            entity.Property(e => e.Emailid)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("emailid");
            entity.Property(e => e.Password)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.Email).WithOne(p => p.Login)
                .HasForeignKey<Login>(d => d.Emailid)
                .HasConstraintName("FK_Login");
        });

        modelBuilder.Entity<Signup>(entity =>
        {
            entity.HasKey(e => e.EmailId);

            entity.ToTable("Signup");

            entity.Property(e => e.EmailId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("emailId");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Firstname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phoneno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phoneno");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SKILLS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Emailid)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("emailid");
            entity.Property(e => e.Profeciency).HasColumnName("profeciency");
            entity.Property(e => e.Skill1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("skill");

            entity.HasOne(d => d.Email).WithMany(p => p.Skills)
                .HasForeignKey(d => d.Emailid)
                .HasConstraintName("FK_Skills");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
