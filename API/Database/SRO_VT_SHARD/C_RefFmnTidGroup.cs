using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefFmnTidGroup")]
    public partial class C_RefFmnTidGroup
    {
        [Key]
        [Column(Order = 0)]
        public int TidGroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string TidGroupName { get; set; }
    }
}
