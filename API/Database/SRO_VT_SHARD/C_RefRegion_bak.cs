using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefRegion_bak")]
    public partial class C_RefRegion_bak
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short wRegionID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte X { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte Z { get; set; }

        [Key]
        [Column(Order = 3)]
        public string ContinentName { get; set; }

        [Key]
        [Column(Order = 4)]
        public string AreaName { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte IsBattleField { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Climate { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaxCapacity { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssocObjID { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssocServer { get; set; }

        [Key]
        [Column(Order = 10)]
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
