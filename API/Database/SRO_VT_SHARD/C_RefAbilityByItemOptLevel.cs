using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefAbilityByItemOptLevel")]
    public partial class C_RefAbilityByItemOptLevel
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RefItemID { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte ItemOptLevel { get; set; }

        public virtual C_RefObjCommon C_RefObjCommon { get; set; }
    }
}
