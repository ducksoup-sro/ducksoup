using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_GPHistory")]
    public partial class C_GPHistory
    {
        public int ID { get; set; }

        public int GuildID { get; set; }

        public DateTime? UsedTime { get; set; }

        [Required]
        [StringLength(64)]
        public string CharName { get; set; }

        public int UsedGP { get; set; }

        public byte Reason { get; set; }
    }
}
