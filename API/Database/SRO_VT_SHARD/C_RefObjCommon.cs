using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefObjCommon")]
    public partial class C_RefObjCommon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefObjCommon()
        {
            C_RefAbilityByItemOptLevel = new HashSet<C_RefAbilityByItemOptLevel>();
            C_RefCustomizingReservedItemDropForMonster = new HashSet<C_RefCustomizingReservedItemDropForMonster>();
            C_RefDropItemGroup = new HashSet<C_RefDropItemGroup>();
            C_RefMonster_AssignedItemDrop = new HashSet<C_RefMonster_AssignedItemDrop>();
            C_RefMonster_AssignedItemDrop1 = new HashSet<C_RefMonster_AssignedItemDrop>();
            C_RefMonster_AssignedItemRndDrop = new HashSet<C_RefMonster_AssignedItemRndDrop>();
        }

        public int Service { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string ObjName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string OrgObjCodeName128 { get; set; }

        [Required]
        [StringLength(129)]
        public string NameStrID128 { get; set; }

        [Required]
        [StringLength(129)]
        public string DescStrID128 { get; set; }

        public byte CashItem { get; set; }

        public byte Bionic { get; set; }

        public byte TypeID1 { get; set; }

        public byte TypeID2 { get; set; }

        public byte TypeID3 { get; set; }

        public byte TypeID4 { get; set; }

        public int DecayTime { get; set; }

        public byte Country { get; set; }

        public byte Rarity { get; set; }

        public byte CanTrade { get; set; }

        public byte CanSell { get; set; }

        public byte CanBuy { get; set; }

        public byte CanBorrow { get; set; }

        public byte CanDrop { get; set; }

        public byte CanPick { get; set; }

        public byte CanRepair { get; set; }

        public byte CanRevive { get; set; }

        public byte CanUse { get; set; }

        public byte CanThrow { get; set; }

        public int Price { get; set; }

        public int CostRepair { get; set; }

        public int CostRevive { get; set; }

        public int CostBorrow { get; set; }

        public int KeepingFee { get; set; }

        public int SellPrice { get; set; }

        public int ReqLevelType1 { get; set; }

        public byte ReqLevel1 { get; set; }

        public int ReqLevelType2 { get; set; }

        public byte ReqLevel2 { get; set; }

        public int ReqLevelType3 { get; set; }

        public byte ReqLevel3 { get; set; }

        public int ReqLevelType4 { get; set; }

        public byte ReqLevel4 { get; set; }

        public int MaxContain { get; set; }

        public short RegionID { get; set; }

        public short Dir { get; set; }

        public short OffsetX { get; set; }

        public short OffsetY { get; set; }

        public short OffsetZ { get; set; }

        public short Speed1 { get; set; }

        public short Speed2 { get; set; }

        public int Scale { get; set; }

        public short BCHeight { get; set; }

        public short BCRadius { get; set; }

        public int EventID { get; set; }

        [Required]
        [StringLength(129)]
        public string AssocFileObj128 { get; set; }

        [Required]
        [StringLength(129)]
        public string AssocFileDrop128 { get; set; }

        [Required]
        [StringLength(129)]
        public string AssocFileIcon128 { get; set; }

        [Required]
        [StringLength(129)]
        public string AssocFile1_128 { get; set; }

        [Required]
        [StringLength(129)]
        public string AssocFile2_128 { get; set; }

        public int Link { get; set; }

        private C_RefObjItem? _refObjItem;

        public C_RefObjItem GetRefObjItem()
        {
            return _refObjItem ??= ServiceFactory.ServiceFactory
                .Load<ISharedObjects>(typeof(ISharedObjects)).RefObjItem
                .FirstOrDefault(c => c.Value.ID == Link).Value;
        }
        
        private C_RefObjChar? _refObjChar;

        public C_RefObjChar GetRefObjChar()
        {
            return _refObjChar ??= ServiceFactory.ServiceFactory
                .Load<ISharedObjects>(typeof(ISharedObjects)).RefObjChar
                .FirstOrDefault(c => c.Value.ID == Link).Value;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefAbilityByItemOptLevel> C_RefAbilityByItemOptLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefCustomizingReservedItemDropForMonster> C_RefCustomizingReservedItemDropForMonster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefDropItemGroup> C_RefDropItemGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefMonster_AssignedItemDrop> C_RefMonster_AssignedItemDrop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefMonster_AssignedItemDrop> C_RefMonster_AssignedItemDrop1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefMonster_AssignedItemRndDrop> C_RefMonster_AssignedItemRndDrop { get; set; }
    }
}
