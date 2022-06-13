using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_DeletedChar")]
    public partial class C_DeletedChar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        public int UserJID { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}
