using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class SR_CharNames
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserJID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short ShardID { get; set; }

        [Required]
        [StringLength(17)]
        public string CharID_1 { get; set; }

        [StringLength(17)]
        public string CharID_2 { get; set; }

        [StringLength(17)]
        public string CharID_3 { get; set; }
    }
}
