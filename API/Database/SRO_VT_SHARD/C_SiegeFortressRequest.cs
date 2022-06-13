using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_SiegeFortressRequest")]
    public partial class C_SiegeFortressRequest
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FortressID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GuildID { get; set; }

        public byte RequestType { get; set; }

        public virtual C_Guild C_Guild { get; set; }

        public virtual C_SiegeFortress C_SiegeFortress { get; set; }
    }
}
