using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefRegion")]
    public partial class C_RefRegion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short wRegionID { get; set; }

        public byte X { get; set; }

        public byte Z { get; set; }

        [Required]
        [StringLength(128)]
        public string ContinentName { get; set; }

        [Required]
        [StringLength(128)]
        public string AreaName { get; set; }

        public byte IsBattleField { get; set; }

        public int Climate { get; set; }

        public int MaxCapacity { get; set; }

        public int AssocObjID { get; set; }

        public int AssocServer { get; set; }

        [Required]
        [StringLength(256)]
        public string AssocFile256 { get; set; }

        public int? LinkedRegion_1 { get; set; }

        public int? LinkedRegion_2 { get; set; }

        public int? LinkedRegion_3 { get; set; }

        public int? LinkedRegion_4 { get; set; }

        public int? LinkedRegion_5 { get; set; }

        public int? LinkedRegion_6 { get; set; }

        public int? LinkedRegion_7 { get; set; }

        public int? LinkedRegion_8 { get; set; }

        public int? LinkedRegion_9 { get; set; }

        public int? LinkedRegion_10 { get; set; }
    }
}
