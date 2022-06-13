using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_UserBalance_Nhat")]
    public partial class C_UserBalance_Nhat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Balance { get; set; }
    }
}
