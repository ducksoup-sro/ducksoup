using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefCustomizingReservedItemDropForMonster")]
    public partial class C_RefCustomizingReservedItemDropForMonster
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefMonsterID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Rarity { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Command { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte DropGroupType { get; set; }

        public int? Param1 { get; set; }

        public int? Param2 { get; set; }

        public int? Param3 { get; set; }

        public int? Param4 { get; set; }

        public int? Param5 { get; set; }

        public virtual C_RefObjCommon C_RefObjCommon { get; set; }
    }
}
