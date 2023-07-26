using Database.VSRO188.SRO_VT_SHARD;
using Microsoft.EntityFrameworkCore;

namespace Database.VSRO188.Context;

public partial class SRO_VT_SHARD : DuckContext
{
    public SRO_VT_SHARD()
    {
    }

    public virtual DbSet<Item_Quay_TNET> Item_Quay_TNETs { get; set; }

    public virtual DbSet<Tab_DBSafe_CheckState> Tab_DBSafe_CheckStates { get; set; }

    public virtual DbSet<Tab_RefAISkill> Tab_RefAISkills { get; set; }

    public virtual DbSet<Tab_RefHive> Tab_RefHives { get; set; }

    public virtual DbSet<Tab_RefNest> Tab_RefNests { get; set; }

    public virtual DbSet<Tab_RefRanking_HunterActivity> Tab_RefRanking_HunterActivities { get; set; }

    public virtual DbSet<Tab_RefRanking_HunterContribution> Tab_RefRanking_HunterContributions { get; set; }

    public virtual DbSet<Tab_RefRanking_RobberActivity> Tab_RefRanking_RobberActivities { get; set; }

    public virtual DbSet<Tab_RefRanking_RobberContribution> Tab_RefRanking_RobberContributions { get; set; }

    public virtual DbSet<Tab_RefRanking_TraderActivity> Tab_RefRanking_TraderActivities { get; set; }

    public virtual DbSet<Tab_RefRanking_TraderContribution> Tab_RefRanking_TraderContributions { get; set; }

    public virtual DbSet<Tab_RefSpawnToolVersion> Tab_RefSpawnToolVersions { get; set; }

    public virtual DbSet<Tab_RefTactic> Tab_RefTactics { get; set; }

    public virtual DbSet<_AccountJID> _AccountJIDs { get; set; }

    public virtual DbSet<_AlliedClan> _AlliedClans { get; set; }

    public virtual DbSet<_AssociationReputation> _AssociationReputations { get; set; }

    public virtual DbSet<_BindingOptionWithItem> _BindingOptionWithItems { get; set; }

    public virtual DbSet<_BlackNameList> _BlackNameLists { get; set; }

    public virtual DbSet<_BlockedWhisperer> _BlockedWhisperers { get; set; }

    public virtual DbSet<_Char> _Chars { get; set; }

    public virtual DbSet<_CharCO> _CharCOs { get; set; }

    public virtual DbSet<_CharCollectionBook> _CharCollectionBooks { get; set; }

    public virtual DbSet<_CharInstanceWorldDatum> _CharInstanceWorldData { get; set; }

    public virtual DbSet<_CharNameList> _CharNameLists { get; set; }

    public virtual DbSet<_CharNickNameList> _CharNickNameLists { get; set; }

    public virtual DbSet<_CharQuest> _CharQuests { get; set; }

    public virtual DbSet<_CharSkill> _CharSkills { get; set; }

    public virtual DbSet<_CharSkillMastery> _CharSkillMasteries { get; set; }

    public virtual DbSet<_CharTrijob> _CharTrijobs { get; set; }

    public virtual DbSet<_CharTrijobSafeTrade> _CharTrijobSafeTrades { get; set; }

    public virtual DbSet<_Chest> _Chests { get; set; }

    public virtual DbSet<_ChestInfo> _ChestInfos { get; set; }

    public virtual DbSet<_ClientConfig> _ClientConfigs { get; set; }

    public virtual DbSet<_DeletedChar> _DeletedChars { get; set; }

    public virtual DbSet<_ExploitLog> _ExploitLogs { get; set; }

    public virtual DbSet<_FlagWorld_EventParticipant> _FlagWorld_EventParticipants { get; set; }

    public virtual DbSet<_FleaMarketNetwork> _FleaMarketNetworks { get; set; }

    public virtual DbSet<_Friend> _Friends { get; set; }

    public virtual DbSet<_GPHistory> _GPHistories { get; set; }

    public virtual DbSet<_Guild> _Guilds { get; set; }

    public virtual DbSet<_GuildChest> _GuildChests { get; set; }

    public virtual DbSet<_GuildMember> _GuildMembers { get; set; }

    public virtual DbSet<_GuildWar> _GuildWars { get; set; }

    public virtual DbSet<_InvCO> _InvCOs { get; set; }

    public virtual DbSet<_Inventory> _Inventories { get; set; }

    public virtual DbSet<_InventoryForAvatar> _InventoryForAvatars { get; set; }

    public virtual DbSet<_InventoryForLinkedStorage> _InventoryForLinkedStorages { get; set; }

    public virtual DbSet<_Item> _Items { get; set; }

    public virtual DbSet<_ItemPool> _ItemPools { get; set; }

    public virtual DbSet<_ItemQuotation> _ItemQuotations { get; set; }

    public virtual DbSet<_LatestItemSerial> _LatestItemSerials { get; set; }

    public virtual DbSet<_Log_SEEK_N_DESTROY_ITEM_FAST> _Log_SEEK_N_DESTROY_ITEM_FASTs { get; set; }

    public virtual DbSet<_Memo> _Memos { get; set; }

    public virtual DbSet<_OldTrijob> _OldTrijobs { get; set; }

    public virtual DbSet<_OpenMarket> _OpenMarkets { get; set; }

    public virtual DbSet<_RefAbilityByItemOptLevel> _RefAbilityByItemOptLevels { get; set; }

    public virtual DbSet<_RefAccessPermissionOfShop> _RefAccessPermissionOfShops { get; set; }

    public virtual DbSet<_RefAlchemyMerit> _RefAlchemyMerits { get; set; }

    public virtual DbSet<_RefCharDefault_Quest> _RefCharDefault_Quests { get; set; }

    public virtual DbSet<_RefCharDefault_Skill> _RefCharDefault_Skills { get; set; }

    public virtual DbSet<_RefCharDefault_SkillMastery> _RefCharDefault_SkillMasteries { get; set; }

    public virtual DbSet<_RefCharGen> _RefCharGens { get; set; }

    public virtual DbSet<_RefClimate> _RefClimates { get; set; }

    public virtual DbSet<_RefCollectionBook_Item> _RefCollectionBook_Items { get; set; }

    public virtual DbSet<_RefCollectionBook_Theme> _RefCollectionBook_Themes { get; set; }

    public virtual DbSet<_RefConditionToBuyScrapItem> _RefConditionToBuyScrapItems { get; set; }

    public virtual DbSet<_RefConditionToSellPackageItem> _RefConditionToSellPackageItems { get; set; }

    public virtual DbSet<_RefConditionToSellScrapItem> _RefConditionToSellScrapItems { get; set; }

    public virtual DbSet<_RefCustomizingReservedItemDropForMonster> _RefCustomizingReservedItemDropForMonsters { get; set; }

    public virtual DbSet<_RefDropClassSel_Alchemy_ATTRStone> _RefDropClassSel_Alchemy_ATTRStones { get; set; }

    public virtual DbSet<_RefDropClassSel_Alchemy_MagicStone> _RefDropClassSel_Alchemy_MagicStones { get; set; }

    public virtual DbSet<_RefDropClassSel_Alchemy_Tablet> _RefDropClassSel_Alchemy_Tablets { get; set; }

    public virtual DbSet<_RefDropClassSel_Ammo> _RefDropClassSel_Ammos { get; set; }

    public virtual DbSet<_RefDropClassSel_Cure> _RefDropClassSel_Cures { get; set; }

    public virtual DbSet<_RefDropClassSel_Equip> _RefDropClassSel_Equips { get; set; }

    public virtual DbSet<_RefDropClassSel_RareEquip> _RefDropClassSel_RareEquips { get; set; }

    public virtual DbSet<_RefDropClassSel_Recover> _RefDropClassSel_Recovers { get; set; }

    public virtual DbSet<_RefDropClassSel_Reinforce> _RefDropClassSel_Reinforces { get; set; }

    public virtual DbSet<_RefDropClassSel_Scroll> _RefDropClassSel_Scrolls { get; set; }

    public virtual DbSet<_RefDropGold> _RefDropGolds { get; set; }

    public virtual DbSet<_RefDropItemAssign> _RefDropItemAssigns { get; set; }

    public virtual DbSet<_RefDropItemGroup> _RefDropItemGroups { get; set; }

    public virtual DbSet<_RefDropOptLvlSel> _RefDropOptLvlSels { get; set; }

    public virtual DbSet<_RefDummySlot> _RefDummySlots { get; set; }

    public virtual DbSet<_RefEvent> _RefEvents { get; set; }

    public virtual DbSet<_RefEventReward> _RefEventRewards { get; set; }

    public virtual DbSet<_RefEventRewardItem> _RefEventRewardItems { get; set; }

    public virtual DbSet<_RefEventZone> _RefEventZones { get; set; }

    public virtual DbSet<_RefFmnCategoryTree> _RefFmnCategoryTrees { get; set; }

    public virtual DbSet<_RefFmnTidGroup> _RefFmnTidGroups { get; set; }

    public virtual DbSet<_RefFmnTidGroupMap> _RefFmnTidGroupMaps { get; set; }

    public virtual DbSet<_RefGachaCode> _RefGachaCodes { get; set; }

    public virtual DbSet<_RefGachaItemSet> _RefGachaItemSets { get; set; }

