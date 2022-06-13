using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_BlockedUser")]
    public partial class C_BlockedUser
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserJID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Type { get; set; }

        public int SerialNo { get; set; }

        public DateTime timeBegin { get; set; }

        public DateTime timeEnd { get; set; }
    }
}
