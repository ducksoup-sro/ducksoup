using System.Data.Entity;

namespace API.Database.SRO_VT_SHARD
{
    public partial class SRO_VT_SHARD : DbContext
    {
        public SRO_VT_SHARD()
            : base(DatabaseManager.SroVtShardConnectionString)
        {
        }

        public virtual DbSet<C_AcademyChat> C_AcademyChat { get; set; }
        public virtual DbSet<C_AccountJID> C_AccountJID { get; set; }
        public virtual DbSet<C_AllChat> C_AllChat { get; set; }
        public virtual DbSet<C_AlliedClans> C_AlliedClans { get; set; }
        public virtual DbSet<C_AssociationReputation> C_AssociationReputation { get; set; }
        public virtual DbSet<C_BindingOptionWithItem> C_BindingOptionWithItem { get; set; }
        public virtual DbSet<C_Char> C_Char { get; set; }
        public virtual DbSet<C_CharCollectionBook> C_CharCollectionBook { get; set; }
        public virtual DbSet<C_CharCOS> C_CharCOS { get; set; }
        public virtual DbSet<C_CharInstanceWorldData> C_CharInstanceWorldData { get; set; }
        public virtual DbSet<C_CharNameList> C_CharNameList { get; set; }
        public virtual DbSet<C_CharNickNameList> C_CharNickNameList { get; set; }
        public virtual DbSet<C_CharQuest> C_CharQuest { get; set; }
        public virtual DbSet<C_CharSkill> C_CharSkill { get; set; }
        public virtual DbSet<C_CharSkillMastery> C_CharSkillMastery { get; set; }
        public virtual DbSet<C_CharTrijob> C_CharTrijob { get; set; }
        public virtual DbSet<C_Chest> C_Chest { get; set; }
        public virtual DbSet<C_DeletedChar> C_DeletedChar { get; set; }
        public virtual DbSet<C_ExploitLog> C_ExploitLog { get; set; }
        public virtual DbSet<C_GlobalChat> C_GlobalChat { get; set; }
        public virtual DbSet<C_GPHistory> C_GPHistory { get; set; }
        public virtual DbSet<C_Guild> C_Guild { get; set; }
        public virtual DbSet<C_GuildChat> C_GuildChat { get; set; }
        public virtual DbSet<C_GuildChest> C_GuildChest { get; set; }
        public virtual DbSet<C_GuildMember> C_GuildMember { get; set; }
        public virtual DbSet<C_GuildWar> C_GuildWar { get; set; }
        public virtual DbSet<C_InvCOS> C_InvCOS { get; set; }
        public virtual DbSet<C_Inventory> C_Inventory { get; set; }
        public virtual DbSet<C_InventoryForAvatar> C_InventoryForAvatar { get; set; }
        public virtual DbSet<C_InventoryForLinkedStorage> C_InventoryForLinkedStorage { get; set; }
        public virtual DbSet<C_ItemPool> C_ItemPool { get; set; }
        public virtual DbSet<C_ItemQuotation> C_ItemQuotation { get; set; }
        public virtual DbSet<C_Items> C_Items { get; set; }
        public virtual DbSet<C_Memo> C_Memo { get; set; }
        public virtual DbSet<C_OldTrijob> C_OldTrijob { get; set; }
        public virtual DbSet<C_PrivateChat> C_PrivateChat { get; set; }
        public virtual DbSet<C_RefEventReward> C_RefEventReward { get; set; }
        public virtual DbSet<C_RefEventZone> C_RefEventZone { get; set; }
        public virtual DbSet<C_RefGachaNpcMap> C_RefGachaNpcMap { get; set; }
        public virtual DbSet<C_RefGame_World> C_RefGame_World { get; set; }
        public virtual DbSet<C_RefGameWorldBindGameWorldGroup> C_RefGameWorldBindGameWorldGroup { get; set; }
        public virtual DbSet<C_RefGameWorldBindTriggerCategory> C_RefGameWorldBindTriggerCategory { get; set; }
        public virtual DbSet<C_RefGameWorldGroup> C_RefGameWorldGroup { get; set; }
        public virtual DbSet<C_RefGameWorldGroup_Config> C_RefGameWorldGroup_Config { get; set; }
        public virtual DbSet<C_RefHWANLevel> C_RefHWANLevel { get; set; }
        public virtual DbSet<C_RefLevel> C_RefLevel { get; set; }
        public virtual DbSet<C_RefMagicOpt> C_RefMagicOpt { get; set; }
        public virtual DbSet<C_RefMappingShopGroup> C_RefMappingShopGroup { get; set; }
        public virtual DbSet<C_RefMappingShopWithTab> C_RefMappingShopWithTab { get; set; }
        public virtual DbSet<C_RefObjChar> C_RefObjChar { get; set; }
        public virtual DbSet<C_RefObjCharExtraSkill> C_RefObjCharExtraSkill { get; set; }
        public virtual DbSet<C_RefObjCommon> C_RefObjCommon { get; set; }
        public virtual DbSet<C_RefObjItem> C_RefObjItem { get; set; }
        public virtual DbSet<C_RefObjStruct> C_RefObjStruct { get; set; }
        public virtual DbSet<C_RefOptionalTeleport> C_RefOptionalTeleport { get; set; }
        public virtual DbSet<C_RefPackageItem> C_RefPackageItem { get; set; }
        public virtual DbSet<C_RefPricePolicyOfItem> C_RefPricePolicyOfItem { get; set; }
        public virtual DbSet<C_RefQuestReward> C_RefQuestReward { get; set; }
        public virtual DbSet<C_RefRegion> C_RefRegion { get; set; }
        public virtual DbSet<C_RefRentItem> C_RefRentItem { get; set; }
        public virtual DbSet<C_RefRewardPolicyToSellPackageItem> C_RefRewardPolicyToSellPackageItem { get; set; }
        public virtual DbSet<C_RefScheduleDefine> C_RefScheduleDefine { get; set; }
        public virtual DbSet<C_RefServerEvent> C_RefServerEvent { get; set; }
        public virtual DbSet<C_RefServerEventReward> C_RefServerEventReward { get; set; }
        public virtual DbSet<C_RefShop> C_RefShop { get; set; }
        public virtual DbSet<C_RefShopGoods> C_RefShopGoods { get; set; }
        public virtual DbSet<C_RefShopGroup> C_RefShopGroup { get; set; }
        public virtual DbSet<C_RefShopItemGroup> C_RefShopItemGroup { get; set; }
        public virtual DbSet<C_RefShopItemStockPeriod> C_RefShopItemStockPeriod { get; set; }
        public virtual DbSet<C_RefShopObject> C_RefShopObject { get; set; }
        public virtual DbSet<C_RefShopTab> C_RefShopTab { get; set; }
        public virtual DbSet<C_RefShopTabGroup> C_RefShopTabGroup { get; set; }
        public virtual DbSet<C_RefSiegeBlessBuff> C_RefSiegeBlessBuff { get; set; }
        public virtual DbSet<C_RefSiegeDungeon> C_RefSiegeDungeon { get; set; }
        public virtual DbSet<C_RefSiegeFortress> C_RefSiegeFortress { get; set; }
        public virtual DbSet<C_RefSiegeFortressBattleRank> C_RefSiegeFortressBattleRank { get; set; }
        public virtual DbSet<C_RefSiegeFortressGuard> C_RefSiegeFortressGuard { get; set; }
        public virtual DbSet<C_RefSiegeFortressItemForge> C_RefSiegeFortressItemForge { get; set; }
        public virtual DbSet<C_RefSiegeLvlSummonMonster> C_RefSiegeLvlSummonMonster { get; set; }
        public virtual DbSet<C_RefSiegeQuest> C_RefSiegeQuest { get; set; }
        public virtual DbSet<C_RefSkill> C_RefSkill { get; set; }
        public virtual DbSet<C_RefSkillGroup> C_RefSkillGroup { get; set; }
        public virtual DbSet<C_RefSkillMastery> C_RefSkillMastery { get; set; }
        public virtual DbSet<C_RefTeleport> C_RefTeleport { get; set; }
        public virtual DbSet<C_RefTrigger> C_RefTrigger { get; set; }
        public virtual DbSet<C_RefTriggerAction> C_RefTriggerAction { get; set; }
        public virtual DbSet<C_RefTriggerActionParam> C_RefTriggerActionParam { get; set; }
        public virtual DbSet<C_RefTriggerBindAction> C_RefTriggerBindAction { get; set; }
        public virtual DbSet<C_RefTriggerBindCondition> C_RefTriggerBindCondition { get; set; }
        public virtual DbSet<C_RefTriggerBindEvent> C_RefTriggerBindEvent { get; set; }
        public virtual DbSet<C_RefTriggerCategory> C_RefTriggerCategory { get; set; }
        public virtual DbSet<C_RefTriggerCategoryBindTrigger> C_RefTriggerCategoryBindTrigger { get; set; }
        public virtual DbSet<C_RefTriggerCommon> C_RefTriggerCommon { get; set; }
        public virtual DbSet<C_RefTriggerCondition> C_RefTriggerCondition { get; set; }
        public virtual DbSet<C_RefTriggerConditionParam> C_RefTriggerConditionParam { get; set; }
        public virtual DbSet<C_RefTriggerEvent> C_RefTriggerEvent { get; set; }
        public virtual DbSet<C_RefTriggerVariable> C_RefTriggerVariable { get; set; }
        public virtual DbSet<C_RefUIString_Mt> C_RefUIString_Mt { get; set; }
        public virtual DbSet<C_RentItemInfo> C_RentItemInfo { get; set; }
        public virtual DbSet<C_ResultOfPackageItemToMappingWithServerSide> C_ResultOfPackageItemToMappingWithServerSide { get; set; }
        public virtual DbSet<C_Schedule> C_Schedule { get; set; }
        public virtual DbSet<C_ShopItemStockQuantity> C_ShopItemStockQuantity { get; set; }
        public virtual DbSet<C_SiegeFortress> C_SiegeFortress { get; set; }
        public virtual DbSet<C_SiegeFortressBattleRecord> C_SiegeFortressBattleRecord { get; set; }
        public virtual DbSet<C_SiegeFortressItemForge> C_SiegeFortressItemForge { get; set; }
        public virtual DbSet<C_SiegeFortressObject> C_SiegeFortressObject { get; set; }
        public virtual DbSet<C_SiegeFortressRequest> C_SiegeFortressRequest { get; set; }
        public virtual DbSet<C_Skill_BaoHiem_TNET> C_Skill_BaoHiem_TNET { get; set; }
        public virtual DbSet<C_StaticAvatar> C_StaticAvatar { get; set; }
        public virtual DbSet<C_TimedJob> C_TimedJob { get; set; }
        public virtual DbSet<C_TimedJobForPet> C_TimedJobForPet { get; set; }
        public virtual DbSet<C_TrainingCamp> C_TrainingCamp { get; set; }
        public virtual DbSet<C_TrainingCampBuffStatus> C_TrainingCampBuffStatus { get; set; }
        public virtual DbSet<C_TrainingCampHonorRank> C_TrainingCampHonorRank { get; set; }
        public virtual DbSet<C_TrainingCampMember> C_TrainingCampMember { get; set; }
        public virtual DbSet<C_TrainingCampSubMentorHonorPoint> C_TrainingCampSubMentorHonorPoint { get; set; }
        public virtual DbSet<C_TrijobRanking4WEB> C_TrijobRanking4WEB { get; set; }
        public virtual DbSet<C_TrijobRewards> C_TrijobRewards { get; set; }
        public virtual DbSet<C_UnionChat> C_UnionChat { get; set; }
        public virtual DbSet<C_Uniques> C_Uniques { get; set; }
        public virtual DbSet<C_UserBalance_Nhat> C_UserBalance_Nhat { get; set; }
        public virtual DbSet<C_UserOld> C_UserOld { get; set; }
        public virtual DbSet<C_WebShop_SRO_Log> C_WebShop_SRO_Log { get; set; }
        public virtual DbSet<dtproperties> dtproperties { get; set; }
        public virtual DbSet<Tab_RefHive> Tab_RefHive { get; set; }
        public virtual DbSet<Tab_RefNest> Tab_RefNest { get; set; }
        public virtual DbSet<Tab_RefRanking_HunterActivity> Tab_RefRanking_HunterActivity { get; set; }
        public virtual DbSet<Tab_RefRanking_HunterContribution> Tab_RefRanking_HunterContribution { get; set; }
        public virtual DbSet<Tab_RefRanking_RobberActivity> Tab_RefRanking_RobberActivity { get; set; }
        public virtual DbSet<Tab_RefRanking_RobberContribution> Tab_RefRanking_RobberContribution { get; set; }
        public virtual DbSet<Tab_RefRanking_TraderActivity> Tab_RefRanking_TraderActivity { get; set; }
        public virtual DbSet<Tab_RefRanking_TraderContribution> Tab_RefRanking_TraderContribution { get; set; }
        public virtual DbSet<Tab_RefSpawnToolVersion> Tab_RefSpawnToolVersion { get; set; }
        public virtual DbSet<Tab_RefTactics> Tab_RefTactics { get; set; }
        public virtual DbSet<C_BlockedWhisperers> C_BlockedWhisperers { get; set; }
        public virtual DbSet<C_CharTrijobSafeTrade> C_CharTrijobSafeTrade { get; set; }
        public virtual DbSet<C_ChestInfo> C_ChestInfo { get; set; }
        public virtual DbSet<C_ClientConfig> C_ClientConfig { get; set; }
        public virtual DbSet<C_FlagWorld_EventParticipants> C_FlagWorld_EventParticipants { get; set; }
        public virtual DbSet<C_FleaMarketNetwork> C_FleaMarketNetwork { get; set; }
        public virtual DbSet<C_Friend> C_Friend { get; set; }
        public virtual DbSet<C_LatestItemSerial> C_LatestItemSerial { get; set; }
        public virtual DbSet<C_Magopt> C_Magopt { get; set; }
        public virtual DbSet<C_OpenMarket> C_OpenMarket { get; set; }
        public virtual DbSet<C_RefAbilityByItemOptLevel> C_RefAbilityByItemOptLevel { get; set; }
        public virtual DbSet<C_RefAccessPermissionOfShop> C_RefAccessPermissionOfShop { get; set; }
        public virtual DbSet<C_RefAlchemyMerit> C_RefAlchemyMerit { get; set; }
        public virtual DbSet<C_RefCharDefault_Quest> C_RefCharDefault_Quest { get; set; }
        public virtual DbSet<C_RefCharDefault_Skill> C_RefCharDefault_Skill { get; set; }
        public virtual DbSet<C_RefCharDefault_SkillMastery> C_RefCharDefault_SkillMastery { get; set; }
        public virtual DbSet<C_RefCharGen> C_RefCharGen { get; set; }
        public virtual DbSet<C_RefClimate> C_RefClimate { get; set; }
        public virtual DbSet<C_RefCollectionBook_Item> C_RefCollectionBook_Item { get; set; }
        public virtual DbSet<C_RefCollectionBook_Theme> C_RefCollectionBook_Theme { get; set; }
        public virtual DbSet<C_RefConditionToBuyScrapItem> C_RefConditionToBuyScrapItem { get; set; }
        public virtual DbSet<C_RefConditionToSellPackageItem> C_RefConditionToSellPackageItem { get; set; }
        public virtual DbSet<C_RefConditionToSellScrapItem> C_RefConditionToSellScrapItem { get; set; }
        public virtual DbSet<C_RefCustomizingReservedItemDropForMonster> C_RefCustomizingReservedItemDropForMonster { get; set; }
        public virtual DbSet<C_RefDropClassSel_Alchemy_ATTRStone> C_RefDropClassSel_Alchemy_ATTRStone { get; set; }
        public virtual DbSet<C_RefDropClassSel_Alchemy_MagicStone> C_RefDropClassSel_Alchemy_MagicStone { get; set; }
        public virtual DbSet<C_RefDropClassSel_Alchemy_Tablet> C_RefDropClassSel_Alchemy_Tablet { get; set; }
        public virtual DbSet<C_RefDropClassSel_Ammo> C_RefDropClassSel_Ammo { get; set; }
        public virtual DbSet<C_RefDropClassSel_Cure> C_RefDropClassSel_Cure { get; set; }
        public virtual DbSet<C_RefDropClassSel_Equip> C_RefDropClassSel_Equip { get; set; }
        public virtual DbSet<C_RefDropClassSel_RareEquip> C_RefDropClassSel_RareEquip { get; set; }
        public virtual DbSet<C_RefDropClassSel_Recover> C_RefDropClassSel_Recover { get; set; }
        public virtual DbSet<C_RefDropClassSel_Reinforce> C_RefDropClassSel_Reinforce { get; set; }
        public virtual DbSet<C_RefDropClassSel_Scroll> C_RefDropClassSel_Scroll { get; set; }
        public virtual DbSet<C_RefDropGold> C_RefDropGold { get; set; }
        public virtual DbSet<C_RefDropItemAssign> C_RefDropItemAssign { get; set; }
        public virtual DbSet<C_RefDropItemGroup> C_RefDropItemGroup { get; set; }
        public virtual DbSet<C_RefDropOptLvlSel> C_RefDropOptLvlSel { get; set; }
        public virtual DbSet<C_RefDummySlot> C_RefDummySlot { get; set; }
        public virtual DbSet<C_RefEvent> C_RefEvent { get; set; }
        public virtual DbSet<C_RefEventRewardItems> C_RefEventRewardItems { get; set; }
        public virtual DbSet<C_RefFmnCategoryTree> C_RefFmnCategoryTree { get; set; }
        public virtual DbSet<C_RefFmnTidGroup> C_RefFmnTidGroup { get; set; }
        public virtual DbSet<C_RefFmnTidGroupMap> C_RefFmnTidGroupMap { get; set; }
        public virtual DbSet<C_RefGachaCode> C_RefGachaCode { get; set; }
        public virtual DbSet<C_RefGachaItemSet> C_RefGachaItemSet { get; set; }
        public virtual DbSet<C_RefGame_World_Config> C_RefGame_World_Config { get; set; }
        public virtual DbSet<C_RefGameWorldNPC> C_RefGameWorldNPC { get; set; }
        public virtual DbSet<C_RefInstance_World_Region> C_RefInstance_World_Region { get; set; }
        public virtual DbSet<C_RefInstance_World_Start_Pos> C_RefInstance_World_Start_Pos { get; set; }
        public virtual DbSet<C_RefLatestItemSerial> C_RefLatestItemSerial { get; set; }
        public virtual DbSet<C_RefMagicOptAssign> C_RefMagicOptAssign { get; set; }
        public virtual DbSet<C_RefMagicOptByItemOptLevel> C_RefMagicOptByItemOptLevel { get; set; }
        public virtual DbSet<C_RefMagicOptGroup> C_RefMagicOptGroup { get; set; }
        public virtual DbSet<C_RefMonster_AssignedItemDrop> C_RefMonster_AssignedItemDrop { get; set; }
        public virtual DbSet<C_RefMonster_AssignedItemRndDrop> C_RefMonster_AssignedItemRndDrop { get; set; }
        public virtual DbSet<C_RefQuest> C_RefQuest { get; set; }
        public virtual DbSet<C_RefQuestRewardItems> C_RefQuestRewardItems { get; set; }
        public virtual DbSet<C_RefRegion_bak> C_RefRegion_bak { get; set; }
        public virtual DbSet<C_RefRegionBindAssocServer> C_RefRegionBindAssocServer { get; set; }
        public virtual DbSet<C_RefRegionBindAssocServer_bak> C_RefRegionBindAssocServer_bak { get; set; }
        public virtual DbSet<C_RefRewardPolicyToBuyScrapItem> C_RefRewardPolicyToBuyScrapItem { get; set; }
        public virtual DbSet<C_RefRewardPolicyToSellScrapItem> C_RefRewardPolicyToSellScrapItem { get; set; }
        public virtual DbSet<C_RefScrapOfPackageItem> C_RefScrapOfPackageItem { get; set; }
        public virtual DbSet<C_RefServerEventReward_ExpUPForPlayers> C_RefServerEventReward_ExpUPForPlayers { get; set; }
        public virtual DbSet<C_RefServerEventReward_SpawnMonster> C_RefServerEventReward_SpawnMonster { get; set; }
        public virtual DbSet<C_RefSetItemGroup> C_RefSetItemGroup { get; set; }
        public virtual DbSet<C_RefShardContentConfig> C_RefShardContentConfig { get; set; }
        public virtual DbSet<C_RefSiegeFortressRewards> C_RefSiegeFortressRewards { get; set; }
        public virtual DbSet<C_RefSiegeQuestReward> C_RefSiegeQuestReward { get; set; }
        public virtual DbSet<C_RefSiegeStructUpgrade> C_RefSiegeStructUpgrade { get; set; }
        public virtual DbSet<C_RefSkillByItemOptLevel> C_RefSkillByItemOptLevel { get; set; }
        public virtual DbSet<C_RefTeleLink> C_RefTeleLink { get; set; }
        public virtual DbSet<C_RefTreatItemOfShop> C_RefTreatItemOfShop { get; set; }
        public virtual DbSet<C_ServerEvent> C_ServerEvent { get; set; }
        public virtual DbSet<C_ServerEventReward> C_ServerEventReward { get; set; }
        public virtual DbSet<C_SiegeFortressStoneState> C_SiegeFortressStoneState { get; set; }
        public virtual DbSet<C_SiegeFortressStruct> C_SiegeFortressStruct { get; set; }
        public virtual DbSet<C_User> C_User { get; set; }
        public virtual DbSet<Tab_RefAISkill> Tab_RefAISkill { get; set; }
        public virtual DbSet<TimItemOnChar> TimItemOnChar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<C_AcademyChat>()
                .Property(e => e.GuardianName)
                .IsUnicode(false);