    public virtual DbSet<_RefGachaNpcMap> _RefGachaNpcMaps { get; set; }

    public virtual DbSet<_RefGameWorldBindGameWorldGroup> _RefGameWorldBindGameWorldGroups { get; set; }

    public virtual DbSet<_RefGameWorldBindTriggerCategory> _RefGameWorldBindTriggerCategories { get; set; }

    public virtual DbSet<_RefGameWorldGroup> _RefGameWorldGroups { get; set; }

    public virtual DbSet<_RefGameWorldGroup_Config> _RefGameWorldGroup_Configs { get; set; }

    public virtual DbSet<_RefGameWorldNPC> _RefGameWorldNPCs { get; set; }

    public virtual DbSet<_RefGame_World> _RefGame_Worlds { get; set; }

    public virtual DbSet<_RefGame_World_Config> _RefGame_World_Configs { get; set; }

    public virtual DbSet<_RefHWANLevel> _RefHWANLevels { get; set; }

    public virtual DbSet<_RefInstance_World_Region> _RefInstance_World_Regions { get; set; }

    public virtual DbSet<_RefInstance_World_Start_Po> _RefInstance_World_Start_Pos { get; set; }

    public virtual DbSet<_RefLatestItemSerial> _RefLatestItemSerials { get; set; }

    public virtual DbSet<_RefLevel> _RefLevels { get; set; }

    public virtual DbSet<_RefMagicOpt> _RefMagicOpts { get; set; }

    public virtual DbSet<_RefMagicOptAssign> _RefMagicOptAssigns { get; set; }

    public virtual DbSet<_RefMagicOptByItemOptLevel> _RefMagicOptByItemOptLevels { get; set; }

    public virtual DbSet<_RefMagicOptGroup> _RefMagicOptGroups { get; set; }

    public virtual DbSet<_RefMappingShopGroup> _RefMappingShopGroups { get; set; }

    public virtual DbSet<_RefMappingShopWithTab> _RefMappingShopWithTabs { get; set; }

    public virtual DbSet<_RefMonster_AssignedItemDrop> _RefMonster_AssignedItemDrops { get; set; }

    public virtual DbSet<_RefMonster_AssignedItemRndDrop> _RefMonster_AssignedItemRndDrops { get; set; }

    public virtual DbSet<_RefObjChar> _RefObjChars { get; set; }

    public virtual DbSet<_RefObjCharExtraSkill> _RefObjCharExtraSkills { get; set; }

    public virtual DbSet<_RefObjCommon> _RefObjCommons { get; set; }

    public virtual DbSet<_RefObjItem> _RefObjItems { get; set; }

    public virtual DbSet<_RefObjStruct> _RefObjStructs { get; set; }

    public virtual DbSet<_RefOptionalTeleport> _RefOptionalTeleports { get; set; }

    public virtual DbSet<_RefPackageItem> _RefPackageItems { get; set; }

    public virtual DbSet<_RefPricePolicyOfItem> _RefPricePolicyOfItems { get; set; }

    public virtual DbSet<_RefQuest> _RefQuests { get; set; }

    public virtual DbSet<_RefQuestReward> _RefQuestRewards { get; set; }

    public virtual DbSet<_RefQuestRewardItem> _RefQuestRewardItems { get; set; }

    public virtual DbSet<_RefRegion> _RefRegions { get; set; }

    public virtual DbSet<_RefRegionBindAssocServer> _RefRegionBindAssocServers { get; set; }

    public virtual DbSet<_RefRegionBindAssocServer_bak> _RefRegionBindAssocServer_baks { get; set; }

    public virtual DbSet<_RefRegion_bak> _RefRegion_baks { get; set; }

    public virtual DbSet<_RefRentItem> _RefRentItems { get; set; }

    public virtual DbSet<_RefRewardPolicyToBuyScrapItem> _RefRewardPolicyToBuyScrapItems { get; set; }

    public virtual DbSet<_RefRewardPolicyToSellPackageItem> _RefRewardPolicyToSellPackageItems { get; set; }

    public virtual DbSet<_RefRewardPolicyToSellScrapItem> _RefRewardPolicyToSellScrapItems { get; set; }

    public virtual DbSet<_RefScheduleDefine> _RefScheduleDefines { get; set; }

    public virtual DbSet<_RefScrapOfPackageItem> _RefScrapOfPackageItems { get; set; }

    public virtual DbSet<_RefServerEvent> _RefServerEvents { get; set; }

    public virtual DbSet<_RefServerEventReward> _RefServerEventRewards { get; set; }

    public virtual DbSet<_RefServerEventReward_ExpUPForPlayer> _RefServerEventReward_ExpUPForPlayers { get; set; }

    public virtual DbSet<_RefServerEventReward_SpawnMonster> _RefServerEventReward_SpawnMonsters { get; set; }

    public virtual DbSet<_RefSetItemGroup> _RefSetItemGroups { get; set; }

    public virtual DbSet<_RefShardContentConfig> _RefShardContentConfigs { get; set; }

    public virtual DbSet<_RefShop> _RefShops { get; set; }

    public virtual DbSet<_RefShopGood> _RefShopGoods { get; set; }

    public virtual DbSet<_RefShopGroup> _RefShopGroups { get; set; }

    public virtual DbSet<_RefShopItemGroup> _RefShopItemGroups { get; set; }

    public virtual DbSet<_RefShopItemStockPeriod> _RefShopItemStockPeriods { get; set; }

    public virtual DbSet<_RefShopObject> _RefShopObjects { get; set; }

    public virtual DbSet<_RefShopTab> _RefShopTabs { get; set; }

    public virtual DbSet<_RefShopTabGroup> _RefShopTabGroups { get; set; }

    public virtual DbSet<_RefSiegeBlessBuff> _RefSiegeBlessBuffs { get; set; }

    public virtual DbSet<_RefSiegeDungeon> _RefSiegeDungeons { get; set; }

    public virtual DbSet<_RefSiegeFortress> _RefSiegeFortresses { get; set; }

    public virtual DbSet<_RefSiegeFortressBattleRank> _RefSiegeFortressBattleRanks { get; set; }

    public virtual DbSet<_RefSiegeFortressGuard> _RefSiegeFortressGuards { get; set; }

    public virtual DbSet<_RefSiegeFortressItemForge> _RefSiegeFortressItemForges { get; set; }

    public virtual DbSet<_RefSiegeFortressReward> _RefSiegeFortressRewards { get; set; }

    public virtual DbSet<_RefSiegeLvlSummonMonster> _RefSiegeLvlSummonMonsters { get; set; }

    public virtual DbSet<_RefSiegeQuest> _RefSiegeQuests { get; set; }

    public virtual DbSet<_RefSiegeQuestReward> _RefSiegeQuestRewards { get; set; }

    public virtual DbSet<_RefSiegeStructUpgrade> _RefSiegeStructUpgrades { get; set; }

    public virtual DbSet<_RefSkill> _RefSkills { get; set; }

    public virtual DbSet<_RefSkillByItemOptLevel> _RefSkillByItemOptLevels { get; set; }

    public virtual DbSet<_RefSkillGroup> _RefSkillGroups { get; set; }

    public virtual DbSet<_RefSkillMastery> _RefSkillMasteries { get; set; }

    public virtual DbSet<_RefTeleLink> _RefTeleLinks { get; set; }

    public virtual DbSet<_RefTeleport> _RefTeleports { get; set; }

    public virtual DbSet<_RefTreatItemOfShop> _RefTreatItemOfShops { get; set; }

    public virtual DbSet<_RefTrigger> _RefTriggers { get; set; }

    public virtual DbSet<_RefTriggerAction> _RefTriggerActions { get; set; }

    public virtual DbSet<_RefTriggerActionParam> _RefTriggerActionParams { get; set; }

    public virtual DbSet<_RefTriggerBindAction> _RefTriggerBindActions { get; set; }

    public virtual DbSet<_RefTriggerBindCondition> _RefTriggerBindConditions { get; set; }

    public virtual DbSet<_RefTriggerBindEvent> _RefTriggerBindEvents { get; set; }

    public virtual DbSet<_RefTriggerCategory> _RefTriggerCategories { get; set; }

    public virtual DbSet<_RefTriggerCategoryBindTrigger> _RefTriggerCategoryBindTriggers { get; set; }

    public virtual DbSet<_RefTriggerCommon> _RefTriggerCommons { get; set; }

    public virtual DbSet<_RefTriggerCondition> _RefTriggerConditions { get; set; }

    public virtual DbSet<_RefTriggerConditionParam> _RefTriggerConditionParams { get; set; }

    public virtual DbSet<_RefTriggerEvent> _RefTriggerEvents { get; set; }

    public virtual DbSet<_RefTriggerVariable> _RefTriggerVariables { get; set; }

    public virtual DbSet<_RefUIString_Mt> _RefUIString_Mts { get; set; }

    public virtual DbSet<_RentItemInfo> _RentItemInfos { get; set; }

    public virtual DbSet<_ResultOfPackageItemToMappingWithServerSide> _ResultOfPackageItemToMappingWithServerSides { get; set; }

    public virtual DbSet<_Schedule> _Schedules { get; set; }

    public virtual DbSet<_ServerEvent> _ServerEvents { get; set; }

    public virtual DbSet<_ServerEventReward> _ServerEventRewards { get; set; }

