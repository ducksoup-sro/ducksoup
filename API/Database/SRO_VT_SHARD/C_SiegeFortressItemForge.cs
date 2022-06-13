using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_SiegeFortressItemForge")]
    public partial class C_SiegeFortressItemForge
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FortressID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemRefID { get; set; }

        public short Amount { get; set; }

        public byte Finished { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public virtual C_SiegeFortress C_SiegeFortress { get; set; }
    }
}
