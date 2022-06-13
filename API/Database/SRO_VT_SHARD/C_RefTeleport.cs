using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTeleport")]
    public partial class C_RefTeleport
    {
        public int Service { get; set; }

        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [StringLength(129)]
        public string AssocRefObjCodeName128 { get; set; }

        public int AssocRefObjID { get; set; }

        [Required]
        [StringLength(129)]
        public string ZoneName128 { get; set; }

        public short GenRegionID { get; set; }

        public short GenPos_X { get; set; }

        public short GenPos_Y { get; set; }

        public short GenPos_Z { get; set; }

        public short GenAreaRadius { get; set; }

        public byte CanBeResurrectPos { get; set; }

        public byte CanGotoResurrectPos { get; set; }

        public short GenWorldID { get; set; }

        public byte BindInteractionMask { get; set; }

        public byte FixedService { get; set; }
    }
}
