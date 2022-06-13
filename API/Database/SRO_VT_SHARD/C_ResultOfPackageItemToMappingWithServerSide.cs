using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_ResultOfPackageItemToMappingWithServerSide")]
    public partial class C_ResultOfPackageItemToMappingWithServerSide
    {
        public byte Operation { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Slot { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RefItemSerial64 { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RefItemDBID { get; set; }

        public int RefItemID { get; set; }

        public byte Type { get; set; }

        public byte SubType { get; set; }
    }
}
