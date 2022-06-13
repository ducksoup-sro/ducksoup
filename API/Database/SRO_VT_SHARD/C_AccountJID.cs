using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_AccountJID")]
    public partial class C_AccountJID
    {
        [Key]
        public string AccountID { get; set; }

        public int JID { get; set; }

        public long Gold { get; set; }
    }
}
