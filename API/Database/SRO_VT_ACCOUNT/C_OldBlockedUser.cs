using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_OldBlockedUser")]
    public partial class C_OldBlockedUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserJID { get; set; }

        public byte Type { get; set; }

        public int SerialNo { get; set; }

        public DateTime timeBegin { get; set; }

        public DateTime timeEnd { get; set; }
    }
}
