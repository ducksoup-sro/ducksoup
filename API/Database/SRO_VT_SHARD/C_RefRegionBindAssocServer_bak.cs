using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefRegionBindAssocServer_bak")]
    public partial class C_RefRegionBindAssocServer_bak
    {
        [Key]
        [Column(Order = 0)]
        public string AreaName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssocServer { get; set; }
    }
}
