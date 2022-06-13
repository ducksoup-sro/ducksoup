using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGachaNpcMap")]
    public partial class C_RefGachaNpcMap
    {
        public byte Service { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NPC_ID { get; set; }

        public int SelectionGachaID { get; set; }

        public int WasteGachaID { get; set; }
    }
}
