using API.Database.SRO_VT_ACCOUNT;
using Microsoft.EntityFrameworkCore;

namespace API.Database.Context;

public partial class SRO_VT_ACCOUNT : DbContext
{
    public SRO_VT_ACCOUNT()
    {
    }

    public SRO_VT_ACCOUNT(DbContextOptions<SRO_VT_ACCOUNT> options)
        : base(options)
    {
    }

    public virtual DbSet<BOOK> BOOKs { get; set; }

    public virtual DbSet<QuaySoEpoint> QuaySoEpoints { get; set; }

    public virtual DbSet<SK_CharRenameLog> SK_CharRenameLogs { get; set; }

    public virtual DbSet<SK_DownLevelLog> SK_DownLevelLogs { get; set; }

    public virtual DbSet<SK_ITEM_GuardLog> SK_ITEM_GuardLogs { get; set; }

    public virtual DbSet<SK_ItemSaleLog> SK_ItemSaleLogs { get; set; }

    public virtual DbSet<SK_PK_UpdateLog> SK_PK_UpdateLogs { get; set; }

    public virtual DbSet<SK_PackageItemSaleLog> SK_PackageItemSaleLogs { get; set; }

    public virtual DbSet<SK_ResetSkillLog> SK_ResetSkillLogs { get; set; }

    public virtual DbSet<SK_SHL> SK_SHLs { get; set; }

    public virtual DbSet<SK_Silk> SK_Silks { get; set; }

    public virtual DbSet<SK_SilkBuyList> SK_SilkBuyLists { get; set; }

    public virtual DbSet<SK_SilkChange_BY_Web> SK_SilkChange_BY_Webs { get; set; }

    public virtual DbSet<SK_SilkGood> SK_SilkGoods { get; set; }

    public virtual DbSet<SK_SubtractSilk_VA> SK_SubtractSilk_VAs { get; set; }

    public virtual DbSet<SK_gamebang_ip> SK_gamebang_ips { get; set; }

    public virtual DbSet<SR_CharName> SR_CharNames { get; set; }

    public virtual DbSet<SR_ShardCharName> SR_ShardCharNames { get; set; }

    public virtual DbSet<TB_Net2e> TB_Net2es { get; set; }

    public virtual DbSet<TB_Net2e_Bak> TB_Net2e_Baks { get; set; }

    public virtual DbSet<TB_Ref_ItemName> TB_Ref_ItemNames { get; set; }

    public virtual DbSet<TB_User> TB_Users { get; set; }

    public virtual DbSet<TB_User_Bak> TB_User_Baks { get; set; }

    public virtual DbSet<_BlockedUser> _BlockedUsers { get; set; }

    public virtual DbSet<_BlockedUser_bak> _BlockedUser_baks { get; set; }

    public virtual DbSet<_CasDatum> _CasData { get; set; }

    public virtual DbSet<_CasGMChatLog> _CasGMChatLogs { get; set; }

    public virtual DbSet<_LoginLogoutStatistic> _LoginLogoutStatistics { get; set; }

    public virtual DbSet<_ModuleVersion> _ModuleVersions { get; set; }

    public virtual DbSet<_ModuleVersionFile> _ModuleVersionFiles { get; set; }

    public virtual DbSet<_Notice> _Notices { get; set; }

    public virtual DbSet<_OldBlockedUser> _OldBlockedUsers { get; set; }

    public virtual DbSet<_PrivilegedIP> _PrivilegedIPs { get; set; }

    public virtual DbSet<_Punishment> _Punishments { get; set; }

    public virtual DbSet<_RefCountryNameAndCode> _RefCountryNameAndCodes { get; set; }

    public virtual DbSet<_SMCLog> _SMCLogs { get; set; }

    public virtual DbSet<_SecurityDescription> _SecurityDescriptions { get; set; }

    public virtual DbSet<_SecurityDescriptionGroup> _SecurityDescriptionGroups { get; set; }

    public virtual DbSet<_SecurityDescriptionGroupAssign> _SecurityDescriptionGroupAssigns { get; set; }

    public virtual DbSet<_ServiceManagerLog> _ServiceManagerLogs { get; set; }

