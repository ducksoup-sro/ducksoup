using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_Char")]
    public partial class C_Char
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Char()
        {
            C_BlockedWhisperers = new HashSet<C_BlockedWhisperers>();
            C_CharCOS = new HashSet<C_CharCOS>();
            C_CharSkill = new HashSet<C_CharSkill>();
            C_CharSkillMastery = new HashSet<C_CharSkillMastery>();
            C_FleaMarketNetwork = new HashSet<C_FleaMarketNetwork>();
            C_Friend = new HashSet<C_Friend>();
            C_Friend1 = new HashSet<C_Friend>();
            C_GuildMember = new HashSet<C_GuildMember>();
            C_Inventory = new HashSet<C_Inventory>();
            C_InventoryForAvatar = new HashSet<C_InventoryForAvatar>();
            C_Memo = new HashSet<C_Memo>();
            C_TimedJob = new HashSet<C_TimedJob>();
            C_TrainingCampMember = new HashSet<C_TrainingCampMember>();
            C_User = new HashSet<C_User>();
        }

        [Key]
        public int CharID { get; set; }

        public byte Deleted { get; set; }

        public int RefObjID { get; set; }

        [Required]
        [StringLength(64)]
        public string CharName16 { get; set; }

        [Required]
        [StringLength(17)]
        public string NickName16 { get; set; }

        public byte Scale { get; set; }

        public byte CurLevel { get; set; }

        public byte MaxLevel { get; set; }

        public long ExpOffset { get; set; }

        public int SExpOffset { get; set; }

        public short Strength { get; set; }

        public short Intellect { get; set; }

        public long RemainGold { get; set; }

        public int RemainSkillPoint { get; set; }

        public short RemainStatPoint { get; set; }

        public byte RemainHwanCount { get; set; }

        public int GatheredExpPoint { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public short LatestRegion { get; set; }

        public float PosX { get; set; }

        public float PosY { get; set; }

        public float PosZ { get; set; }

        public int AppointedTeleport { get; set; }

        public byte AutoInvestExp { get; set; }

        public int InventorySize { get; set; }

        public byte DailyPK { get; set; }

        public short TotalPK { get; set; }

        public int PKPenaltyPoint { get; set; }

        public int TPP { get; set; }

        public int PenaltyForfeit { get; set; }

        public int JobPenaltyTime { get; set; }

        public byte JobLvl_Trader { get; set; }

        public int Trader_Exp { get; set; }

        public byte JobLvl_Hunter { get; set; }

        public int Hunter_Exp { get; set; }

        public byte JobLvl_Robber { get; set; }

        public int Robber_Exp { get; set; }

        public int? GuildID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastLogout { get; set; }

        public short TelRegion { get; set; }

        public float TelPosX { get; set; }

        public float TelPosY { get; set; }

        public float TelPosZ { get; set; }

        public short DiedRegion { get; set; }

        public float DiedPosX { get; set; }

        public float DiedPosY { get; set; }

        public float DiedPosZ { get; set; }

        public short WorldID { get; set; }

        public short TelWorldID { get; set; }

        public short DiedWorldID { get; set; }

        public byte HwanLevel { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_BlockedWhisperers> C_BlockedWhisperers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_CharCOS> C_CharCOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_CharSkill> C_CharSkill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_CharSkillMastery> C_CharSkillMastery { get; set; }

        public virtual C_CharTrijob C_CharTrijob { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_FleaMarketNetwork> C_FleaMarketNetwork { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Friend> C_Friend { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Friend> C_Friend1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_GuildMember> C_GuildMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Inventory> C_Inventory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_InventoryForAvatar> C_InventoryForAvatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Memo> C_Memo { get; set; }

        public virtual C_StaticAvatar C_StaticAvatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_TimedJob> C_TimedJob { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_TrainingCampMember> C_TrainingCampMember { get; set; }

        public virtual C_TrainingCampSubMentorHonorPoint C_TrainingCampSubMentorHonorPoint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_User> C_User { get; set; }
    }
}
