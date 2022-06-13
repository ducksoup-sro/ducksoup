using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSiegeFortressItemForge")]
    public partial class C_RefSiegeFortressItemForge
    {
        public byte Service { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FortressID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefItemID { get; set; }

        public int ReqGold { get; set; }

        public int ReqGP { get; set; }

        public int ForgeTimeMin { get; set; }
    }
}
