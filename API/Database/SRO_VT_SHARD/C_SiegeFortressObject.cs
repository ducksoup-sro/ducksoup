using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_SiegeFortressObject")]
    public partial class C_SiegeFortressObject
    {
        public int ID { get; set; }

        public int FortressID { get; set; }

        public int OwnerGuildID { get; set; }

        public int RefObjID { get; set; }

        public int HP { get; set; }

        public short Region { get; set; }

        public float PosX { get; set; }

        public float PosY { get; set; }

        public float PosZ { get; set; }

        public float Direction { get; set; }

        public byte OwnerLevel { get; set; }

        public virtual C_SiegeFortress C_SiegeFortress { get; set; }
    }
}
