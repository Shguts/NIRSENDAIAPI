﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models;

public partial class NirsendaiContext : DbContext
{
    public NirsendaiContext()
    {
    }

    public NirsendaiContext(DbContextOptions<NirsendaiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ball> Balls { get; set; }

    public virtual DbSet<Critery> Criteries { get; set; }

    public virtual DbSet<FileUser> FileUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Zayavl> Zayavls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UIGEPJ3\\SQLEXPRESS;Database=nirsendai;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ball>(entity =>
        {
            entity.HasKey(e => new { e.Login, e.IdCriterie, e.IdZayv }).HasName("PK_balls_1");

            entity.ToTable("balls");

            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.IdCriterie).HasColumnName("id_criterie");
            entity.Property(e => e.IdZayv).HasColumnName("id_zayv");
            entity.Property(e => e.Mark).HasColumnName("mark");

            entity.HasOne(d => d.IdCriterieNavigation).WithMany(p => p.Balls)
                .HasForeignKey(d => d.IdCriterie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_balls_Criteries1");

            entity.HasOne(d => d.LoginNavigation).WithMany(p => p.Balls)
                .HasForeignKey(d => d.Login)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_balls_Users1");
        });

        modelBuilder.Entity<Critery>(entity =>
        {
            entity.HasKey(e => e.IdCriterie);

            entity.Property(e => e.IdCriterie)
                .ValueGeneratedNever()
                .HasColumnName("id_criterie");
            entity.Property(e => e.NameCriterie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_criterie");
        });

        modelBuilder.Entity<FileUser>(entity =>
        {
            entity.HasKey(e => e.IdFile);

            entity.Property(e => e.IdFile)
                .ValueGeneratedNever()
                .HasColumnName("id_file");
            entity.Property(e => e.FileData).HasColumnName("file_data");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .HasColumnName("file_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");

            entity.HasOne(d => d.LoginNavigation).WithMany(p => p.FileUsers)
                .HasForeignKey(d => d.Login)
                .HasConstraintName("FK_FileUsers_Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdD);

            entity.ToTable("roles");

            entity.Property(e => e.IdD)
                .ValueGeneratedNever()
                .HasColumnName("id_d");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .HasColumnName("name_role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Login);

            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.CategoryMo)
                .HasMaxLength(50)
                .HasColumnName("categoryMO");
            entity.Property(e => e.DateBirth)
                .HasColumnType("date")
                .HasColumnName("date_birth");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Passwd)
                .HasMaxLength(50)
                .HasColumnName("passwd");
            entity.Property(e => e.Region)
                .HasMaxLength(250)
                .HasColumnName("region");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .HasColumnName("second_name");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_roles");
        });

        modelBuilder.Entity<Zayavl>(entity =>
        {
            entity.HasKey(e => new { e.IdZayv, e.IdFile }).HasName("PK_zayavl_1");

            entity.ToTable("zayavl");

            entity.Property(e => e.IdZayv).HasColumnName("id_zayv");
            entity.Property(e => e.IdFile).HasColumnName("id_file");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");

            entity.HasOne(d => d.IdFileNavigation).WithMany(p => p.Zayavls)
                .HasForeignKey(d => d.IdFile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_zayavl_FileUsers1");

            entity.HasOne(d => d.LoginNavigation).WithMany(p => p.Zayavls)
                .HasForeignKey(d => d.Login)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_zayavl_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
