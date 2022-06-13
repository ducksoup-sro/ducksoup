using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_BlockedWhisperers")]
    public partial class C_BlockedWhisperers
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OwnerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string TargetName { get; set; }

        public virtual C_Char C_Char { get; set; }
    }
}
