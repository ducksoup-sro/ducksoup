using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTeleLink")]
    public partial class C_RefTeleLink
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Service { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OwnerTeleport { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TargetTeleport { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Fee { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte RestrictBindMethod { get; set; }

        [Key]
        [Column(Order = 5)]
        public byte RunTimeTeleportMethod { get; set; }

        [Key]
        [Column(Order = 6)]
        public byte CheckResult { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Restrict1 { get; set; }

        public int? Data1_1 { get; set; }

        public int? Data1_2 { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Restrict2 { get; set; }

        public int? Data2_1 { get; set; }

        public int? Data2_2 { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Restrict3 { get; set; }

        public int? Data3_1 { get; set; }

        public int? Data3_2 { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Restrict4 { get; set; }

        public int? Data4_1 { get; set; }

        public int? Data4_2 { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Restrict5 { get; set; }

        public int? Data5_1 { get; set; }

        public int? Data5_2 { get; set; }
    }
}