    public virtual DbSet<_ShopItemStockQuantity> _ShopItemStockQuantities { get; set; }

    public virtual DbSet<_SiegeFortress> _SiegeFortresses { get; set; }

    public virtual DbSet<_SiegeFortressBattleRecord> _SiegeFortressBattleRecords { get; set; }

    public virtual DbSet<_SiegeFortressItemForge> _SiegeFortressItemForges { get; set; }

    public virtual DbSet<_SiegeFortressObject> _SiegeFortressObjects { get; set; }

    public virtual DbSet<_SiegeFortressRequest> _SiegeFortressRequests { get; set; }

    public virtual DbSet<_SiegeFortressStoneState> _SiegeFortressStoneStates { get; set; }

    public virtual DbSet<_SiegeFortressStruct> _SiegeFortressStructs { get; set; }

    public virtual DbSet<_Skill_BaoHiem_TNET> _Skill_BaoHiem_TNETs { get; set; }

    public virtual DbSet<_StaticAvatar> _StaticAvatars { get; set; }

    public virtual DbSet<_TimedJob> _TimedJobs { get; set; }

    public virtual DbSet<_TimedJobForPet> _TimedJobForPets { get; set; }

    public virtual DbSet<_TrainingCamp> _TrainingCamps { get; set; }

    public virtual DbSet<_TrainingCampBuffStatus> _TrainingCampBuffStatuses { get; set; }

    public virtual DbSet<_TrainingCampHonorRank> _TrainingCampHonorRanks { get; set; }

    public virtual DbSet<_TrainingCampHonorRankUpdateDate> _TrainingCampHonorRankUpdateDates { get; set; }

    public virtual DbSet<_TrainingCampMember> _TrainingCampMembers { get; set; }

    public virtual DbSet<_TrainingCampSubMentorHonorPoint> _TrainingCampSubMentorHonorPoints { get; set; }

    public virtual DbSet<_TrijobRanking4WEB> _TrijobRanking4WEBs { get; set; }

    public virtual DbSet<_TrijobReward> _TrijobRewards { get; set; }

    public virtual DbSet<_User> _Users { get; set; }

    public virtual DbSet<_UserBalance_Nhat> _UserBalance_Nhats { get; set; }

    public virtual DbSet<_UserOld> _UserOlds { get; set; }

    public virtual DbSet<_WebShop_SRO_Log> _WebShop_SRO_Logs { get; set; }

    public virtual DbSet<test_item_TNET> test_item_TNETs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item_Quay_TNET>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Item_Quay_TNET");

