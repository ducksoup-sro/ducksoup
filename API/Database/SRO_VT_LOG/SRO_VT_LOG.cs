using System.Data.Entity;

namespace API.Database.SRO_VT_LOG
{
    public partial class SRO_VT_LOG : DbContext
    {
        public SRO_VT_LOG()
            : base(DatabaseManager.SroVtLogConnectionString)
        {
        }

        public virtual DbSet<C_FortressStatus> C_FortressStatus { get; set; }
        public virtual DbSet<C_LogServerEvent> C_LogServerEvent { get; set; }
        public virtual DbSet<C_OnlineOffline> C_OnlineOffline { get; set; }
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<loginhistory> loginhistories { get; set; }
        public virtual DbSet<onlineofflinelog> onlineofflinelogs { get; set; }
        public virtual DbSet<pvp_records> pvp_records { get; set; }
        public virtual DbSet<uniquekilllog> uniquekilllogs { get; set; }
        public virtual DbSet<C_LevelReward> C_LevelReward { get; set; }
        public virtual DbSet<C_LogCashItem> C_LogCashItem { get; set; }
        public virtual DbSet<C_LogEventChar> C_LogEventChar { get; set; }
        public virtual DbSet<C_LogEventItem> C_LogEventItem { get; set; }
        public virtual DbSet<C_LogEventSiegeFortress> C_LogEventSiegeFortress { get; set; }
        public virtual DbSet<C_LogSchedule> C_LogSchedule { get; set; }
        public virtual DbSet<C__StatisticsGoldIncrementData__> C__StatisticsGoldIncrementData__ { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C_LogServerEvent>()
                .Property(e => e.strDesc)
                .IsUnicode(false);

            modelBuilder.Entity<C_OnlineOffline>()
                .Property(e => e.Charname)
                .IsUnicode(false);

            modelBuilder.Entity<C_OnlineOffline>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<C_OnlineOffline>()
                .Property(e => e.mOnline)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.property)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<C_LogEventChar>()
                .Property(e => e.EventPos)
                .IsUnicode(false);

            modelBuilder.Entity<C_LogEventChar>()
                .Property(e => e.strDesc)
                .IsUnicode(false);

            modelBuilder.Entity<C_LogEventItem>()
                .Property(e => e.EventPos)
                .IsUnicode(false);

            modelBuilder.Entity<C_LogEventItem>()
                .Property(e => e.strDesc)
                .IsUnicode(false);

            modelBuilder.Entity<C_LogEventSiegeFortress>()
                .Property(e => e.strDesc)
                .IsUnicode(false);

            modelBuilder.Entity<C_LogSchedule>()
                .Property(e => e.ServerType)
                .IsUnicode(false);

            modelBuilder.Entity<C_LogSchedule>()
                .Property(e => e.ScheduleDefine)
                .IsUnicode(false);

            modelBuilder.Entity<C_LogSchedule>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
