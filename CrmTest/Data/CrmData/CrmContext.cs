using System;
using System.Collections.Generic;
using CrmTest.Data.CrmData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrmTest.Data.CrmData;

public partial class CrmContext : DbContext
{
    public CrmContext()
    {
    }

    public CrmContext(DbContextOptions<CrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbsenceReason> AbsenceReasons { get; set; }

    public virtual DbSet<ApprovalRequest> ApprovalRequests { get; set; }

    public virtual DbSet<ApprovalRequestStatus> ApprovalRequestStatuses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }

    public virtual DbSet<LeaveRequestStatus> LeaveRequestStatuses { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Subdivision> Subdivisions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbsenceReason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AbsenceR__3214EC07508AB101");

            entity.ToTable("AbsenceReasons", "crm");

            entity.Property(e => e.Text)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApprovalRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Approval__3214EC07D289CE1D");

            entity.ToTable("ApprovalRequests", "crm");

            entity.HasOne(d => d.Approver).WithMany(p => p.ApprovalRequests)
                .HasForeignKey(d => d.ApproverId)
                .HasConstraintName("FK__ApprovalR__Appro__68536ACF");

            entity.HasOne(d => d.LeaveRequest).WithMany(p => p.ApprovalRequests)
                .HasForeignKey(d => d.LeaveRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ApprovalR__Leave__69478F08");

            entity.HasOne(d => d.Status).WithMany(p => p.ApprovalRequests)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ApprovalR__Statu__6A3BB341");
        });

        modelBuilder.Entity<ApprovalRequestStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Approval__3214EC070F2464D8");

            entity.ToTable("ApprovalRequestStatuses", "crm");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07B16C5816");

            entity.ToTable("Employees", "crm");

            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Photo).HasMaxLength(1);

            entity.HasOne(d => d.PeoplePartner).WithMany(p => p.InversePeoplePartner)
                .HasForeignKey(d => d.PeoplePartnerId)
                .HasConstraintName("FK__Employees__Peopl__5BED93EA");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__Posit__5AF96FB1");

            entity.HasOne(d => d.Subvision).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SubvisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__Subvi__5A054B78");
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeaveReq__3214EC0791BE4000");

            entity.ToTable("LeaveRequests", "crm");

            entity.Property(e => e.Comment)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AbsenceReason).WithMany(p => p.LeaveRequests)
                .HasForeignKey(d => d.AbsenceReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaveRequ__Absen__638EB5B2");

            entity.HasOne(d => d.Employee).WithMany(p => p.LeaveRequests)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LeaveRequ__Emplo__629A9179");
        });

        modelBuilder.Entity<LeaveRequestStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeaveReq__3214EC0774FAB60C");

            entity.ToTable("LeaveRequestStatuses", "crm");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC075FB172A8");

            entity.ToTable("Positions", "crm");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Subdivision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subdivis__3214EC07C6BEAE5F");

            entity.ToTable("Subdivisions", "crm");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