            entity.Property(e => e.CodeName).HasMaxLength(255);
        });

        modelBuilder.Entity<Tab_DBSafe_CheckState>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tab_DBSafe_CheckState");
        });

        modelBuilder.Entity<Tab_RefAISkill>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tab_RefAISkill");

            entity.Property(e => e.SkillCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tab_RefHive>(entity =>
        {
            entity.HasKey(e => e.dwHiveID);

            entity.ToTable("Tab_RefHive");

            entity.Property(e => e.GameWorldID).HasDefaultValueSql("(1)");
            entity.Property(e => e.HatchObjType).HasDefaultValueSql("(1)");
            entity.Property(e => e.szDescString128)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<Tab_RefNest>(entity =>
        {
            entity.HasKey(e => e.dwNestID);

            entity.ToTable("Tab_RefNest");

            entity.Property(e => e.btRespawn).HasDefaultValueSql("(1)");
        });

        modelBuilder.Entity<Tab_RefRanking_HunterActivity>(entity =>
        {
            entity.HasKey(e => e.Rank);

            entity.ToTable("Tab_RefRanking_HunterActivity");

            entity.Property(e => e.NickName)
                .HasMaxLength(17)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<Tab_RefRanking_HunterContribution>(entity =>
        {
            entity.HasKey(e => e.Rank);

            entity.ToTable("Tab_RefRanking_HunterContribution");

            entity.Property(e => e.NickName)
                .HasMaxLength(17)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tab_RefRanking_RobberActivity>(entity =>
        {
            entity.HasKey(e => e.Rank);

            entity.ToTable("Tab_RefRanking_RobberActivity");

            entity.Property(e => e.NickName)
                .HasMaxLength(17)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<Tab_RefRanking_RobberContribution>(entity =>
        {
            entity.HasKey(e => e.Rank);

            entity.ToTable("Tab_RefRanking_RobberContribution");

            entity.Property(e => e.NickName)
                .HasMaxLength(17)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tab_RefRanking_TraderActivity>(entity =>
        {
            entity.HasKey(e => e.Rank);

            entity.ToTable("Tab_RefRanking_TraderActivity");

            entity.Property(e => e.NickName)
                .HasMaxLength(17)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<Tab_RefRanking_TraderContribution>(entity =>
        {
            entity.HasKey(e => e.Rank);

            entity.ToTable("Tab_RefRanking_TraderContribution");

            entity.Property(e => e.NickName)
                .HasMaxLength(17)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tab_RefSpawnToolVersion>(entity =>
        {
            entity.HasKey(e => e.dwRefDataVersion).HasName("PK__Tab_RefSpawnTool__0F35FD8B");

            entity.ToTable("Tab_RefSpawnToolVersion");

            entity.Property(e => e.szVersionDescString)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tab_RefTactic>(entity =>
        {
            entity.HasKey(e => e.dwTacticsID).HasName("PK__Tab_RefTactics__62065FF3");

            entity.Property(e => e.dwTacticsID).ValueGeneratedNever();
            entity.Property(e => e.szDescString128)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_AccountJID>(entity =>
        {
            entity.HasKey(e => e.AccountID);

            entity.ToTable("_AccountJID");

            entity.HasIndex(e => e.JID, "IX__AccountJID").IsUnique();

            entity.Property(e => e.AccountID)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Chinese_Taiwan_Stroke_CI_AS");
        });

        modelBuilder.Entity<_AlliedClan>(entity =>
        {
            entity.Property(e => e.FoundationDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_AssociationReputation>(entity =>
        {
            entity.HasKey(e => new { e.AssociationCodeName, e.AssociationTypeName });

            entity.ToTable("_AssociationReputation");

            entity.HasIndex(e => e.AssociationCodeName, "IX__AssociationReputation_AssociationCodeName").HasFillFactor(90);

            entity.Property(e => e.AssociationCodeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AssociationTypeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_BindingOptionWithItem>(entity =>
        {
            entity.HasKey(e => new { e.nItemDBID, e.bOptType, e.nSlot });

            entity.ToTable("_BindingOptionWithItem");
        });

        modelBuilder.Entity<_BlackNameList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_BlackNameList");

            entity.Property(e => e.BlacklistName).HasMaxLength(255);
        });

        modelBuilder.Entity<_BlockedWhisperer>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TargetName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_Char>(entity =>
        {
            entity.HasKey(e => e.CharID).HasName("PK__Char_1");

            entity.ToTable("_Char");

            entity.HasIndex(e => e.CharName16, "IX__Char").IsUnique();

            entity.HasIndex(e => e.NickName16, "IX__Char_1").HasFillFactor(90);

            entity.Property(e => e.AutoInvestExp).HasDefaultValueSql("(1)");
            entity.Property(e => e.CharName16)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.CurLevel).HasDefaultValueSql("(1)");
            entity.Property(e => e.DiedWorldID).HasDefaultValueSql("(1)");
            entity.Property(e => e.GuildID).HasDefaultValueSql("(0)");
            entity.Property(e => e.HP).HasDefaultValueSql("(200)");
            entity.Property(e => e.JobLvl_Hunter).HasDefaultValueSql("(1)");
            entity.Property(e => e.JobLvl_Robber).HasDefaultValueSql("(1)");
            entity.Property(e => e.JobLvl_Trader).HasDefaultValueSql("(1)");
            entity.Property(e => e.LastLogout).HasColumnType("smalldatetime");
            entity.Property(e => e.MP).HasDefaultValueSql("(200)");
            entity.Property(e => e.MaxLevel).HasDefaultValueSql("(1)");
            entity.Property(e => e.NickName16)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.TelWorldID).HasDefaultValueSql("(1)");
            entity.Property(e => e.WorldID).HasDefaultValueSql("(1)");
        });

        modelBuilder.Entity<_CharCO>(entity =>
        {
            entity.ToTable("_CharCOS");

            entity.HasIndex(e => e.OwnerCharID, "IX__CharCOS").HasFillFactor(90);

            entity.HasIndex(e => e.CharName, "IX__CharCOS_1").HasFillFactor(90);

            entity.Property(e => e.CharName)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Lvl).HasDefaultValueSql("(1)");
            entity.Property(e => e.RentEndTime).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_CharCollectionBook>(entity =>
        {
            entity.HasKey(e => new { e.CharID, e.ThemeID, e.SlotIndex });

            entity.ToTable("_CharCollectionBook");

            entity.Property(e => e.RegDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_CharInstanceWorldDatum>(entity =>
        {
            entity.HasKey(e => new { e.CharID, e.WorldID });

            entity.Property(e => e.LastEnterTime).HasColumnType("datetime");
            entity.Property(e => e.OpenedTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<_CharNameList>(entity =>
        {
            entity.HasKey(e => new { e.CharName16, e.CharID });

            entity.ToTable("_CharNameList");

            entity.Property(e => e.CharName16)
                .HasMaxLength(17)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_CharNickNameList>(entity =>
        {
            entity.HasKey(e => new { e.NickName16, e.CharID });

            entity.ToTable("_CharNickNameList");

            entity.HasIndex(e => e.CharID, "IX_CharNickNameList").HasFillFactor(90);

            entity.Property(e => e.NickName16)
                .HasMaxLength(17)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_CharQuest>(entity =>
        {
            entity.HasKey(e => new { e.CharID, e.QuestID });

            entity.ToTable("_CharQuest");

            entity.Property(e => e.EndTime).HasColumnType("smalldatetime");
            entity.Property(e => e.StartTime).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_CharSkill>(entity =>
        {
            entity.HasKey(e => new { e.CharID, e.SkillID });

            entity.ToTable("_CharSkill");

            entity.Property(e => e.Enable).HasDefaultValueSql("(1)");
        });

        modelBuilder.Entity<_CharSkillMastery>(entity =>
        {
            entity.HasKey(e => new { e.CharID, e.MasteryID });

            entity.ToTable("_CharSkillMastery");
        });

        modelBuilder.Entity<_CharTrijob>(entity =>
        {
            entity.HasKey(e => e.CharID);

            entity.ToTable("_CharTrijob");

            entity.Property(e => e.CharID).ValueGeneratedNever();
            entity.Property(e => e.Level).HasDefaultValueSql("(1)");
        });

        modelBuilder.Entity<_CharTrijobSafeTrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_CharTrijobSafeTrade");

            entity.HasIndex(e => e.CharID, "IX__CharTrijobSafeTrade")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.LastSafeTrade).HasColumnType("datetime");
        });

        modelBuilder.Entity<_Chest>(entity =>
        {
            entity.HasKey(e => new { e.UserJID, e.Slot });

            entity.ToTable("_Chest");

            entity.HasIndex(e => e.ItemID, "IX__Chest").HasFillFactor(90);
        });

        modelBuilder.Entity<_ChestInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_ChestInfo");

            entity.Property(e => e.ChestSize).HasDefaultValueSql("(150)");
        });

        modelBuilder.Entity<_ClientConfig>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_ClientConfig");

            entity.HasIndex(e => e.CharID, "IX__ClientConfig")
                .IsClustered()
                .HasFillFactor(90);
        });

        modelBuilder.Entity<_DeletedChar>(entity =>
        {
            entity.HasKey(e => e.CharID);

            entity.ToTable("_DeletedChar");

            entity.HasIndex(e => e.UserJID, "IX__DeletedChar").HasFillFactor(90);

            entity.Property(e => e.CharID).ValueGeneratedNever();
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<_ExploitLog>(entity =>
        {
            entity.HasKey(e => new { e.ID, e.CharID });

            entity.ToTable("_ExploitLog");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.DetectedApp)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.LogTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<_FlagWorld_EventParticipant>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.LatestAttempt).HasColumnType("datetime");
        });

        modelBuilder.Entity<_FleaMarketNetwork>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_FleaMarketNetwork");

            entity.HasIndex(e => new { e.CharID, e.Slot }, "CIX__FleaMarketNetwork")
                .IsClustered()
                .HasFillFactor(90);
        });

        modelBuilder.Entity<_Friend>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_Friend");

            entity.HasIndex(e => e.CharID, "IX__Friend")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.FriendCharName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.RefObjID).HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_GPHistory>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK___GPHistory__2A54081B");

            entity.ToTable("_GPHistory");

            entity.HasIndex(e => e.GuildID, "IX_GPHistory_GuildID").HasFillFactor(71);

            entity.HasIndex(e => e.UsedTime, "IX_GPHistory_UsedTime").HasFillFactor(71);

            entity.Property(e => e.CharName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.UsedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<_Guild>(entity =>
        {
            entity.ToTable("_Guild");

            entity.HasIndex(e => e.Name, "IX__Guild").IsUnique();

            entity.Property(e => e.FoundationDate).HasColumnType("smalldatetime");
            entity.Property(e => e.MasterComment)
                .HasMaxLength(2049)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.MasterCommentTitle)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_GuildChest>(entity =>
        {
            entity.HasKey(e => new { e.GuildID, e.Slot });

            entity.ToTable("_GuildChest");
        });

        modelBuilder.Entity<_GuildMember>(entity =>
        {
            entity.HasKey(e => new { e.GuildID, e.CharID });

            entity.ToTable("_GuildMember");

            entity.HasIndex(e => e.CharID, "IX_CharID_GuildMember").HasFillFactor(90);

            entity.Property(e => e.CharName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.JoinDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Nickname)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.RefObjID).HasDefaultValueSql("(0)");
            entity.Property(e => e.SiegeAuthority).HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_GuildWar>(entity =>
        {
            entity.ToTable("_GuildWar");

            entity.Property(e => e.WarEndTime).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_InvCO>(entity =>
        {
            entity.HasKey(e => new { e.COSID, e.Slot });

            entity.ToTable("_InvCOS");

            entity.HasIndex(e => e.ItemID, "IX__InvCOS").HasFillFactor(90);
        });

        modelBuilder.Entity<_Inventory>(entity =>
        {
            entity.HasKey(e => new { e.CharID, e.Slot }).HasName("PK_Inventory");

            entity.ToTable("_Inventory");

            entity.HasIndex(e => e.ItemID, "IX__Inventory").HasFillFactor(90);
        });

        modelBuilder.Entity<_InventoryForAvatar>(entity =>
        {
            entity.HasKey(e => new { e.CharID, e.Slot });

            entity.ToTable("_InventoryForAvatar");

            entity.HasIndex(e => e.ItemID, "IX__InventoryForAvatar").HasFillFactor(90);
        });

        modelBuilder.Entity<_InventoryForLinkedStorage>(entity =>
        {
            entity.HasKey(e => new { e.LinkedItemID, e.Slot });

            entity.ToTable("_InventoryForLinkedStorage");
        });

        modelBuilder.Entity<_Item>(entity =>
        {
            entity.HasKey(e => e.ID64);

            entity.Property(e => e.CreaterName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
        });

        modelBuilder.Entity<_ItemPool>(entity =>
        {
            entity.HasKey(e => e.ItemID).IsClustered(false);

            entity.ToTable("_ItemPool");

            entity.HasIndex(e => e.InUse, "IX__ItemPool")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.ItemID).ValueGeneratedNever();
        });

        modelBuilder.Entity<_ItemQuotation>(entity =>
        {
            entity.ToTable("_ItemQuotation");
        });

        modelBuilder.Entity<_LatestItemSerial>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_LatestItemSerial");
        });

        modelBuilder.Entity<_Log_SEEK_N_DESTROY_ITEM_FAST>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_Log_SEEK_N_DESTROY_ITEM_FAST");

            entity.Property(e => e.CodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.DeletedTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<_Memo>(entity =>
        {
            entity.HasKey(e => e.ID64).IsClustered(false);

            entity.ToTable("_Memo");

            entity.HasIndex(e => e.CharID, "IX__Memo")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.Date).HasColumnType("smalldatetime");
            entity.Property(e => e.FromCharName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .UseCollation("Latin1_General_CI_AS");
            entity.Property(e => e.Message)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.RefObjID).HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_OldTrijob>(entity =>
        {
            entity.HasKey(e => e.CharID);

            entity.ToTable("_OldTrijob");

            entity.Property(e => e.CharID).ValueGeneratedNever();
        });

        modelBuilder.Entity<_OpenMarket>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_OpenMarket");

            entity.HasIndex(e => new { e.Status, e.TidGroupID, e.ItemClass, e.RegDate }, "IX__OpenMarket_For_SMC").HasFillFactor(90);

            entity.HasIndex(e => new { e.JID, e.Status }, "IX__OpenMarket_JID_STATUS").HasFillFactor(90);

            entity.HasIndex(e => e.JID, "IX__OpenMarket_RefItemID").HasFillFactor(90);

            entity.HasIndex(e => new { e.TidGroupID, e.Status, e.EndDate }, "IX__OpenMarket_TID_STATUS_REGDATE").HasFillFactor(90);

            entity.Property(e => e.CharName16)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");
            entity.Property(e => e.PersnalID).HasDefaultValueSql("((-1))");
            entity.Property(e => e.RegDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_RefAbilityByItemOptLevel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefAbilityByItemOptLevel");

            entity.HasIndex(e => e.ID, "IX__RefAbilityByItemOptLevel").IsUnique();

            entity.HasIndex(e => new { e.RefItemID, e.ItemOptLevel }, "IX__RefAbilityByItemOptLevel_1").IsUnique();

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<_RefAccessPermissionOfShop>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefAccessPermissionOfShop");

            entity.HasIndex(e => new { e.Country, e.RefShopCodeName, e.FourCC }, "IX__RefAccessPermissionOfShop").IsUnique();

            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.RefShopCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefAlchemyMerit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefAlchemyMerit");

            entity.Property(e => e.FreeParamDesc1)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.FreeParamDesc2)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.FreeParamDesc3)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.OptName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefCharDefault_Quest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefCharDefault_Quest");

            entity.Property(e => e.CodeName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<_RefCharDefault_Skill>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefCharDefault_Skill");
        });

        modelBuilder.Entity<_RefCharDefault_SkillMastery>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefCharDefault_SkillMastery");
        });

        modelBuilder.Entity<_RefCharGen>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefCharGen");
        });

        modelBuilder.Entity<_RefClimate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefClimate");
        });

        modelBuilder.Entity<_RefCollectionBook_Item>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefCollectionBook_Item");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.DDJFile128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ObjName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Story128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ThemeCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefCollectionBook_Theme>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefCollectionBook_Theme");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Name128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ObjName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefConditionToBuyScrapItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefConditionToBuyScrapItem");

            entity.HasIndex(e => new { e.Country, e.Cash, e.TypeID1, e.TypeID2, e.TypeID3, e.TypeID4, e.RefItemCodeName, e.AcceptOrReject, e.FourCC }, "IX__RefConditionToBuyScrapItem").IsUnique();

            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.RefItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_RefConditionToSellPackageItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefConditionToSellPackageItem");

            entity.HasIndex(e => new { e.Country, e.RefPackageItemCodeName, e.FourCC }, "IX__RefConditionToSellPackageItem").IsUnique();

            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.RefPackageItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefConditionToSellScrapItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefConditionToSellScrapItem");

            entity.HasIndex(e => new { e.Country, e.Cash, e.TypeID1, e.TypeID2, e.TypeID3, e.TypeID4, e.RefItemCodeName, e.AcceptOrReject, e.FourCC }, "IX__RefConditionToSellScrapItem").IsUnique();

            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.RefItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefCustomizingReservedItemDropForMonster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefCustomizingReservedItemDropForMonster");

            entity.Property(e => e.Param1).HasDefaultValueSql("(0)");
            entity.Property(e => e.Param2).HasDefaultValueSql("(0)");
            entity.Property(e => e.Param3).HasDefaultValueSql("(0)");
            entity.Property(e => e.Param4).HasDefaultValueSql("(0)");
            entity.Property(e => e.Param5).HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_RefDropClassSel_Alchemy_ATTRStone>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_Alchemy_ATTRStone");
        });

        modelBuilder.Entity<_RefDropClassSel_Alchemy_MagicStone>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_Alchemy_MagicStone");
        });

        modelBuilder.Entity<_RefDropClassSel_Alchemy_Tablet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_Alchemy_Tablet");
        });

        modelBuilder.Entity<_RefDropClassSel_Ammo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_Ammo");
        });

        modelBuilder.Entity<_RefDropClassSel_Cure>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_Cure");
        });

        modelBuilder.Entity<_RefDropClassSel_Equip>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_Equip");
        });

        modelBuilder.Entity<_RefDropClassSel_RareEquip>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_RareEquip");
        });

        modelBuilder.Entity<_RefDropClassSel_Recover>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_Recover");
        });

        modelBuilder.Entity<_RefDropClassSel_Reinforce>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_Reinforce");
        });

        modelBuilder.Entity<_RefDropClassSel_Scroll>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropClassSel_Scroll");
        });

        modelBuilder.Entity<_RefDropGold>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropGold");
        });

        modelBuilder.Entity<_RefDropItemAssign>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropItemAssign");
        });

        modelBuilder.Entity<_RefDropItemGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropItemGroup");

            entity.HasIndex(e => new { e.RefItemGroupID, e.RefItemID }, "IX__RefDropItemGroup").IsUnique();

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefDropOptLvlSel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDropOptLvlSel");
        });

        modelBuilder.Entity<_RefDummySlot>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefDummySlot");
        });

        modelBuilder.Entity<_RefEvent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefEvent");

            entity.Property(e => e.CodeName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.DescName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.ScheduleName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        });

        modelBuilder.Entity<_RefEventReward>(entity =>
        {
            entity.HasKey(e => e.EventID);

            entity.ToTable("_RefEventReward");

            entity.Property(e => e.EventID).ValueGeneratedNever();
            entity.Property(e => e.EventCodeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param1_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param2_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param3_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefEventRewardItem>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.EventID, "IX__RefEventRewardItems_EventID").HasFillFactor(90);

            entity.Property(e => e.EventCodeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ItemCodeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param1_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param2_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.RentItemCodeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefEventZone>(entity =>
        {
            entity.ToTable("_RefEventZone");

            entity.Property(e => e.EventName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ZoneName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.strParam1)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.strParam2)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.strParam3)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.strParam4)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.strParam5)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefFmnCategoryTree>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefFmnCategoryTree");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ParentCategoryName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.StringID)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefFmnTidGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefFmnTidGroup");

            entity.Property(e => e.TidGroupID).ValueGeneratedOnAdd();
            entity.Property(e => e.TidGroupName)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefFmnTidGroupMap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefFmnTidGroupMap");
        });

        modelBuilder.Entity<_RefGachaCode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefGachaCode");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.GachaSetID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<_RefGachaItemSet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefGachaItemSet");

            entity.Property(e => e.Count).HasDefaultValueSql("(1)");
            entity.Property(e => e.GachaID).ValueGeneratedOnAdd();
            entity.Property(e => e.param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
        });

        modelBuilder.Entity<_RefGachaNpcMap>(entity =>
        {
            entity.HasKey(e => e.NPC_ID).HasName("PK__RefGachaNpc");

            entity.ToTable("_RefGachaNpcMap");

            entity.Property(e => e.NPC_ID).ValueGeneratedNever();
        });

        modelBuilder.Entity<_RefGameWorldBindGameWorldGroup>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__RefGameWorldBindGroupGameWorld");

            entity.ToTable("_RefGameWorldBindGameWorldGroup");
        });

        modelBuilder.Entity<_RefGameWorldBindTriggerCategory>(entity =>
        {
            entity.ToTable("_RefGameWorldBindTriggerCategory");
        });

        modelBuilder.Entity<_RefGameWorldGroup>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__RefGroupGameWorld");

            entity.ToTable("_RefGameWorldGroup");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ConfigGroupCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ObjName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefGameWorldGroup_Config>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__RefGroupGameWorld_Config");

            entity.ToTable("_RefGameWorldGroup_Config");

            entity.HasIndex(e => e.GroupCodeName128, "IX__RefGroupGameWorld_Config").HasFillFactor(90);

            entity.Property(e => e.GroupCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Value)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ValueCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefGameWorldNPC>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefGameWorldNPC");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.NPCCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.WorldCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefGame_World>(entity =>
        {
            entity.ToTable("_RefGame_World");

            entity.Property(e => e.ConfigGroupCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.WorldCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('INSTANC_WORLD_CODENAME')")
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefGame_World_Config>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefGame_World_Config");

            entity.HasIndex(e => e.GroupCodeName128, "IX__RefGame_World_Config")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.GroupCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Value)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ValueCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefHWANLevel>(entity =>
        {
            entity.HasKey(e => e.HwanLevel);

            entity.ToTable("_RefHWANLevel");

            entity.Property(e => e.AssocFileObj128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Title_CH70)
                .HasMaxLength(70)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Title_EU70)
                .HasMaxLength(70)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefInstance_World_Region>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefInstance_World_Region");
        });

        modelBuilder.Entity<_RefInstance_World_Start_Po>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<_RefLatestItemSerial>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefLatestItemSerial");
        });

        modelBuilder.Entity<_RefLevel>(entity =>
        {
            entity.HasKey(e => e.Lvl);

            entity.ToTable("_RefLevel");
        });

        modelBuilder.Entity<_RefMagicOpt>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__RefMagicOpt_ID");

            entity.ToTable("_RefMagicOpt");

            entity.HasIndex(e => e.MLevel, "IX__RefMagicOpt_MLevel").HasFillFactor(90);

            entity.HasIndex(e => e.MOptName128, "IX__RefMagicOpt_MOptName128").HasFillFactor(90);

            entity.Property(e => e.AttrType)
                .HasMaxLength(8)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup1)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup10)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup2)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup3)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup4)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup5)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup6)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup7)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup8)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AvailItemGroup9)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.MOptName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefMagicOptAssign>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefMagicOptAssign");

            entity.Property(e => e.AvailMOpt1)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt10)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt11)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt12)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt13)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt14)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt15)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt16)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt17)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt18)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt19)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt2)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt20)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt21)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt22)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt23)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt24)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt25)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt3)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt4)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt5)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt6)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt7)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt8)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AvailMOpt9)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefMagicOptByItemOptLevel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefMagicOptByItemOptLevel");

            entity.HasIndex(e => new { e.RefMagicOptID, e.Link }, "IX__RefMagicOptByItemOptLevel").IsUnique();

            entity.Property(e => e.TooltipCodename)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefMagicOptGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefMagicOptGroup");

            entity.HasIndex(e => new { e.LinkID, e.MagicType, e.MOptID }, "IX__RefMagicOptGroup").IsUnique();

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param1_Desc)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param2_Desc)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefMappingShopGroup>(entity =>
        {
            entity.HasKey(e => new { e.Country, e.RefShopGroupCodeName, e.RefShopCodeName });

            entity.ToTable("_RefMappingShopGroup");

            entity.Property(e => e.RefShopGroupCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.RefShopCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefMappingShopWithTab>(entity =>
        {
            entity.HasKey(e => new { e.Country, e.RefShopCodeName, e.RefTabGroupCodeName });

            entity.ToTable("_RefMappingShopWithTab");

            entity.Property(e => e.RefShopCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.RefTabGroupCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefMonster_AssignedItemDrop>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefMonster_AssignedItemDrop");

            entity.Property(e => e.CustomValue1).HasDefaultValueSql("(0)");
            entity.Property(e => e.CustomValue2).HasDefaultValueSql("(0)");
            entity.Property(e => e.CustomValue3).HasDefaultValueSql("(0)");
            entity.Property(e => e.CustomValue4).HasDefaultValueSql("(0)");
            entity.Property(e => e.CustomValue5).HasDefaultValueSql("(0)");
            entity.Property(e => e.CustomValue6).HasDefaultValueSql("(0)");
            entity.Property(e => e.CustomValue7).HasDefaultValueSql("(0)");
            entity.Property(e => e.CustomValue8).HasDefaultValueSql("(0)");
            entity.Property(e => e.CustomValue9).HasDefaultValueSql("(0)");
            entity.Property(e => e.RefMagicOptionID1).HasDefaultValueSql("(0)");
            entity.Property(e => e.RefMagicOptionID2).HasDefaultValueSql("(0)");
            entity.Property(e => e.RefMagicOptionID3).HasDefaultValueSql("(0)");
            entity.Property(e => e.RefMagicOptionID4).HasDefaultValueSql("(0)");
            entity.Property(e => e.RefMagicOptionID5).HasDefaultValueSql("(0)");
            entity.Property(e => e.RefMagicOptionID6).HasDefaultValueSql("(0)");
            entity.Property(e => e.RefMagicOptionID7).HasDefaultValueSql("(0)");
            entity.Property(e => e.RefMagicOptionID8).HasDefaultValueSql("(0)");
            entity.Property(e => e.RefMagicOptionID9).HasDefaultValueSql("(0)");
            entity.Property(e => e.RentCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefMonster_AssignedItemRndDrop>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefMonster_AssignedItemRndDrop");

            entity.HasIndex(e => new { e.RefMonsterID, e.RefItemGroupID }, "IX__RefMonster_AssignedItemRndDrop").IsUnique();

            entity.Property(e => e.ItemGroupCodeName128)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefObjChar>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Char");

            entity.ToTable("_RefObjChar");
        });

        modelBuilder.Entity<_RefObjCharExtraSkill>(entity =>
        {
            entity.HasKey(e => e.CharID);

            entity.ToTable("_RefObjCharExtraSkill");

            entity.Property(e => e.CharID).ValueGeneratedNever();
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<_RefObjCommon>(entity =>
        {
            entity.ToTable("_RefObjCommon");

            entity.HasIndex(e => e.CodeName128, "IX_RefObjCommon_CodeName").HasFillFactor(90);

            entity.Property(e => e.AssocFile1_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AssocFile2_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AssocFileDrop128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AssocFileIcon128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.AssocFileObj128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.DescStrID128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.NameStrID128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.ObjName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.OrgObjCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefObjItem>(entity =>
        {
            entity.ToTable("_RefObjItem");

            entity.Property(e => e.Desc10_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc11_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc12_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc13_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc14_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc15_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc16_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc17_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc18_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc19_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc1_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc20_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc2_128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Desc3_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc4_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc5_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc6_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc7_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc8_128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Desc9_128)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefObjStruct>(entity =>
        {
            entity.ToTable("_RefObjStruct");
        });

        modelBuilder.Entity<_RefOptionalTeleport>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("IX_RefOptionalTeleport");

            entity.ToTable("_RefOptionalTeleport");

            entity.Property(e => e.ObjName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param1_Desc_128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param2_Desc_128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param3_Desc_128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ZoneName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefPackageItem>(entity =>
        {
            entity.HasKey(e => new { e.ID, e.Country });

            entity.ToTable("_RefPackageItem");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.AssocFileIcon)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.DescStrID)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.ExpandTerm)
                .HasMaxLength(65)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.NameStrID)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
        });

        modelBuilder.Entity<_RefPricePolicyOfItem>(entity =>
        {
            entity.HasKey(e => new { e.RefPackageItemCodeName, e.PaymentDevice, e.Country });

            entity.ToTable("_RefPricePolicyOfItem");

            entity.Property(e => e.RefPackageItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefQuest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefQuest");

            entity.Property(e => e.CodeName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ContentsString)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.DescName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.NameString)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.NoticeCondition)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.NoticeNPC)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.PayContents)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.PayString)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefQuestReward>(entity =>
        {
            entity.HasKey(e => e.QuestID);

            entity.ToTable("_RefQuestReward");

            entity.Property(e => e.QuestID).ValueGeneratedNever();
            entity.Property(e => e.APType)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param1_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param2_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param3_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.QuestCodeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefQuestRewardItem>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.QuestID, "IX__RefQuestRewardItems_QuestID").HasFillFactor(90);

            entity.Property(e => e.ItemCodeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.OptionalItemCode)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param1_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param2_Desc)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.QuestCodeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.RentItemCodeName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')")
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefRegion>(entity =>
        {
            entity.HasKey(e => e.wRegionID);

            entity.ToTable("_RefRegion");

            entity.Property(e => e.wRegionID).ValueGeneratedNever();
            entity.Property(e => e.AreaName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.AssocFile256)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.ContinentName)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefRegionBindAssocServer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefRegionBindAssocServer");

            entity.Property(e => e.AreaName)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefRegionBindAssocServer_bak>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefRegionBindAssocServer_bak");

            entity.Property(e => e.AreaName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefRegion_bak>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefRegion_bak");

            entity.Property(e => e.AreaName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.AssocFile256)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ContinentName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefRentItem>(entity =>
        {
            entity.HasKey(e => new { e.RentCodeName, e.RefItemID });

            entity.ToTable("_RefRentItem");

            entity.HasIndex(e => e.RentCodeName, "UQ___RefRentItem__68A6404F").IsUnique();

            entity.Property(e => e.RentCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.EndTime).HasColumnType("smalldatetime");
            entity.Property(e => e.StartTime).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_RefRewardPolicyToBuyScrapItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefRewardPolicyToBuyScrapItem");

            entity.HasIndex(e => new { e.Country, e.Cash, e.TypeID1, e.TypeID2, e.TypeID3, e.TypeID4, e.RefItemCodeName, e.AcceptOrReject, e.FourCC }, "IX__RefRewardPolicyToBuyScrapItem").IsUnique();

            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.RefItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_RefRewardPolicyToSellPackageItem>(entity =>
        {
            entity.HasKey(e => new { e.RefPackageItemCodeName, e.FourCC, e.Country });

            entity.ToTable("_RefRewardPolicyToSellPackageItem");

            entity.HasIndex(e => new { e.Country, e.RefPackageItemCodeName, e.FourCC }, "IX__RefRewardPolicyToSellPackageItem").IsUnique();

            entity.Property(e => e.RefPackageItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
        });

        modelBuilder.Entity<_RefRewardPolicyToSellScrapItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefRewardPolicyToSellScrapItem");

            entity.HasIndex(e => new { e.Country, e.Cash, e.TypeID1, e.TypeID2, e.TypeID3, e.TypeID4, e.RefItemCodeName, e.AcceptOrReject, e.FourCC }, "IX__RefRewardPolicyToSellScrapItem").IsUnique();

            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.RefItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefScheduleDefine>(entity =>
        {
            entity.HasKey(e => e.ScheduleDefineIdx).HasName("PK___RefScheduleDefi__4077880D");

            entity.ToTable("_RefScheduleDefine");

            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ScheduleName)
                .HasMaxLength(124)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefScrapOfPackageItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefScrapOfPackageItem");

            entity.Property(e => e.Index).ValueGeneratedOnAdd();
            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.RefItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.RefPackageItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefServerEvent>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK___RefServerEvent__67280C31");

            entity.ToTable("_RefServerEvent");

            entity.HasIndex(e => e.Name, " IX_RefServerEvent_Name ").HasFillFactor(90);

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.BeginDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefServerEventReward>(entity =>
        {
            entity.HasKey(e => e.RewardID).HasName("PK___RefServerEventR__681C306A");

            entity.ToTable("_RefServerEventReward");
        });

        modelBuilder.Entity<_RefServerEventReward_ExpUPForPlayer>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.OwnerRewardID, "IX_RefServerEventReward_ExpUPForPlayers")
                .IsClustered()
                .HasFillFactor(90);
        });

        modelBuilder.Entity<_RefServerEventReward_SpawnMonster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefServerEventReward_SpawnMonster");

            entity.HasIndex(e => e.OwnerRewardID, "IX_RefServerEventReward_SpawnMonster")
                .IsClustered()
                .HasFillFactor(90);
        });

        modelBuilder.Entity<_RefSetItemGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefSetItemGroup");

            entity.HasIndex(e => e.ID, "IX__RefSetItemGroup").IsUnique();

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.DescStrID128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.NameStrID128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ObjName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e._10SetMOptGroupID).HasColumnName("10SetMOptGroupID");
            entity.Property(e => e._11SetMOptGroupID).HasColumnName("11SetMOptGroupID");
            entity.Property(e => e._2SetMOptGroupID).HasColumnName("2SetMOptGroupID");
            entity.Property(e => e._3SetMOptGroupID).HasColumnName("3SetMOptGroupID");
            entity.Property(e => e._4SetMOptGroupID).HasColumnName("4SetMOptGroupID");
            entity.Property(e => e._5SetMOptGroupID).HasColumnName("5SetMOptGroupID");
            entity.Property(e => e._6SetMOptGroupID).HasColumnName("6SetMOptGroupID");
            entity.Property(e => e._7SetMOptGroupID).HasColumnName("7SetMOptGroupID");
            entity.Property(e => e._8SetMOptGroupID).HasColumnName("8SetMOptGroupID");
            entity.Property(e => e._9SetMOptGroupID).HasColumnName("9SetMOptGroupID");
        });

        modelBuilder.Entity<_RefShardContentConfig>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefShardContentConfig");

            entity.HasIndex(e => e.CodeName128, "IX__RefShardContentService")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.CodeDesc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Value)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefShop>(entity =>
        {
            entity.HasKey(e => new { e.ID, e.Country }).HasName("PK__RefShop_renewal");

            entity.ToTable("_RefShop");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
        });

        modelBuilder.Entity<_RefShopGood>(entity =>
        {
            entity.HasKey(e => new { e.Country, e.RefTabCodeName, e.RefPackageItemCodeName }).HasName("PK__RefShopGoods_renewal");

            entity.Property(e => e.RefTabCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.RefPackageItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
        });

        modelBuilder.Entity<_RefShopGroup>(entity =>
        {
            entity.HasKey(e => new { e.Country, e.ID, e.RefNPCCodeName }).HasName("PK__RefShopGroup_renewal");

            entity.ToTable("_RefShopGroup");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.RefNPCCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
        });

        modelBuilder.Entity<_RefShopItemGroup>(entity =>
        {
            entity.HasKey(e => e.GroupID);

            entity.ToTable("_RefShopItemGroup");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.StrID128_Group)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefShopItemStockPeriod>(entity =>
        {
            entity.HasKey(e => new { e.Country, e.RefShopGroupCodeName, e.RefPackageItemCodeName }).HasName("PK__RefShopItemStockQuantity");

            entity.ToTable("_RefShopItemStockPeriod");

            entity.Property(e => e.RefShopGroupCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.RefPackageItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.StockExpireDate).HasColumnType("smalldatetime");
            entity.Property(e => e.StockOpeningDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_RefShopObject>(entity =>
        {
            entity.ToTable("_RefShopObject");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefShopTab>(entity =>
        {
            entity.HasKey(e => new { e.ID, e.Country }).HasName("PK__RefShopTab_renewal");

            entity.ToTable("_RefShopTab");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.RefTabGroupCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.StrID128_Tab)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefShopTabGroup>(entity =>
        {
            entity.HasKey(e => new { e.ID, e.Country });

            entity.ToTable("_RefShopTabGroup");

            entity.Property(e => e.ID).ValueGeneratedOnAdd();
            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.StrID128_Group)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefSiegeBlessBuff>(entity =>
        {
            entity.HasKey(e => e.BlessID).HasName("PK___RefSiegeBlessBu__71A59AA4");

            entity.ToTable("_RefSiegeBlessBuff");

            entity.HasIndex(e => e.FortressID, "IX_RefSiegeBlessBuff_FortressID").HasFillFactor(71);

            entity.HasIndex(e => e.RefBlessBuffID, "IX_RefSiegeBlessBuff_RefBlessBuffID").HasFillFactor(71);

            entity.Property(e => e.NeedGP).HasDefaultValueSql("(0)");
            entity.Property(e => e.NeedGold).HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_RefSiegeDungeon>(entity =>
        {
            entity.HasKey(e => e.FortressID).HasName("PK___RefSiegeDungeon__7299BEDD");

            entity.ToTable("_RefSiegeDungeon");

            entity.Property(e => e.FortressID).ValueGeneratedNever();
        });

        modelBuilder.Entity<_RefSiegeFortress>(entity =>
        {
            entity.HasKey(e => e.FortressID);

            entity.ToTable("_RefSiegeFortress");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.CrestPath128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.LinkedTeleportCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.NameID128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.RequestNPCName128)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefSiegeFortressBattleRank>(entity =>
        {
            entity.HasKey(e => e.RankLvl);

            entity.ToTable("_RefSiegeFortressBattleRank");

            entity.Property(e => e.CrestPath128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.RankName)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefSiegeFortressGuard>(entity =>
        {
            entity.HasKey(e => new { e.FortressID, e.GuardRefObjID });

            entity.ToTable("_RefSiegeFortressGuard");
        });

        modelBuilder.Entity<_RefSiegeFortressItemForge>(entity =>
        {
            entity.HasKey(e => new { e.FortressID, e.RefItemID });

            entity.ToTable("_RefSiegeFortressItemForge");
        });

        modelBuilder.Entity<_RefSiegeFortressReward>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.FortressID, "IX__RefSiegeFortressRewards_FortressID").HasFillFactor(71);
        });

        modelBuilder.Entity<_RefSiegeLvlSummonMonster>(entity =>
        {
            entity.HasKey(e => e.RefObjID);

            entity.ToTable("_RefSiegeLvlSummonMonster");

            entity.Property(e => e.RefObjID).ValueGeneratedNever();
        });

        modelBuilder.Entity<_RefSiegeQuest>(entity =>
        {
            entity.HasKey(e => e.QuestID).HasName("PK___RefSiegeQuest__78529833");

            entity.ToTable("_RefSiegeQuest");

            entity.HasIndex(e => e.QuestName, "IX_RefSiegeQuest_QuestName").HasFillFactor(71);

            entity.Property(e => e.QuestName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefSiegeQuestReward>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefSiegeQuestReward");

            entity.HasIndex(e => e.QuestID, "IX_RefSiegeQuestReward_QuestID").HasFillFactor(71);
        });

        modelBuilder.Entity<_RefSiegeStructUpgrade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefSiegeStructUpgrade");

            entity.Property(e => e.BaseStructcodename)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.Structname)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.UpgradeStructname1)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.UpgradeStructname2)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.UpgradeStructname3)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.UpgradeStructname4)
                .HasMaxLength(129)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefSkill>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK___RefSkill__01C9240F");

            entity.ToTable("_RefSkill");

            entity.HasIndex(e => e.Basic_Code, "IX_RefSkill_BasicCode").HasFillFactor(90);

            entity.Property(e => e.Basic_Code)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Basic_Group)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Basic_Name)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.UI_IconFile)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.UI_SkillName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.UI_SkillStudy_Desc)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.UI_SkillToolTip)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.UI_SkillToolTip_Desc)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefSkillByItemOptLevel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefSkillByItemOptLevel");

            entity.HasIndex(e => new { e.RefSkillID, e.Link }, "IX__RefSkillByItemOptLevel").IsUnique();
        });

        modelBuilder.Entity<_RefSkillGroup>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK___RefSkillGroup__52593CB8");

            entity.ToTable("_RefSkillGroup");

            entity.Property(e => e.Code)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefSkillMastery>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Tab_RefSkillMast__23DE44F1");

            entity.ToTable("_RefSkillMastery");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_RefTeleLink>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefTeleLink");

            entity.HasIndex(e => e.OwnerTeleport, "IX__RefTeleLinks")
                .IsClustered()
                .HasFillFactor(90);
        });

        modelBuilder.Entity<_RefTeleport>(entity =>
        {
            entity.ToTable("_RefTeleport");

            entity.Property(e => e.AssocRefObjCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.GenWorldID).HasDefaultValueSql("(1)");
            entity.Property(e => e.ZoneName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefTreatItemOfShop>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_RefTreatItemOfShop");

            entity.HasIndex(e => new { e.Country, e.RefShopCodeName, e.Cash, e.TypeID1, e.TypeID2, e.TypeID3, e.TypeID4, e.RefItemCodeName, e.AcceptOrReject, e.FourCC }, "IX__RefTreatItemOfShop").IsUnique();

            entity.Property(e => e.Param1_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param2_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param3_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.Param4_Desc128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("('xxx')");
            entity.Property(e => e.RefItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.RefShopCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_RefTrigger>(entity =>
        {
            entity.ToTable("_RefTrigger");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Comment512)
                .HasMaxLength(513)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefTriggerAction>(entity =>
        {
            entity.ToTable("_RefTriggerAction");

            entity.Property(e => e.ParamGroupCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefTriggerActionParam>(entity =>
        {
            entity.ToTable("_RefTriggerActionParam");

            entity.Property(e => e.GroupCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Value)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ValueCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefTriggerBindAction>(entity =>
        {
            entity.ToTable("_RefTriggerBindAction");
        });

        modelBuilder.Entity<_RefTriggerBindCondition>(entity =>
        {
            entity.ToTable("_RefTriggerBindCondition");
        });

        modelBuilder.Entity<_RefTriggerBindEvent>(entity =>
        {
            entity.ToTable("_RefTriggerBindEvent");
        });

        modelBuilder.Entity<_RefTriggerCategory>(entity =>
        {
            entity.ToTable("_RefTriggerCategory");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ObjName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefTriggerCategoryBindTrigger>(entity =>
        {
            entity.ToTable("_RefTriggerCategoryBindTrigger");
        });

        modelBuilder.Entity<_RefTriggerCommon>(entity =>
        {
            entity.ToTable("_RefTriggerCommon");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ObjName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefTriggerCondition>(entity =>
        {
            entity.ToTable("_RefTriggerCondition");

            entity.Property(e => e.OnFalse)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.OnTrue)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ParamGroupCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefTriggerConditionParam>(entity =>
        {
            entity.ToTable("_RefTriggerConditionParam");

            entity.Property(e => e.GroupCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Value)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ValueCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefTriggerEvent>(entity =>
        {
            entity.ToTable("_RefTriggerEvent");
        });

        modelBuilder.Entity<_RefTriggerVariable>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__TriggerVariable");

            entity.ToTable("_RefTriggerVariable");

            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Comment128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Type)
                .HasMaxLength(33)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RefUIString_Mt>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__RefDesignString_Mt");

            entity.ToTable("_RefUIString_Mt");

            entity.Property(e => e.GroupCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Value)
                .HasMaxLength(513)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.ValueCodeName128)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_RentItemInfo>(entity =>
        {
            entity.HasKey(e => e.nItemDBID);

            entity.ToTable("_RentItemInfo");

            entity.Property(e => e.nItemDBID).ValueGeneratedNever();
            entity.Property(e => e.MeterRateTime).HasColumnType("smalldatetime");
            entity.Property(e => e.PeriodBeginTime).HasColumnType("smalldatetime");
            entity.Property(e => e.PeriodEndTime).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_ResultOfPackageItemToMappingWithServerSide>(entity =>
        {
            entity.HasKey(e => new { e.CharID, e.Slot, e.RefItemSerial64, e.RefItemDBID });

            entity.ToTable("_ResultOfPackageItemToMappingWithServerSide");
        });

        modelBuilder.Entity<_Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleIdx).HasName("PK___Schedule__425FD07F");

            entity.ToTable("_Schedule");

            entity.Property(e => e.DateEnd).HasColumnType("datetime");
            entity.Property(e => e.DateStart).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.Param)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_ServerEvent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_ServerEvent");

            entity.HasIndex(e => e.ID, "IX_ServerEvent")
                .IsClustered()
                .HasFillFactor(90);
        });

        modelBuilder.Entity<_ServerEventReward>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_ServerEventReward");

            entity.HasIndex(e => e.RewardID, "IX_ServerEventReward_RewardID").HasFillFactor(90);

            entity.HasIndex(e => e.ServerEventID, "IX_ServerEventReward_ServerEventID")
                .IsClustered()
                .HasFillFactor(90);
        });

        modelBuilder.Entity<_ShopItemStockQuantity>(entity =>
        {
            entity.HasKey(e => new { e.Country, e.RefShopGroupCodeName, e.RefPackageItemCodeName });

            entity.ToTable("_ShopItemStockQuantity");

            entity.Property(e => e.RefShopGroupCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
            entity.Property(e => e.RefPackageItemCodeName)
                .HasMaxLength(129)
                .IsUnicode(false)
                .UseCollation("Korean_Wansung_CI_AS");
        });

        modelBuilder.Entity<_SiegeFortress>(entity =>
        {
            entity.HasKey(e => e.FortressID);

            entity.ToTable("_SiegeFortress");

            entity.HasIndex(e => e.GuildID, "IX__SiegeFortress").HasFillFactor(90);

            entity.Property(e => e.FortressID).ValueGeneratedNever();
            entity.Property(e => e.CreatedDungeonCount).HasDefaultValueSql("(0)");
            entity.Property(e => e.CreatedDungeonTime).HasColumnType("datetime");
            entity.Property(e => e.Introduction)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.IntroductionModificationPermission).HasDefaultValueSql("(1)");
        });

        modelBuilder.Entity<_SiegeFortressBattleRecord>(entity =>
        {
            entity.HasKey(e => new { e.FortressID, e.CharID });

            entity.ToTable("_SiegeFortressBattleRecord");

            entity.Property(e => e.RankUpDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<_SiegeFortressItemForge>(entity =>
        {
            entity.HasKey(e => new { e.FortressID, e.ItemRefID });

            entity.ToTable("_SiegeFortressItemForge");

            entity.Property(e => e.Amount).HasDefaultValueSql("(1)");
            entity.Property(e => e.FinishDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<_SiegeFortressObject>(entity =>
        {
            entity.ToTable("_SiegeFortressObject");

            entity.HasIndex(e => e.FortressID, "IX__SiegeFortressObject").HasFillFactor(90);
        });

        modelBuilder.Entity<_SiegeFortressRequest>(entity =>
        {
            entity.HasKey(e => new { e.FortressID, e.GuildID });

            entity.ToTable("_SiegeFortressRequest");
        });

        modelBuilder.Entity<_SiegeFortressStoneState>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_SiegeFortressStoneState");

            entity.HasIndex(e => e.FortressID, "IX__SiegeFortressStoneState").HasFillFactor(90);
        });

        modelBuilder.Entity<_SiegeFortressStruct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_SiegeFortressStruct");

            entity.HasIndex(e => e.FortressID, "IX__SiegeFortressStruct").HasFillFactor(90);

            entity.Property(e => e.MakeDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<_Skill_BaoHiem_TNET>(entity =>
        {
            entity.HasKey(e => e.CharID);

            entity.ToTable("_Skill_BaoHiem_TNET");

            entity.Property(e => e.CharID).ValueGeneratedNever();
            entity.Property(e => e.CharName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.Regdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<_StaticAvatar>(entity =>
        {
            entity.HasKey(e => e.CharID);

            entity.ToTable("_StaticAvatar");

            entity.Property(e => e.CharID).ValueGeneratedNever();
        });

        modelBuilder.Entity<_TimedJob>(entity =>
        {
            entity.HasKey(e => e.ID).IsClustered(false);

            entity.ToTable("_TimedJob");

            entity.HasIndex(e => e.CharID, "IX__TimedJob")
                .IsClustered()
                .HasFillFactor(90);

            entity.Property(e => e.Data3).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data4).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data5).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data6).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data7).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data8).HasDefaultValueSql("(0)");
            entity.Property(e => e.JID).HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_TimedJobForPet>(entity =>
        {
            entity.HasKey(e => e.ID).IsClustered(false);

            entity.ToTable("_TimedJobForPet");

            entity.Property(e => e.Data3).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data4).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data5).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data6).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data7).HasDefaultValueSql("(0)");
            entity.Property(e => e.Data8).HasDefaultValueSql("(0)");
            entity.Property(e => e.JID).HasDefaultValueSql("(0)");
        });

        modelBuilder.Entity<_TrainingCamp>(entity =>
        {
            entity.ToTable("_TrainingCamp");

            entity.Property(e => e.Comment)
                .HasMaxLength(2048)
                .IsUnicode(false);
            entity.Property(e => e.CommentTitle)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.LatestEvaluationDate).HasColumnType("datetime");
            entity.Property(e => e.Rank).HasDefaultValueSql("(5)");
        });

        modelBuilder.Entity<_TrainingCampBuffStatus>(entity =>
        {
            entity.HasKey(e => new { e.CampID, e.RecipientCharID, e.BuffSlotIdx });

            entity.ToTable("_TrainingCampBuffStatus");

            entity.Property(e => e.StartingTime)
                .HasDefaultValueSql("('2000-01-01')")
                .HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_TrainingCampHonorRank>(entity =>
        {
            entity.HasKey(e => e.Ranking);

            entity.ToTable("_TrainingCampHonorRank");

            entity.Property(e => e.Ranking).ValueGeneratedNever();
        });

        modelBuilder.Entity<_TrainingCampHonorRankUpdateDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_TrainingCampHonorRankUpdateDate");

            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<_TrainingCampMember>(entity =>
        {
            entity.HasKey(e => new { e.CampID, e.CharID });

            entity.ToTable("_TrainingCampMember");

            entity.Property(e => e.CharName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.JoinDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<_TrainingCampSubMentorHonorPoint>(entity =>
        {
            entity.HasKey(e => e.CharID);

            entity.ToTable("_TrainingCampSubMentorHonorPoint");

            entity.Property(e => e.CharID).ValueGeneratedNever();
        });

        modelBuilder.Entity<_TrijobRanking4WEB>(entity =>
        {
            entity.HasKey(e => new { e.TrijobType, e.RankType, e.Rank });

            entity.ToTable("_TrijobRanking4WEB");

            entity.HasIndex(e => e.NickName, "IX__TrijobRanking4WEB").HasFillFactor(90);

            entity.Property(e => e.NickName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<_TrijobReward>(entity =>
        {
            entity.HasKey(e => e.JobType);
        });

        modelBuilder.Entity<_User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_User");

            entity.HasIndex(e => e.CharID, "IX__CharID")
                .IsUnique()
                .HasFillFactor(90);

            entity.HasIndex(e => e.UserJID, "IX__User")
                .IsClustered()
                .HasFillFactor(90);
        });

        modelBuilder.Entity<_UserBalance_Nhat>(entity =>
        {
            entity.HasKey(e => e.JID);

            entity.ToTable("_UserBalance_Nhat");

            entity.Property(e => e.JID).ValueGeneratedNever();
            entity.Property(e => e.Balance).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<_UserOld>(entity =>
        {
            entity.HasKey(e => e.UserJID).HasName("PK__UserCharList");

            entity.ToTable("_UserOld");

            entity.Property(e => e.UserJID).ValueGeneratedNever();
        });

        modelBuilder.Entity<_WebShop_SRO_Log>(entity =>
        {
            entity.ToTable("_WebShop_SRO_Log");

            entity.Property(e => e.Balance_After_Buy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Balance_Before_Buy).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.CodeName128)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.IP)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<test_item_TNET>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("test_item_TNET");

            entity.Property(e => e.CodeName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
