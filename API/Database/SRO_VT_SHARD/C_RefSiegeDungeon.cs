using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSiegeDungeon")]
    public partial class C_RefSiegeDungeon
    {
        public byte Service { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FortressID { get; set; }

        public int WorldID { get; set; }

        public byte MaxCreateCount { get; set; }

        public long EntryGold { get; set; }

        public int EntryGP { get; set; }
    }
}
