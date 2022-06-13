using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_CharInstanceWorldData")]
    public partial class C_CharInstanceWorldData
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        public int DungeonKeyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorldID { get; set; }

        public int LayerID { get; set; }

        public DateTime OpenedTime { get; set; }

        public short RegionID { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public int PosZ { get; set; }

        public byte IsActivated { get; set; }

        public int EnterCount { get; set; }

        public DateTime LastEnterTime { get; set; }
    }
}
