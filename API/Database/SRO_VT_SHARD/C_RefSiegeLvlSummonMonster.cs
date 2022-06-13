using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSiegeLvlSummonMonster")]
    public partial class C_RefSiegeLvlSummonMonster
    {
        public byte Service { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefObjID { get; set; }

        public int RefOrgObjID { get; set; }
    }
}
