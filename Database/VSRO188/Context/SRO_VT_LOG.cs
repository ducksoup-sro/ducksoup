using API.Database.SRO_VT_LOG;
using Microsoft.EntityFrameworkCore;

namespace API.Database.Context;

public partial class SRO_VT_LOG : DbContext
{
    public SRO_VT_LOG()
    {
    }

    public SRO_VT_LOG(DbContextOptions<SRO_VT_LOG> options)
        : base(options)
    {
    }

    public virtual DbSet<_LogCashItem> _LogCashItems { get; set; }

    public virtual DbSet<_LogEventChar> _LogEventChars { get; set; }

    public virtual DbSet<_LogEventItem> _LogEventItems { get; set; }

    public virtual DbSet<_LogEventSiegeFortress> _LogEventSiegeFortresses { get; set; }

    public virtual DbSet<_LogSchedule> _LogSchedules { get; set; }

    public virtual DbSet<_LogServerEvent> _LogServerEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(DatabaseManager.SroVtLogConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<_LogCashItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_LogCashItem");

            entity.HasIndex(e => e.RefItemID, "IX__LogCashItem").HasFillFactor(90);

            entity.HasIndex(e => e.Serial64, "IX__LogCashItemSerial").HasFillFactor(90);

            entity.Property(e => e.EventTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<_LogEventChar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_LogEventChar");

            entity.HasIndex(e => e.CharID, "IX__LogEventChar").HasFillFactor(90);

            entity.Property(e => e.EventPos)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.EventTime).HasColumnType("datetime");
            entity.Property(e => e.strDesc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_LogEventItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_LogEventItem");

            entity.HasIndex(e => e.CharID, "IX__LogEventItem").HasFillFactor(90);

            entity.HasIndex(e => e.Serial64, "IX__LogEventItemSerial").HasFillFactor(90);

            entity.Property(e => e.EventPos)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.EventTime).HasColumnType("datetime");
            entity.Property(e => e.Gold).HasDefaultValueSql("(0)");
            entity.Property(e => e.strDesc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_LogEventSiegeFortress>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_LogEventSiegeFortress");

            entity.Property(e => e.EventTime).HasColumnType("datetime");
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.strDesc)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_LogSchedule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_LogSchedule");

            entity.HasIndex(e => e.OccureTime, "CX_LOG_SCHEDULE_OCCURETIME")
                .IsClustered()
                .HasFillFactor(71);

            entity.HasIndex(e => e.ID, "IX_LOG_SCHEDULE_IDX").HasFillFactor(71);

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.OccureTime).HasColumnType("datetime");
            entity.Property(e => e.ScheduleDefine)
                .HasMaxLength(124)
                .IsUnicode(false);
            entity.Property(e => e.ServerType)
                .HasMaxLength(124)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_LogServerEvent>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK___LogServerEvent__300424B4");

            entity.ToTable("_LogServerEvent");

            entity.HasIndex(e => e.EventTime, "IX_LogServerEvent_EventTime").HasFillFactor(90);

            entity.HasIndex(e => e.ServerEventID, "IX_LogServerEvent_ServerEventID").HasFillFactor(90);

            entity.Property(e => e.EventTime).HasColumnType("datetime");
            entity.Property(e => e.strDesc)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
