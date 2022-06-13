using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_PrivateChat")]
    public partial class C_PrivateChat
    {
        public long ID { get; set; }

        [StringLength(255)]
        public string Sender { get; set; }

        [StringLength(255)]
        public string Receiver { get; set; }

        [StringLength(255)]
        public string Message { get; set; }

        public DateTime? Time { get; set; }

        public string IP { get; set; }
    }
}
