using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefMonster_AssignedItemDrop")]
    public partial class C_RefMonster_AssignedItemDrop
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefMonsterID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefItemID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte DropGroupType { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte OptLevel { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte DropAmountMin { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte DropAmountMax { get; set; }

        [Key]
        [Column(Order = 6)]
        public float DropRatio { get; set; }

        public short? RefMagicOptionID1 { get; set; }

        public int? CustomValue1 { get; set; }

        public short? RefMagicOptionID2 { get; set; }

        public int? CustomValue2 { get; set; }

        public short? RefMagicOptionID3 { get; set; }

        public int? CustomValue3 { get; set; }

        public short? RefMagicOptionID4 { get; set; }

        public int? CustomValue4 { get; set; }

        public short? RefMagicOptionID5 { get; set; }

        public int? CustomValue5 { get; set; }

        public short? RefMagicOptionID6 { get; set; }

        public int? CustomValue6 { get; set; }

        public short? RefMagicOptionID7 { get; set; }

        public int? CustomValue7 { get; set; }

        public short? RefMagicOptionID8 { get; set; }

        public int? CustomValue8 { get; set; }

        public short? RefMagicOptionID9 { get; set; }

        public int? CustomValue9 { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(129)]
        public string RentCodeName { get; set; }

        public virtual C_RefObjCommon C_RefObjCommon { get; set; }

        public virtual C_RefObjCommon C_RefObjCommon1 { get; set; }
    }
}
