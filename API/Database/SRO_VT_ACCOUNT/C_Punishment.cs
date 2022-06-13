using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_Punishment")]
    public partial class C_Punishment
    {
        [Key]
        public int SerialNo { get; set; }

        public int UserJID { get; set; }

        public byte Type { get; set; }

        [Required]
        [StringLength(128)]
        public string Executor { get; set; }

        public short Shard { get; set; }

        [StringLength(64)]
        public string CharName { get; set; }

        [Required]
        [StringLength(256)]
        public string CharInfo { get; set; }

        [Required]
        [StringLength(64)]
        public string PosInfo { get; set; }

        [Required]
        [StringLength(512)]
        public string Guide { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        public DateTime RaiseTime { get; set; }

        public DateTime BlockStartTime { get; set; }

        public DateTime BlockEndTime { get; set; }

        public DateTime PunishTime { get; set; }

        public byte Status { get; set; }
    }
}