    public virtual DbSet<_Shard> _Shards { get; set; }

    public virtual DbSet<_ShardCurrentUser> _ShardCurrentUsers { get; set; }

    public virtual DbSet<_ShardService> _ShardServices { get; set; }

    public virtual DbSet<_WriteOutResetPlayTime> _WriteOutResetPlayTimes { get; set; }

    public virtual DbSet<__SiegeFortressStatus__> __SiegeFortressStatus__s { get; set; }

    public virtual DbSet<__TrijobRankingStatus__> __TrijobRankingStatus__s { get; set; }

    public virtual DbSet<__TrijobRanking__> __TrijobRanking__s { get; set; }

    public virtual DbSet<tb_partnerInfo> tb_partnerInfos { get; set; }

    public virtual DbSet<tb_paygate_tran> tb_paygate_trans { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(DatabaseManager.SroVtAccountConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BOOK>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BOOKS");

            entity.Property(e => e.id).ValueGeneratedOnAdd();
            entity.Property(e => e.pubdate).HasColumnType("datetime");
            entity.Property(e => e.synopsis)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<QuaySoEpoint>(entity =>
        {
            entity.ToTable("QuaySoEpoint");

            entity.Property(e => e.CharName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Regdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SourcePoint)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserCash)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SK_CharRenameLog>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__ChangeNameOfChar");

            entity.ToTable("SK_CharRenameLog");

            entity.Property(e => e.new_char)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.old_char)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.server)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.struserid)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.timechange).HasColumnType("datetime");
        });

        modelBuilder.Entity<SK_DownLevelLog>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__DownLevelOfChar");

            entity.ToTable("SK_DownLevelLog");

            entity.Property(e => e.charname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.newlevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.package)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.server)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.struserid)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.timedown).HasColumnType("datetime");
        });

        modelBuilder.Entity<SK_ITEM_GuardLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SK_ITEM_GuardLog");

            entity.Property(e => e.LastGuard).HasColumnType("datetime");
            entity.Property(e => e.autoID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SK_ItemSaleLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SK_ItemSaleLog");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.RegDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<SK_PK_UpdateLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SK_PK_UpdateLog");

            entity.Property(e => e.CharName).HasMaxLength(15);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.RegDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Serial64).HasDefaultValueSql("(0)");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e._Item_BH)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e._NewName)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e._NewPetName)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e._OldPetName)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SK_PackageItemSaleLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SK_PackageItemSaleLog");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.RegDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<SK_ResetSkillLog>(entity =>
        {
            entity.ToTable("SK_ResetSkillLog");

            entity.Property(e => e.NewSkill)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SilkDown)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SkillDown)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TimeReset).HasColumnType("datetime");
            entity.Property(e => e.charname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.server)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.struserid)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SK_SHL>(entity =>
        {
            entity.HasKey(e => e.idx).IsClustered(false);

            entity.ToTable("SK_SHL");

            entity.HasIndex(e => e.JID, "IX_SK_SHL")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.event_time).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<SK_Silk>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SK_Silk");
        });

        modelBuilder.Entity<SK_SilkBuyList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SK_SilkBuyList");

            entity.Property(e => e.AuthDate).HasColumnType("datetime");
            entity.Property(e => e.AuthNumber)
                .HasMaxLength(14)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.BuyNo).ValueGeneratedOnAdd();
            entity.Property(e => e.IP)
                .HasMaxLength(16)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.PGUniqueNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.RegDate).HasColumnType("datetime");
            entity.Property(e => e.SlipPaper)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.srID)
                .HasMaxLength(25)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<SK_SilkChange_BY_Web>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SK_SilkChange_BY_Web");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SK_SilkGood>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CPName)
                .HasMaxLength(36)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.GoodsCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.GoodsName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.RegDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SK_SubtractSilk_VA>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SK_SubtractSilk_VAS");

            entity.Property(e => e.AuthDate).HasColumnType("datetime");
            entity.Property(e => e.AuthNumber)
                .HasMaxLength(14)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.BuyNo).ValueGeneratedOnAdd();
            entity.Property(e => e.IP)
                .HasMaxLength(16)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.PGUniqueNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.RegDate).HasColumnType("datetime");
            entity.Property(e => e.SlipPaper)
                .HasMaxLength(128)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.srID)
                .HasMaxLength(25)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<SK_gamebang_ip>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SK_gamebang_ip");
        });

        modelBuilder.Entity<SR_CharName>(entity =>
        {
            entity.HasKey(e => new { e.UserJID, e.ShardID });

            entity.Property(e => e.CharID_1)
                .HasMaxLength(17)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.CharID_2)
                .HasMaxLength(17)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.CharID_3)
                .HasMaxLength(17)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<SR_ShardCharName>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CharName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<TB_Net2e>(entity =>
        {
            entity.HasKey(e => e.JID);

            entity.ToTable("TB_Net2e");

            entity.Property(e => e.JID).ValueGeneratedNever();
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Class).HasMaxLength(50);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Games)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Inviter)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.LastModification).HasColumnType("datetime");
            entity.Property(e => e.MDK)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sec_act)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecondPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StrUserID)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Time_log).HasColumnType("datetime");
            entity.Property(e => e.WhereKnow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WherePlay).HasMaxLength(50);
            entity.Property(e => e.address).HasMaxLength(100);
            entity.Property(e => e.answer).HasMaxLength(50);
            entity.Property(e => e.certificate_num)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.cid).HasMaxLength(70);
            entity.Property(e => e.mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.postcode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.question).HasMaxLength(70);
            entity.Property(e => e.reg_ip)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.regtime).HasColumnType("datetime");
            entity.Property(e => e.sex)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.strLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_Net2e_Bak>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_Net2e_Bak");

            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Class).HasMaxLength(50);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Games)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Inviter)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.LastModification).HasColumnType("datetime");
            entity.Property(e => e.MDK)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sec_act)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecondPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StrUserID)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Time_log).HasColumnType("datetime");
            entity.Property(e => e.WhereKnow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WherePlay).HasMaxLength(50);
            entity.Property(e => e.address).HasMaxLength(100);
            entity.Property(e => e.answer).HasMaxLength(50);
            entity.Property(e => e.certificate_num)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.cid).HasMaxLength(70);
            entity.Property(e => e.mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.postcode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.question).HasMaxLength(70);
            entity.Property(e => e.reg_ip)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.regtime).HasColumnType("datetime");
            entity.Property(e => e.sex)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.strLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TB_Ref_ItemName>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_Ref_ItemName");

            entity.Property(e => e.ITEM_NAME).HasMaxLength(255);
            entity.Property(e => e.ITEM_NAME_UK).HasMaxLength(255);
        });

        modelBuilder.Entity<TB_User>(entity =>
        {
            entity.HasKey(e => e.JID);

            entity.ToTable("TB_User");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.StrUserID)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Time_log).HasColumnType("datetime");
            entity.Property(e => e.address).HasMaxLength(100);
            entity.Property(e => e.certificate_num)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.postcode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.reg_ip)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.regtime).HasColumnType("datetime");
            entity.Property(e => e.sec_content).HasDefaultValueSql("(3)");
            entity.Property(e => e.sec_primary).HasDefaultValueSql("(3)");
            entity.Property(e => e.sex)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TB_User_Bak>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TB_User_Bak");

            entity.Property(e => e.Birthday).HasColumnType("smalldatetime");
            entity.Property(e => e.Class).HasMaxLength(50);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Games)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JID).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StrUserID)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Time_log).HasColumnType("datetime");
            entity.Property(e => e.WhereKnow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WherePlay)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.address).HasMaxLength(100);
            entity.Property(e => e.answer).HasMaxLength(50);
            entity.Property(e => e.certificate_num)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.cid).HasMaxLength(70);
            entity.Property(e => e.mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.postcode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.question).HasMaxLength(70);
            entity.Property(e => e.reg_ip)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.regtime).HasColumnType("datetime");
            entity.Property(e => e.sex)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.strLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_BlockedUser>(entity =>
        {
            entity.HasKey(e => new { e.UserJID, e.Type }).HasName("PK__BlockedUser__1");

            entity.ToTable("_BlockedUser");

            entity.Property(e => e.UserID)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.timeBegin).HasColumnType("datetime");
            entity.Property(e => e.timeEnd).HasColumnType("datetime");
        });

        modelBuilder.Entity<_BlockedUser_bak>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_BlockedUser_bak");

            entity.Property(e => e.UserID)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.timeBegin).HasColumnType("datetime");
            entity.Property(e => e.timeEnd).HasColumnType("datetime");
        });

        modelBuilder.Entity<_CasDatum>(entity =>
        {
            entity.HasKey(e => e.nSerial).HasName("PK___CasData__0EA330E9");

            entity.Property(e => e.dProcessDate).HasColumnType("datetime");
            entity.Property(e => e.dReportDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.szAnswer)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szCharName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szChatLog)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szMailAddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szMemo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szProcessedGM)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szStatement)
                .HasMaxLength(512)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szTgtCharName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_CasGMChatLog>(entity =>
        {
            entity.HasKey(e => e.nSerial).HasName("PK___CasGMChatLog__0F975522");

            entity.ToTable("_CasGMChatLog");

            entity.Property(e => e.dWritten)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.szCharName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szGM)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szGMChatLog)
                .HasMaxLength(4000)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_LoginLogoutStatistic>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.dLogin, "CIX___Login_Logout_Statistics_dLogin")
                .IsClustered()
                .HasFillFactor(90);

            entity.HasIndex(e => e.nIdx, "IX___Login_Logout_Statistics_nIdx")
                .IsUnique()
                .HasFillFactor(90);

            entity.Property(e => e.dLogin).HasColumnType("smalldatetime");
            entity.Property(e => e.dLogout).HasColumnType("smalldatetime");
            entity.Property(e => e.nIdx).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<_ModuleVersion>(entity =>
        {
            entity.HasKey(e => e.nID)
                .HasName("PK___ModuleVersion__656C112C")
                .IsClustered(false);

            entity.ToTable("_ModuleVersion");

            entity.HasIndex(e => e.nModuleID, "IX__ModuleVersion")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.szDesc)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szVersion)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_ModuleVersionFile>(entity =>
        {
            entity.HasKey(e => e.nID).IsClustered(false);

            entity.ToTable("_ModuleVersionFile");

            entity.HasIndex(e => e.nModuleID, "IX__ModuleVersionFile")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.szFilename)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szPath)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.timeModified).HasColumnType("datetime");
        });

        modelBuilder.Entity<_Notice>(entity =>
        {
            entity.HasKey(e => e.ID).IsClustered(false);

            entity.ToTable("_Notice");

            entity.HasIndex(e => e.ContentID, "IX__Notice")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.Article)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.EditDate).HasColumnType("datetime");
            entity.Property(e => e.Subject)
                .HasMaxLength(80)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_OldBlockedUser>(entity =>
        {
            entity.HasKey(e => e.UserJID).HasName("PK__BlockedUser");

            entity.ToTable("_OldBlockedUser");

            entity.HasIndex(e => e.UserJID, "IX__BlockedUser").HasFillFactor(90);

            entity.Property(e => e.UserJID).ValueGeneratedNever();
            entity.Property(e => e.timeBegin).HasColumnType("datetime");
            entity.Property(e => e.timeEnd).HasColumnType("datetime");
        });

        modelBuilder.Entity<_PrivilegedIP>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_PrivilegedIP");
        });

        modelBuilder.Entity<_Punishment>(entity =>
        {
            entity.HasKey(e => e.SerialNo).IsClustered(false);

            entity.ToTable("_Punishment");

            entity.HasIndex(e => e.UserJID, "IX__Punishment")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.BlockEndTime).HasColumnType("datetime");
            entity.Property(e => e.BlockStartTime).HasColumnType("datetime");
            entity.Property(e => e.CharInfo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.CharName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Executor)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Guide)
                .HasMaxLength(512)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.PosInfo)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.PunishTime).HasColumnType("datetime");
            entity.Property(e => e.RaiseTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<_RefCountryNameAndCode>(entity =>
        {
            entity.HasKey(e => e.code);

            entity.ToTable("_RefCountryNameAndCode");

            entity.Property(e => e.code)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szCountryName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_SMCLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_SMCLog");

            entity.HasIndex(e => e.dLogDate, "IX_SMCLog")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.dLogDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.szLog)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szUserID)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_SecurityDescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_SecurityDescription");

            entity.Property(e => e.nID).ValueGeneratedOnAdd();
            entity.Property(e => e.szDesc)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_SecurityDescriptionGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_SecurityDescriptionGroup");

            entity.Property(e => e.nID).ValueGeneratedOnAdd();
            entity.Property(e => e.szDesc)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Chinese_Taiwan_Stroke_CI_AS");
            entity.Property(e => e.szName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_SecurityDescriptionGroupAssign>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_SecurityDescriptionGroupAssign");
        });

        modelBuilder.Entity<_ServiceManagerLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_ServiceManagerLog");

            entity.HasIndex(e => e.nUserID, "IX__ServiceManagerLog")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.EventTime).HasColumnType("datetime");
            entity.Property(e => e.szLog)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_Shard>(entity =>
        {
            entity.HasKey(e => e.nID).HasName("PK___Shard__7C4F7684");

            entity.ToTable("_Shard");

            entity.Property(e => e.nMaxUser).HasDefaultValueSql("(1000)");
            entity.Property(e => e.szDBConfig)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szDesc)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.szName)
                .HasMaxLength(32)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_ShardCurrentUser>(entity =>
        {
            entity.HasKey(e => e.nID)
                .HasName("PK___ShardCurrentUse__20C1E124")
                .IsClustered(false);

            entity.ToTable("_ShardCurrentUser");

            entity.HasIndex(e => e.nShardID, "IX__ShardCurrentUser")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.dLogDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_ShardService>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_ShardService");
        });

        modelBuilder.Entity<_WriteOutResetPlayTime>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_WriteOutResetPlayTime");

            entity.Property(e => e.LatestResetTime).HasDefaultValueSql("(1)");
        });

        modelBuilder.Entity<__SiegeFortressStatus__>(entity =>
        {
            entity.HasKey(e => new { e.ShardID, e.FortressName });

            entity.ToTable("__SiegeFortressStatus__");

            entity.Property(e => e.FortressName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerAllianceGuildName1)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerAllianceGuildName2)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerAllianceGuildName3)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerAllianceGuildName4)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerAllianceGuildName5)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerAllianceGuildName6)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerAllianceGuildName7)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerAllianceGuildName8)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerGuildMaster)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerGuildName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OwnerUpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<__TrijobRankingStatus__>(entity =>
        {
            entity.HasKey(e => e.ShardID);

            entity.ToTable("__TrijobRankingStatus__");

            entity.Property(e => e.ShardID).ValueGeneratedNever();
            entity.Property(e => e.UpdateTime).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<__TrijobRanking__>(entity =>
        {
            entity.HasKey(e => new { e.ShardID, e.TrijobType, e.RankType, e.Rank });

            entity.ToTable("__TrijobRanking__");

            entity.HasIndex(e => e.NickName, "IX___TrijobRanking__").HasFillFactor(90);

            entity.Property(e => e.NickName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tb_partnerInfo>(entity =>
        {
            entity.HasKey(e => e.partnerID);

            entity.ToTable("tb_partnerInfo");

            entity.Property(e => e.partnerID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.balance).HasDefaultValueSql("(0)");
            entity.Property(e => e.partnerName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.partnerPass)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.udate).HasColumnType("datetime");
        });

        modelBuilder.Entity<tb_paygate_tran>(entity =>
        {
            entity.HasKey(e => e.trans_ID);

            entity.ToTable(tb => tb.HasTrigger("trgPaygate_Trans_Log"));

            entity.Property(e => e.account_id)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.afterMoney).HasDefaultValueSql("(0)");
            entity.Property(e => e.bank_id)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.beforeMoney).HasDefaultValueSql("(0)");
            entity.Property(e => e.moneyValue).HasDefaultValueSql("(0)");
            entity.Property(e => e.order_no)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.trans_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.trans_type).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
