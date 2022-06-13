using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_SHARD
{
    public partial class Tab_RefSpawnToolVersion
    {
        [Key]
        public int dwRefDataVersion { get; set; }

        [StringLength(128)]
        public string szVersionDescString { get; set; }
    }
}
