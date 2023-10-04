using API.Database.DuckSoup;
using Database;
using Microsoft.EntityFrameworkCore;

namespace API.Database.Context;

public partial class DuckSoup : DuckContext
{
    public virtual DbSet<Database.DuckSoup.Event> Events { get; set; }

    public virtual DbSet<GlobalSetting> GlobalSettings { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Database.DuckSoup.Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK_dbo.Event");

            entity.ToTable("Event");
        });

        modelBuilder.Entity<GlobalSetting>(entity =>
        {
            entity.HasKey(e => e.SettingsId).HasName("PK_dbo.GlobalSetting");

            entity.ToTable("GlobalSetting");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.MachineId).HasName("PK_dbo.Machine");

            entity.ToTable("Machine");

            entity.Property(e => e.Address).HasMaxLength(15);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK_dbo.Service");

            entity.ToTable("Service");

            entity.HasIndex(e => e.LocalMachine_MachineId, "IX_LocalMachine_MachineId");

            entity.HasIndex(e => e.RemoteMachine_MachineId, "IX_RemoteMachine_MachineId");

            entity.HasIndex(e => e.SpoofMachine_MachineId, "IX_SpoofMachine_MachineId");

            entity.HasOne(d => d.LocalMachine_Machine).WithMany(p => p.ServiceLocalMachine_Machines)
                .HasForeignKey(d => d.LocalMachine_MachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Service_dbo.Machine_LocalMachine_MachineId");

            entity.HasOne(d => d.RemoteMachine_Machine).WithMany(p => p.ServiceRemoteMachine_Machines)
                .HasForeignKey(d => d.RemoteMachine_MachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Service_dbo.Machine_RemoteMachine_MachineId");

            entity.HasOne(d => d.SpoofMachine_Machine).WithMany(p => p.ServiceSpoofMachine_Machines)
                .HasForeignKey(d => d.SpoofMachine_MachineId)
                .HasConstraintName("FK_dbo.Service_dbo.Machine_SpoofMachine_MachineId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.userId).HasName("PK_dbo.User");

            entity.ToTable("User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}