using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefFmnTidGroupMap")]
    public partial class C_RefFmnTidGroupMap
    {
        [Key]
        [Column(Order = 0)]
        public byte Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TidGroupID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte TypeID1 { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte TypeID2 { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte TypeID3 { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte TypeID4 { get; set; }
    }
}
