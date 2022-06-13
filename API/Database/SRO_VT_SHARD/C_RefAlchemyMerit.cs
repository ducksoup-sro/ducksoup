using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefAlchemyMerit")]
    public partial class C_RefAlchemyMerit
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Group { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(129)]
        public string OptName128 { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte Level { get; set; }

        [Key]
        [Column(Order = 4)]
        public float Weapon { get; set; }

        [Key]
        [Column(Order = 5)]
        public float Armor { get; set; }

        [Key]
        [Column(Order = 6)]
        public float Accessory { get; set; }

        [Key]
        [Column(Order = 7)]
        public float Shield { get; set; }

        public long? FreeParam1 { get; set; }

        [StringLength(129)]
        public string FreeParamDesc1 { get; set; }

        public long? FreeParam2 { get; set; }

        [StringLength(129)]
        public string FreeParamDesc2 { get; set; }

        public long? FreeParam3 { get; set; }

        [StringLength(129)]
        public string FreeParamDesc3 { get; set; }
    }
}
