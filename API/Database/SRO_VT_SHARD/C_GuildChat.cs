using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_GuildChat")]
    public partial class C_GuildChat
    {
        public long ID { get; set; }

        [StringLength(255)]
        public string Guild { get; set; }

        [StringLength(255)]
        public string CharName { get; set; }

        [StringLength(255)]
        public string Message { get; set; }

        public DateTime? Time { get; set; }

        public string IP { get; set; }
    }
}
