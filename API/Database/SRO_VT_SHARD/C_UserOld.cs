using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_UserOld")]
    public partial class C_UserOld
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserJID { get; set; }

        public int CharID1 { get; set; }

        public int CharID2 { get; set; }

        public int CharID3 { get; set; }

        public long Gold { get; set; }
    }
}