            modelBuilder.Entity<C_AcademyChat>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_AcademyChat>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<C_AcademyChat>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<C_AccountJID>()
                .Property(e => e.AccountID)
                .IsUnicode(false);

            modelBuilder.Entity<C_AllChat>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_AllChat>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<C_AllChat>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<C_AlliedClans>()
                .HasMany(e => e.C_Guild8)
                .WithOptional(e => e.C_AlliedClans8)
                .HasForeignKey(e => e.Alliance);

            modelBuilder.Entity<C_AssociationReputation>()
                .Property(e => e.AssociationCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_AssociationReputation>()
                .Property(e => e.AssociationTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Char>()
                .Property(e => e.CharName16)
                .IsUnicode(false);

            modelBuilder.Entity<C_Char>()
                .Property(e => e.NickName16)
                .IsUnicode(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_BlockedWhisperers)
                .WithRequired(e => e.C_Char)
                .HasForeignKey(e => e.OwnerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_CharCOS)
                .WithRequired(e => e.C_Char)
                .HasForeignKey(e => e.OwnerCharID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_CharSkill)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_CharSkillMastery)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasOptional(e => e.C_CharTrijob)
                .WithRequired(e => e.C_Char);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_FleaMarketNetwork)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_Friend)
                .WithRequired(e => e.C_Char)
                .HasForeignKey(e => e.CharID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_Friend1)
                .WithRequired(e => e.C_Char1)
                .HasForeignKey(e => e.FriendCharID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_GuildMember)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_Inventory)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_InventoryForAvatar)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_Memo)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasOptional(e => e.C_StaticAvatar)
                .WithRequired(e => e.C_Char);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_TimedJob)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_TrainingCampMember)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Char>()
                .HasOptional(e => e.C_TrainingCampSubMentorHonorPoint)
                .WithRequired(e => e.C_Char);

            modelBuilder.Entity<C_Char>()
                .HasMany(e => e.C_User)
                .WithRequired(e => e.C_Char)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_CharCOS>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_CharCOS>()
                .HasMany(e => e.C_InvCOS)
                .WithRequired(e => e.C_CharCOS)
                .HasForeignKey(e => e.COSID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_CharNameList>()
                .Property(e => e.CharName16)
                .IsUnicode(false);

            modelBuilder.Entity<C_CharNickNameList>()
                .Property(e => e.NickName16)
                .IsUnicode(false);

            modelBuilder.Entity<C_CharTrijob>()
                .HasMany(e => e.C_CharTrijobSafeTrade)
                .WithRequired(e => e.C_CharTrijob)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_ExploitLog>()
                .Property(e => e.DetectedApp)
                .IsUnicode(false);

            modelBuilder.Entity<C_ExploitLog>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<C_GlobalChat>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_GlobalChat>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<C_GlobalChat>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<C_GPHistory>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Guild>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<C_Guild>()
                .Property(e => e.MasterCommentTitle)
                .IsUnicode(false);

            modelBuilder.Entity<C_Guild>()
                .Property(e => e.MasterComment)
                .IsUnicode(false);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_AlliedClans)
                .WithOptional(e => e.C_Guild)
                .HasForeignKey(e => e.Ally1);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_AlliedClans1)
                .WithOptional(e => e.C_Guild1)
                .HasForeignKey(e => e.Ally2);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_AlliedClans2)
                .WithOptional(e => e.C_Guild2)
                .HasForeignKey(e => e.Ally3);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_AlliedClans3)
                .WithOptional(e => e.C_Guild3)
                .HasForeignKey(e => e.Ally4);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_AlliedClans4)
                .WithOptional(e => e.C_Guild4)
                .HasForeignKey(e => e.Ally5);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_AlliedClans5)
                .WithOptional(e => e.C_Guild5)
                .HasForeignKey(e => e.Ally6);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_AlliedClans6)
                .WithOptional(e => e.C_Guild6)
                .HasForeignKey(e => e.Ally7);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_AlliedClans7)
                .WithOptional(e => e.C_Guild7)
                .HasForeignKey(e => e.Ally8);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_GuildChest)
                .WithRequired(e => e.C_Guild)
                .HasForeignKey(e => e.GuildID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_GuildMember)
                .WithRequired(e => e.C_Guild)
                .HasForeignKey(e => e.GuildID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_GuildWar)
                .WithRequired(e => e.C_Guild)
                .HasForeignKey(e => e.Guild1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_GuildWar1)
                .WithRequired(e => e.C_Guild1)
                .HasForeignKey(e => e.Guild2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_SiegeFortress)
                .WithRequired(e => e.C_Guild)
                .HasForeignKey(e => e.GuildID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Guild>()
                .HasMany(e => e.C_SiegeFortressRequest)
                .WithRequired(e => e.C_Guild)
                .HasForeignKey(e => e.GuildID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_GuildChat>()
                .Property(e => e.Guild)
                .IsUnicode(false);

            modelBuilder.Entity<C_GuildChat>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_GuildChat>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<C_GuildChat>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<C_GuildMember>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_GuildMember>()
                .Property(e => e.Nickname)
                .IsUnicode(false);

            modelBuilder.Entity<C_Items>()
                .Property(e => e.CreaterName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Items>()
                .HasMany(e => e.C_Chest)
                .WithOptional(e => e.C_Items)
                .HasForeignKey(e => e.ItemID);

            modelBuilder.Entity<C_Items>()
                .HasMany(e => e.C_InvCOS)
                .WithOptional(e => e.C_Items)
                .HasForeignKey(e => e.ItemID);

            modelBuilder.Entity<C_Items>()
                .HasMany(e => e.C_Inventory)
                .WithRequired(e => e.C_Items)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Items>()
                .HasMany(e => e.C_InventoryForAvatar)
                .WithRequired(e => e.C_Items)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Items>()
                .HasMany(e => e.C_InventoryForLinkedStorage)
                .WithRequired(e => e.C_Items)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Items>()
                .HasOptional(e => e.C_ItemPool)
                .WithRequired(e => e.C_Items);

            modelBuilder.Entity<C_Items>()
                .HasMany(e => e.C_OpenMarket)
                .WithRequired(e => e.C_Items)
                .HasForeignKey(e => e.ItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Memo>()
                .Property(e => e.FromCharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Memo>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<C_PrivateChat>()
                .Property(e => e.Sender)
                .IsUnicode(false);

            modelBuilder.Entity<C_PrivateChat>()
                .Property(e => e.Receiver)
                .IsUnicode(false);

            modelBuilder.Entity<C_PrivateChat>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<C_PrivateChat>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventReward>()
                .Property(e => e.EventCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventReward>()
                .Property(e => e.Param1_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventReward>()
                .Property(e => e.Param2_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventReward>()
                .Property(e => e.Param3_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventZone>()
                .Property(e => e.ZoneName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventZone>()
                .Property(e => e.EventName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventZone>()
                .Property(e => e.strParam1)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventZone>()
                .Property(e => e.strParam2)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventZone>()
                .Property(e => e.strParam3)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventZone>()
                .Property(e => e.strParam4)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventZone>()
                .Property(e => e.strParam5)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGame_World>()
                .Property(e => e.WorldCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGame_World>()
                .Property(e => e.ConfigGroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGame_World>()
                .HasMany(e => e.C_RefGameWorldBindGameWorldGroup)
                .WithRequired(e => e.C_RefGame_World)
                .HasForeignKey(e => e.GameWorldID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefGame_World>()
                .HasMany(e => e.C_RefGameWorldBindTriggerCategory)
                .WithRequired(e => e.C_RefGame_World)
                .HasForeignKey(e => e.GameWorldID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefGameWorldGroup>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGameWorldGroup>()
                .Property(e => e.ObjName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGameWorldGroup>()
                .Property(e => e.ConfigGroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGameWorldGroup>()
                .HasMany(e => e.C_RefGameWorldBindGameWorldGroup)
                .WithRequired(e => e.C_RefGameWorldGroup)
                .HasForeignKey(e => e.GameWorldGroupID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefGameWorldGroup_Config>()
                .Property(e => e.GroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGameWorldGroup_Config>()
                .Property(e => e.ValueCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGameWorldGroup_Config>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGameWorldGroup_Config>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefHWANLevel>()
                .Property(e => e.AssocFileObj128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefHWANLevel>()
                .Property(e => e.Title_CH70)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefHWANLevel>()
                .Property(e => e.Title_EU70)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.MOptName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AttrType)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup1)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup2)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup3)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup4)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup5)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup6)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup7)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup8)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup9)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .Property(e => e.AvailItemGroup10)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOpt>()
                .HasMany(e => e.C_RefMagicOptByItemOptLevel)
                .WithRequired(e => e.C_RefMagicOpt)
                .HasForeignKey(e => e.RefMagicOptID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefMappingShopGroup>()
                .Property(e => e.RefShopGroupCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMappingShopGroup>()
                .Property(e => e.RefShopCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMappingShopWithTab>()
                .Property(e => e.RefShopCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMappingShopWithTab>()
                .Property(e => e.RefTabGroupCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.ObjName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.OrgObjCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.NameStrID128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.DescStrID128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.AssocFileObj128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.AssocFileDrop128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.AssocFileIcon128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.AssocFile1_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .Property(e => e.AssocFile2_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .HasMany(e => e.C_RefAbilityByItemOptLevel)
                .WithRequired(e => e.C_RefObjCommon)
                .HasForeignKey(e => e.RefItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .HasMany(e => e.C_RefCustomizingReservedItemDropForMonster)
                .WithRequired(e => e.C_RefObjCommon)
                .HasForeignKey(e => e.RefMonsterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .HasMany(e => e.C_RefDropItemGroup)
                .WithRequired(e => e.C_RefObjCommon)
                .HasForeignKey(e => e.RefItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .HasMany(e => e.C_RefMonster_AssignedItemDrop)
                .WithRequired(e => e.C_RefObjCommon)
                .HasForeignKey(e => e.RefMonsterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .HasMany(e => e.C_RefMonster_AssignedItemDrop1)
                .WithRequired(e => e.C_RefObjCommon1)
                .HasForeignKey(e => e.RefItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefObjCommon>()
                .HasMany(e => e.C_RefMonster_AssignedItemRndDrop)
                .WithRequired(e => e.C_RefObjCommon)
                .HasForeignKey(e => e.RefMonsterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc1_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc2_128)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc3_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc4_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc5_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc6_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc7_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc8_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc9_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc10_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc11_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc12_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc13_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc14_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc15_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc16_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc17_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc18_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc19_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefObjItem>()
                .Property(e => e.Desc20_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefOptionalTeleport>()
                .Property(e => e.ObjName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefOptionalTeleport>()
                .Property(e => e.ZoneName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefOptionalTeleport>()
                .Property(e => e.Param1_Desc_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefOptionalTeleport>()
                .Property(e => e.Param2_Desc_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefOptionalTeleport>()
                .Property(e => e.Param3_Desc_128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPackageItem>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPackageItem>()
                .Property(e => e.ExpandTerm)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPackageItem>()
                .Property(e => e.NameStrID)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPackageItem>()
                .Property(e => e.DescStrID)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPackageItem>()
                .Property(e => e.AssocFileIcon)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPackageItem>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPackageItem>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPackageItem>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPackageItem>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPricePolicyOfItem>()
                .Property(e => e.RefPackageItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPricePolicyOfItem>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPricePolicyOfItem>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPricePolicyOfItem>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefPricePolicyOfItem>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestReward>()
                .Property(e => e.QuestCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestReward>()
                .Property(e => e.APType)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestReward>()
                .Property(e => e.Param1_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestReward>()
                .Property(e => e.Param2_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestReward>()
                .Property(e => e.Param3_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRegion>()
                .Property(e => e.ContinentName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRegion>()
                .Property(e => e.AreaName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRegion>()
                .Property(e => e.AssocFile256)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRentItem>()
                .Property(e => e.RentCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellPackageItem>()
                .Property(e => e.RefPackageItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellPackageItem>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellPackageItem>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellPackageItem>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellPackageItem>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefScheduleDefine>()
                .Property(e => e.ScheduleName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefScheduleDefine>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefServerEvent>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefServerEvent>()
                .HasMany(e => e.C_RefServerEventReward)
                .WithRequired(e => e.C_RefServerEvent)
                .HasForeignKey(e => e.OwnerServerEventID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefServerEventReward>()
                .HasMany(e => e.C_RefServerEventReward_ExpUPForPlayers)
                .WithRequired(e => e.C_RefServerEventReward)
                .HasForeignKey(e => e.OwnerRewardID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefServerEventReward>()
                .HasMany(e => e.C_RefServerEventReward_SpawnMonster)
                .WithRequired(e => e.C_RefServerEventReward)
                .HasForeignKey(e => e.OwnerRewardID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShop>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShop>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShop>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShop>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShop>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGoods>()
                .Property(e => e.RefTabCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGoods>()
                .Property(e => e.RefPackageItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGoods>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGoods>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGoods>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGoods>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGroup>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGroup>()
                .Property(e => e.RefNPCCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGroup>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGroup>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGroup>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopGroup>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopItemGroup>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopItemGroup>()
                .Property(e => e.StrID128_Group)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopItemStockPeriod>()
                .Property(e => e.RefShopGroupCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopItemStockPeriod>()
                .Property(e => e.RefPackageItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopObject>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefMappingShopGroup)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefMappingShopWithTab)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefPackageItem)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefPricePolicyOfItem)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefRewardPolicyToSellPackageItem)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefShop)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefShopGoods)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefShopGroup)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefAccessPermissionOfShop)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefConditionToBuyScrapItem)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefConditionToSellPackageItem)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefConditionToSellScrapItem)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefRewardPolicyToBuyScrapItem)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefRewardPolicyToSellScrapItem)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefScrapOfPackageItem)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefShopTab)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefShopTabGroup)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopObject>()
                .HasMany(e => e.C_RefTreatItemOfShop)
                .WithRequired(e => e.C_RefShopObject)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefShopTab>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopTab>()
                .Property(e => e.RefTabGroupCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopTab>()
                .Property(e => e.StrID128_Tab)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopTabGroup>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShopTabGroup>()
                .Property(e => e.StrID128_Group)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeFortress>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeFortress>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeFortress>()
                .Property(e => e.NameID128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeFortress>()
                .Property(e => e.LinkedTeleportCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeFortress>()
                .Property(e => e.CrestPath128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeFortress>()
                .Property(e => e.RequestNPCName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeFortress>()
                .HasMany(e => e.C_RefSiegeBlessBuff)
                .WithRequired(e => e.C_RefSiegeFortress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefSiegeFortress>()
                .HasMany(e => e.C_RefSiegeFortressRewards)
                .WithRequired(e => e.C_RefSiegeFortress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefSiegeFortressBattleRank>()
                .Property(e => e.RankName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeFortressBattleRank>()
                .Property(e => e.CrestPath128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeQuest>()
                .Property(e => e.QuestName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkill>()
                .Property(e => e.Basic_Code)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkill>()
                .Property(e => e.Basic_Name)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkill>()
                .Property(e => e.Basic_Group)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkill>()
                .Property(e => e.UI_IconFile)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkill>()
                .Property(e => e.UI_SkillName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkill>()
                .Property(e => e.UI_SkillToolTip)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkill>()
                .Property(e => e.UI_SkillToolTip_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkill>()
                .Property(e => e.UI_SkillStudy_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkill>()
                .HasMany(e => e.C_RefSiegeBlessBuff)
                .WithRequired(e => e.C_RefSkill)
                .HasForeignKey(e => e.RefBlessBuffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefSkill>()
                .HasMany(e => e.C_RefSkillByItemOptLevel)
                .WithRequired(e => e.C_RefSkill)
                .HasForeignKey(e => e.RefSkillID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefSkillGroup>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSkillMastery>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTeleport>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTeleport>()
                .Property(e => e.AssocRefObjCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTeleport>()
                .Property(e => e.ZoneName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTrigger>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTrigger>()
                .Property(e => e.Comment512)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTrigger>()
                .HasMany(e => e.C_RefTriggerBindAction)
                .WithRequired(e => e.C_RefTrigger)
                .HasForeignKey(e => e.TriggerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTrigger>()
                .HasMany(e => e.C_RefTriggerBindCondition)
                .WithRequired(e => e.C_RefTrigger)
                .HasForeignKey(e => e.TriggerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTrigger>()
                .HasMany(e => e.C_RefTriggerBindEvent)
                .WithRequired(e => e.C_RefTrigger)
                .HasForeignKey(e => e.TriggerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTrigger>()
                .HasMany(e => e.C_RefTriggerCategoryBindTrigger)
                .WithRequired(e => e.C_RefTrigger)
                .HasForeignKey(e => e.TriggerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTrigger>()
                .HasMany(e => e.C_RefTriggerVariable)
                .WithRequired(e => e.C_RefTrigger)
                .HasForeignKey(e => e.BindTriggerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTriggerAction>()
                .Property(e => e.ParamGroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerAction>()
                .HasMany(e => e.C_RefTriggerBindAction)
                .WithRequired(e => e.C_RefTriggerAction)
                .HasForeignKey(e => e.TriggerActionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTriggerActionParam>()
                .Property(e => e.GroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerActionParam>()
                .Property(e => e.ValueCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerActionParam>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerActionParam>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerCategory>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerCategory>()
                .Property(e => e.ObjName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerCategory>()
                .HasMany(e => e.C_RefGameWorldBindTriggerCategory)
                .WithRequired(e => e.C_RefTriggerCategory)
                .HasForeignKey(e => e.TriggerCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTriggerCommon>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerCommon>()
                .Property(e => e.ObjName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerCommon>()
                .HasMany(e => e.C_RefTriggerAction)
                .WithRequired(e => e.C_RefTriggerCommon)
                .HasForeignKey(e => e.RefTriggerCommonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTriggerCommon>()
                .HasMany(e => e.C_RefTriggerCondition)
                .WithRequired(e => e.C_RefTriggerCommon)
                .HasForeignKey(e => e.RefTriggerCommonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTriggerCommon>()
                .HasMany(e => e.C_RefTriggerEvent)
                .WithRequired(e => e.C_RefTriggerCommon)
                .HasForeignKey(e => e.RefTriggerCommonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTriggerCondition>()
                .Property(e => e.OnTrue)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerCondition>()
                .Property(e => e.OnFalse)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerCondition>()
                .Property(e => e.ParamGroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerCondition>()
                .HasMany(e => e.C_RefTriggerBindCondition)
                .WithRequired(e => e.C_RefTriggerCondition)
                .HasForeignKey(e => e.TriggerConditionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTriggerConditionParam>()
                .Property(e => e.GroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerConditionParam>()
                .Property(e => e.ValueCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerConditionParam>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerConditionParam>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerEvent>()
                .HasMany(e => e.C_RefTriggerBindEvent)
                .WithRequired(e => e.C_RefTriggerEvent)
                .HasForeignKey(e => e.TriggerEventID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_RefTriggerVariable>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerVariable>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTriggerVariable>()
                .Property(e => e.Comment128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefUIString_Mt>()
                .Property(e => e.GroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefUIString_Mt>()
                .Property(e => e.ValueCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefUIString_Mt>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefUIString_Mt>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<C_Schedule>()
                .Property(e => e.Param)
                .IsUnicode(false);

            modelBuilder.Entity<C_Schedule>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<C_ShopItemStockQuantity>()
                .Property(e => e.RefShopGroupCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_ShopItemStockQuantity>()
                .Property(e => e.RefPackageItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_SiegeFortress>()
                .Property(e => e.Introduction)
                .IsUnicode(false);

            modelBuilder.Entity<C_SiegeFortress>()
                .HasMany(e => e.C_SiegeFortressBattleRecord)
                .WithRequired(e => e.C_SiegeFortress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_SiegeFortress>()
                .HasMany(e => e.C_SiegeFortressItemForge)
                .WithRequired(e => e.C_SiegeFortress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_SiegeFortress>()
                .HasMany(e => e.C_SiegeFortressObject)
                .WithRequired(e => e.C_SiegeFortress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_SiegeFortress>()
                .HasMany(e => e.C_SiegeFortressRequest)
                .WithRequired(e => e.C_SiegeFortress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_SiegeFortress>()
                .HasMany(e => e.C_SiegeFortressStoneState)
                .WithRequired(e => e.C_SiegeFortress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_SiegeFortress>()
                .HasMany(e => e.C_SiegeFortressStruct)
                .WithRequired(e => e.C_SiegeFortress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_Skill_BaoHiem_TNET>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_TrainingCamp>()
                .Property(e => e.CommentTitle)
                .IsUnicode(false);

            modelBuilder.Entity<C_TrainingCamp>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<C_TrainingCamp>()
                .HasMany(e => e.C_TrainingCampMember)
                .WithRequired(e => e.C_TrainingCamp)
                .HasForeignKey(e => e.CampID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<C_TrainingCampMember>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_TrijobRanking4WEB>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<C_UnionChat>()
                .Property(e => e.UnionLeader)
                .IsUnicode(false);

            modelBuilder.Entity<C_UnionChat>()
                .Property(e => e.Guild)
                .IsUnicode(false);

            modelBuilder.Entity<C_UnionChat>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_UnionChat>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<C_UnionChat>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<C_Uniques>()
                .Property(e => e.CharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Uniques>()
                .Property(e => e.MonsterCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_UserBalance_Nhat>()
                .Property(e => e.Balance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<C_WebShop_SRO_Log>()
                .Property(e => e.IP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<C_WebShop_SRO_Log>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_WebShop_SRO_Log>()
                .Property(e => e.Balance_Before_Buy)
                .HasPrecision(18, 0);

            modelBuilder.Entity<C_WebShop_SRO_Log>()
                .Property(e => e.Balance_After_Buy)
                .HasPrecision(18, 0);

            modelBuilder.Entity<dtproperties>()
                .Property(e => e.property)
                .IsUnicode(false);

            modelBuilder.Entity<dtproperties>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefHive>()
                .Property(e => e.szDescString128)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefRanking_HunterActivity>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefRanking_HunterContribution>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefRanking_RobberActivity>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefRanking_RobberContribution>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefRanking_TraderActivity>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefRanking_TraderContribution>()
                .Property(e => e.NickName)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefSpawnToolVersion>()
                .Property(e => e.szVersionDescString)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefTactics>()
                .Property(e => e.szDescString128)
                .IsUnicode(false);

            modelBuilder.Entity<C_BlockedWhisperers>()
                .Property(e => e.TargetName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Friend>()
                .Property(e => e.FriendCharName)
                .IsUnicode(false);

            modelBuilder.Entity<C_Magopt>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<C_Magopt>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_Magopt>()
                .Property(e => e.extension)
                .IsUnicode(false);

            modelBuilder.Entity<C_OpenMarket>()
                .Property(e => e.CharName16)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefAccessPermissionOfShop>()
                .Property(e => e.RefShopCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefAccessPermissionOfShop>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefAccessPermissionOfShop>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefAccessPermissionOfShop>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefAccessPermissionOfShop>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefAlchemyMerit>()
                .Property(e => e.OptName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefAlchemyMerit>()
                .Property(e => e.FreeParamDesc1)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefAlchemyMerit>()
                .Property(e => e.FreeParamDesc2)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefAlchemyMerit>()
                .Property(e => e.FreeParamDesc3)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCharDefault_Quest>()
                .Property(e => e.CodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCollectionBook_Item>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCollectionBook_Item>()
                .Property(e => e.ObjName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCollectionBook_Item>()
                .Property(e => e.ThemeCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCollectionBook_Item>()
                .Property(e => e.Story128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCollectionBook_Item>()
                .Property(e => e.DDJFile128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCollectionBook_Theme>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCollectionBook_Theme>()
                .Property(e => e.ObjName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCollectionBook_Theme>()
                .Property(e => e.Name128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefCollectionBook_Theme>()
                .Property(e => e.Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToBuyScrapItem>()
                .Property(e => e.RefItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToBuyScrapItem>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToBuyScrapItem>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToBuyScrapItem>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToBuyScrapItem>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellPackageItem>()
                .Property(e => e.RefPackageItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellPackageItem>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellPackageItem>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellPackageItem>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellPackageItem>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellScrapItem>()
                .Property(e => e.RefItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellScrapItem>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellScrapItem>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellScrapItem>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefConditionToSellScrapItem>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefDropItemGroup>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEvent>()
                .Property(e => e.CodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEvent>()
                .Property(e => e.DescName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEvent>()
                .Property(e => e.ScheduleName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventRewardItems>()
                .Property(e => e.EventCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventRewardItems>()
                .Property(e => e.ItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventRewardItems>()
                .Property(e => e.RentItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventRewardItems>()
                .Property(e => e.Param1_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefEventRewardItems>()
                .Property(e => e.Param2_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefFmnCategoryTree>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefFmnCategoryTree>()
                .Property(e => e.StringID)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefFmnCategoryTree>()
                .Property(e => e.ParentCategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefFmnTidGroup>()
                .Property(e => e.TidGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGachaCode>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGachaItemSet>()
                .Property(e => e.param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGachaItemSet>()
                .Property(e => e.param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGachaItemSet>()
                .Property(e => e.param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGachaItemSet>()
                .Property(e => e.param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGame_World_Config>()
                .Property(e => e.GroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGame_World_Config>()
                .Property(e => e.ValueCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGame_World_Config>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGame_World_Config>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGameWorldNPC>()
                .Property(e => e.WorldCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefGameWorldNPC>()
                .Property(e => e.NPCCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt1)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt2)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt3)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt4)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt5)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt6)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt7)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt8)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt9)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt10)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt11)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt12)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt13)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt14)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt15)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt16)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt17)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt18)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt19)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt20)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt21)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt22)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt23)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt24)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptAssign>()
                .Property(e => e.AvailMOpt25)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptByItemOptLevel>()
                .Property(e => e.TooltipCodename)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptGroup>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptGroup>()
                .Property(e => e.Param1_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMagicOptGroup>()
                .Property(e => e.Param2_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMonster_AssignedItemDrop>()
                .Property(e => e.RentCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefMonster_AssignedItemRndDrop>()
                .Property(e => e.ItemGroupCodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuest>()
                .Property(e => e.CodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuest>()
                .Property(e => e.DescName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuest>()
                .Property(e => e.NameString)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuest>()
                .Property(e => e.PayString)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuest>()
                .Property(e => e.ContentsString)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuest>()
                .Property(e => e.PayContents)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuest>()
                .Property(e => e.NoticeNPC)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuest>()
                .Property(e => e.NoticeCondition)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestRewardItems>()
                .Property(e => e.QuestCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestRewardItems>()
                .Property(e => e.ItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestRewardItems>()
                .Property(e => e.OptionalItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestRewardItems>()
                .Property(e => e.RentItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestRewardItems>()
                .Property(e => e.Param1_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefQuestRewardItems>()
                .Property(e => e.Param2_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRegion_bak>()
                .Property(e => e.ContinentName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRegion_bak>()
                .Property(e => e.AreaName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRegion_bak>()
                .Property(e => e.AssocFile256)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRegionBindAssocServer>()
                .Property(e => e.AreaName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRegionBindAssocServer_bak>()
                .Property(e => e.AreaName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToBuyScrapItem>()
                .Property(e => e.RefItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToBuyScrapItem>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToBuyScrapItem>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToBuyScrapItem>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToBuyScrapItem>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellScrapItem>()
                .Property(e => e.RefItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellScrapItem>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellScrapItem>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellScrapItem>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefRewardPolicyToSellScrapItem>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefScrapOfPackageItem>()
                .Property(e => e.RefPackageItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefScrapOfPackageItem>()
                .Property(e => e.RefItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefScrapOfPackageItem>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefScrapOfPackageItem>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefScrapOfPackageItem>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefScrapOfPackageItem>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSetItemGroup>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSetItemGroup>()
                .Property(e => e.ObjName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSetItemGroup>()
                .Property(e => e.NameStrID128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSetItemGroup>()
                .Property(e => e.DescStrID128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShardContentConfig>()
                .Property(e => e.CodeName128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShardContentConfig>()
                .Property(e => e.CodeDesc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShardContentConfig>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefShardContentConfig>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeStructUpgrade>()
                .Property(e => e.Structname)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeStructUpgrade>()
                .Property(e => e.BaseStructcodename)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeStructUpgrade>()
                .Property(e => e.UpgradeStructname1)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeStructUpgrade>()
                .Property(e => e.UpgradeStructname2)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeStructUpgrade>()
                .Property(e => e.UpgradeStructname3)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefSiegeStructUpgrade>()
                .Property(e => e.UpgradeStructname4)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTreatItemOfShop>()
                .Property(e => e.RefShopCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTreatItemOfShop>()
                .Property(e => e.RefItemCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTreatItemOfShop>()
                .Property(e => e.Param1_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTreatItemOfShop>()
                .Property(e => e.Param2_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTreatItemOfShop>()
                .Property(e => e.Param3_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<C_RefTreatItemOfShop>()
                .Property(e => e.Param4_Desc128)
                .IsUnicode(false);

            modelBuilder.Entity<Tab_RefAISkill>()
                .Property(e => e.SkillCodeName)
                .IsUnicode(false);

            modelBuilder.Entity<TimItemOnChar>()
                .Property(e => e.CharName16)
                .IsUnicode(false);

            modelBuilder.Entity<TimItemOnChar>()
                .Property(e => e.CreaterName)
                .IsUnicode(false);
        }
    }
}
