using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefMonster_AssignedItemRndDrop")]
    public partial class C_RefMonster_AssignedItemRndDrop
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefMonsterID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefItemGroupID { get; set; }

        [Key]
        [Column(Order = 3)]
        public string ItemGroupCodeName128 { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte Overlap { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte DropAmountMin { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte DropAmountMax { get; set; }

        [Key]
        [Column(Order = 7)]
        public float DropRatio { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int param1 { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int param2 { get; set; }

        public virtual C_RefObjCommon C_RefObjCommon { get; set; }
    }
}
