using System.Data.Entity;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class SRO_VT_ACCOUNT : DbContext
    {
        public SRO_VT_ACCOUNT()
            : base(DatabaseManager.SroVtAccountConnectionString)
        {
        }

        public virtual DbSet<C__SiegeFortressStatus__> C__SiegeFortressStatus__ { get; set; }
        public virtual DbSet<C__TrijobRanking__> C__TrijobRanking__ { get; set; }
        public virtual DbSet<C__TrijobRankingStatus__> C__TrijobRankingStatus__ { get; set; }
        public virtual DbSet<C_BlockedUser> C_BlockedUser { get; set; }
        public virtual DbSet<C_CasData> C_CasData { get; set; }
        public virtual DbSet<C_CasGMChatLog> C_CasGMChatLog { get; set; }
        public virtual DbSet<C_ModuleVersion> C_ModuleVersion { get; set; }
        public virtual DbSet<C_ModuleVersionFile> C_ModuleVersionFile { get; set; }
        public virtual DbSet<C_Notice> C_Notice { get; set; }
        public virtual DbSet<C_OldBlockedUser> C_OldBlockedUser { get; set; }
        public virtual DbSet<C_Punishment> C_Punishment { get; set; }
        public virtual DbSet<C_RefCountryNameAndCode> C_RefCountryNameAndCode { get; set; }
        public virtual DbSet<C_Shard> C_Shard { get; set; }
        public virtual DbSet<C_ShardCurrentUser> C_ShardCurrentUser { get; set; }
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<QuaySoEpoint> QuaySoEpoints { get; set; }
        public virtual DbSet<SK_CharRenameLog> SK_CharRenameLog { get; set; }
        public virtual DbSet<SK_DownLevelLog> SK_DownLevelLog { get; set; }
        public virtual DbSet<SK_ResetSkillLog> SK_ResetSkillLog { get; set; }
        public virtual DbSet<SK_SHL> SK_SHL { get; set; }
        public virtual DbSet<SR_CharNames> SR_CharNames { get; set; }
        public virtual DbSet<TB_Net2e> TB_Net2e { get; set; }
        public virtual DbSet<tb_partnerInfo> tb_partnerInfo { get; set; }
        public virtual DbSet<tb_paygate_trans> tb_paygate_trans { get; set; }
        public virtual DbSet<TB_User> TB_User { get; set; }
        public virtual DbSet<C_BlockedUser_bak> C_BlockedUser_bak { get; set; }
        public virtual DbSet<C_LoginLogoutStatistics> C_LoginLogoutStatistics { get; set; }
        public virtual DbSet<C_PrivilegedIP> C_PrivilegedIP { get; set; }
        public virtual DbSet<C_SecurityDescription> C_SecurityDescription { get; set; }
        public virtual DbSet<C_SecurityDescriptionGroup> C_SecurityDescriptionGroup { get; set; }
        public virtual DbSet<C_SecurityDescriptionGroupAssign> C_SecurityDescriptionGroupAssign { get; set; }
        public virtual DbSet<C_ServiceManagerLog> C_ServiceManagerLog { get; set; }
        public virtual DbSet<C_ShardService> C_ShardService { get; set; }
        public virtual DbSet<C_SMCLog> C_SMCLog { get; set; }
        public virtual DbSet<C_WriteOutResetPlayTime> C_WriteOutResetPlayTime { get; set; }
        public virtual DbSet<BOOK> BOOKS { get; set; }
        public virtual DbSet<SK_gamebang_ip> SK_gamebang_ip { get; set; }
        public virtual DbSet<SK_ITEM_GuardLog> SK_ITEM_GuardLog { get; set; }
        public virtual DbSet<SK_ItemSaleLog> SK_ItemSaleLog { get; set; }
        public virtual DbSet<SK_PackageItemSaleLog> SK_PackageItemSaleLog { get; set; }
        public virtual DbSet<SK_PK_UpdateLog> SK_PK_UpdateLog { get; set; }
        public virtual DbSet<SK_Silk> SK_Silk { get; set; }
        public virtual DbSet<SK_SilkBuyList> SK_SilkBuyList { get; set; }
        public virtual DbSet<SK_SilkChange_BY_Web> SK_SilkChange_BY_Web { get; set; }
        public virtual DbSet<SK_SilkGoods> SK_SilkGoods { get; set; }
        public virtual DbSet<SK_SubtractSilk_VAS> SK_SubtractSilk_VAS { get; set; }
        public virtual DbSet<SR_ShardCharNames> SR_ShardCharNames { get; set; }
        public virtual DbSet<TB_Net2e_Bak> TB_Net2e_Bak { get; set; }
        public virtual DbSet<TB_User_Bak> TB_User_Bak { get; set; }
        public virtual DbSet<tmp> tmps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.FortressName)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerGuildName)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerGuildMaster)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerAllianceGuildName1)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerAllianceGuildName2)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerAllianceGuildName3)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerAllianceGuildName4)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerAllianceGuildName5)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerAllianceGuildName6)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerAllianceGuildName7)
                .IsUnicode(false);

            modelBuilder.Entity<C__SiegeFortressStatus__>()
                .Property(e => e.OwnerAllianceGuildName8)
                .IsUnicode(false);

            modelBuilder.Entity<C__TrijobRanking__>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<C_BlockedUser>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasData>()
                .Property(e => e.szCharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasData>()
                .Property(e => e.szTgtCharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasData>()
                .Property(e => e.szMailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasData>()
                .Property(e => e.szStatement)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasData>()
                .Property(e => e.szProcessedGM)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasData>()
                .Property(e => e.szMemo)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasData>()
                .Property(e => e.szAnswer)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasData>()
                .Property(e => e.szChatLog)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasGMChatLog>()
                .Property(e => e.szGM)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasGMChatLog>()
                .Property(e => e.szCharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_CasGMChatLog>()
                .Property(e => e.szGMChatLog)
                .IsUnicode(false);

            modelBuilder.Entity<C_ModuleVersion>()
                .Property(e => e.szVersion)
                .IsUnicode(false);

            modelBuilder.Entity<C_ModuleVersion>()
                .Property(e => e.szDesc)
                .IsUnicode(false);

            modelBuilder.Entity<C_ModuleVersionFile>()
                .Property(e => e.szFilename)
                .IsUnicode(false);

            modelBuilder.Entity<C_ModuleVersionFile>()
                .Property(e => e.szPath)
                .IsUnicode(false);

            modelBuilder.Entity<C_Notice>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<C_Notice>()
                .Property(e => e.Article)
                .IsUnicode(false);

            modelBuilder.Entity<C_Punishment>()
                .Property(e => e.Executor)
                .IsUnicode(false);

            modelBuilder.Entity<C_Punishment>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Punishment>()
                .Property(e => e.CharInfo)
                .IsUnicode(false);

            modelBuilder.Entity<C_Punishment>()
                .Property(e => e.PosInfo)
                .IsUnicode(false);

            modelBuilder.Entity<C_Punishment>()
                .Property(e => e.Guide)
                .IsUnicode(false);

            modelBuilder.Entity<C_Punishment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCountryNameAndCode>()
                .Property(e => e.code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCountryNameAndCode>()
                .Property(e => e.szCountryName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Shard>()
                .Property(e => e.szName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Shard>()
                .Property(e => e.szDesc)
                .IsUnicode(false);

            modelBuilder.Entity<C_Shard>()
                .Property(e => e.szDBConfig)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.property)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperty>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<QuaySoEpoint>()
                .Property(e => e.UserCash)
                .IsUnicode(false);

            modelBuilder.Entity<QuaySoEpoint>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<QuaySoEpoint>()
                .Property(e => e.SourcePoint)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SK_CharRenameLog>()
                .Property(e => e.struserid)
                .IsUnicode(false);

            modelBuilder.Entity<SK_CharRenameLog>()
                .Property(e => e.old_char)
                .IsUnicode(false);

            modelBuilder.Entity<SK_CharRenameLog>()
                .Property(e => e.new_char)
                .IsUnicode(false);

            modelBuilder.Entity<SK_CharRenameLog>()
                .Property(e => e.server)
                .IsUnicode(false);

            modelBuilder.Entity<SK_DownLevelLog>()
                .Property(e => e.struserid)
                .IsUnicode(false);

            modelBuilder.Entity<SK_DownLevelLog>()
                .Property(e => e.charname)
                .IsUnicode(false);

            modelBuilder.Entity<SK_DownLevelLog>()
                .Property(e => e.package)
                .IsUnicode(false);

            modelBuilder.Entity<SK_DownLevelLog>()
                .Property(e => e.newlevel)
                .IsUnicode(false);

            modelBuilder.Entity<SK_DownLevelLog>()
                .Property(e => e.server)
                .IsUnicode(false);

            modelBuilder.Entity<SK_ResetSkillLog>()
                .Property(e => e.struserid)
                .IsUnicode(false);

            modelBuilder.Entity<SK_ResetSkillLog>()
                .Property(e => e.charname)
                .IsUnicode(false);

            modelBuilder.Entity<SK_ResetSkillLog>()
                .Property(e => e.SkillDown)
                .IsUnicode(false);

            modelBuilder.Entity<SK_ResetSkillLog>()
                .Property(e => e.NewSkill)
                .IsUnicode(false);

            modelBuilder.Entity<SK_ResetSkillLog>()
                .Property(e => e.SilkDown)
                .IsUnicode(false);

            modelBuilder.Entity<SK_ResetSkillLog>()
                .Property(e => e.server)
                .IsUnicode(false);

            modelBuilder.Entity<SR_CharNames>()
                .Property(e => e.CharID_1)
                .IsUnicode(false);

            modelBuilder.Entity<SR_CharNames>()
                .Property(e => e.CharID_2)
                .IsUnicode(false);

            modelBuilder.Entity<SR_CharNames>()
                .Property(e => e.CharID_3)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.StrUserID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.SecondPassword)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.MDK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.certificate_num)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.postcode)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.reg_ip)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.WhereKnow)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.Reference)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.Games)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.strLevel)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.Inviter)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e>()
                .Property(e => e.Sec_act)
                .IsUnicode(false);

            modelBuilder.Entity<tb_partnerInfo>()
                .Property(e => e.partnerID)
                .IsUnicode(false);

            modelBuilder.Entity<tb_partnerInfo>()
                .Property(e => e.partnerName)
                .IsUnicode(false);

            modelBuilder.Entity<tb_partnerInfo>()
                .Property(e => e.partnerPass)
                .IsUnicode(false);

            modelBuilder.Entity<tb_paygate_trans>()
                .Property(e => e.bank_id)
                .IsUnicode(false);

            modelBuilder.Entity<tb_paygate_trans>()
                .Property(e => e.account_id)
                .IsUnicode(false);

            modelBuilder.Entity<tb_paygate_trans>()
                .Property(e => e.order_no)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User>()
                .Property(e => e.StrUserID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User>()
                .Property(e => e.sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TB_User>()
                .Property(e => e.certificate_num)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User>()
                .Property(e => e.postcode)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User>()
                .Property(e => e.reg_ip)
                .IsUnicode(false);

            modelBuilder.Entity<C_BlockedUser_bak>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<C_SecurityDescription>()
                .Property(e => e.szName)
                .IsUnicode(false);

            modelBuilder.Entity<C_SecurityDescription>()
                .Property(e => e.szDesc)
                .IsUnicode(false);

            modelBuilder.Entity<C_SecurityDescriptionGroup>()
                .Property(e => e.szName)
                .IsUnicode(false);

            modelBuilder.Entity<C_SecurityDescriptionGroup>()
                .Property(e => e.szDesc)
                .IsUnicode(false);

            modelBuilder.Entity<C_ServiceManagerLog>()
                .Property(e => e.szLog)
                .IsUnicode(false);

            modelBuilder.Entity<C_SMCLog>()
                .Property(e => e.szUserID)
                .IsUnicode(false);

            modelBuilder.Entity<C_SMCLog>()
                .Property(e => e.szLog)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.synopsis)
                .IsUnicode(false);

            modelBuilder.Entity<SK_PK_UpdateLog>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SK_PK_UpdateLog>()
                .Property(e => e.ServiceCode)
                .IsUnicode(false);

            modelBuilder.Entity<SK_PK_UpdateLog>()
                .Property(e => e.C_NewName)
                .IsUnicode(false);

            modelBuilder.Entity<SK_PK_UpdateLog>()
                .Property(e => e.C_OldPetName)
                .IsUnicode(false);

            modelBuilder.Entity<SK_PK_UpdateLog>()
                .Property(e => e.C_NewPetName)
                .IsUnicode(false);

            modelBuilder.Entity<SK_PK_UpdateLog>()
                .Property(e => e.C_Item_BH)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SilkBuyList>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SilkBuyList>()
                .Property(e => e.PGUniqueNo)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SilkBuyList>()
                .Property(e => e.AuthNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SilkBuyList>()
                .Property(e => e.srID)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SilkBuyList>()
                .Property(e => e.SlipPaper)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SilkBuyList>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SilkGoods>()
                .Property(e => e.GoodsCode)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SilkGoods>()
                .Property(e => e.GoodsName)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SilkGoods>()
                .Property(e => e.CPName)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SubtractSilk_VAS>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SubtractSilk_VAS>()
                .Property(e => e.PGUniqueNo)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SubtractSilk_VAS>()
                .Property(e => e.AuthNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SubtractSilk_VAS>()
                .Property(e => e.srID)
                .IsUnicode(false);

            modelBuilder.Entity<SK_SubtractSilk_VAS>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<SR_ShardCharNames>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.StrUserID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.SecondPassword)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.MDK)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.certificate_num)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.postcode)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.reg_ip)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.WhereKnow)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.Reference)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.Games)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.strLevel)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.Inviter)
                .IsUnicode(false);

            modelBuilder.Entity<TB_Net2e_Bak>()
                .Property(e => e.Sec_act)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.StrUserID)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.certificate_num)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.postcode)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.reg_ip)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.WherePlay)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.WhereKnow)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.Reference)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.Games)
                .IsUnicode(false);

            modelBuilder.Entity<TB_User_Bak>()
                .Property(e => e.strLevel)
                .IsUnicode(false);

            modelBuilder.Entity<tmp>()
                .Property(e => e.UserID)
                .IsUnicode(false);
        }
    }
}
