using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGameWorldNPC")]
    public partial class C_RefGameWorldNPC
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(129)]
        public string WorldCodeName128 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string NPCCodeName128 { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short RegionID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PosX { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PosY { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short PosZ { get; set; }

        public int? Param1 { get; set; }

        public int? Param2 { get; set; }

        public int? Param3 { get; set; }

        public int? Param4 { get; set; }

        public int? Param5 { get; set; }

        public int? Param6 { get; set; }

        public int? Param7 { get; set; }

        public int? Param8 { get; set; }

        public int? Param9 { get; set; }

        public int? Param10 { get; set; }
    }
}
