using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefMagicOptAssign")]
    public partial class C_RefMagicOptAssign
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Service { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte Race { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte TID3 { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte TID4 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(129)]
        public string AvailMOpt1 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(129)]
        public string AvailMOpt2 { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(129)]
        public string AvailMOpt3 { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(129)]
        public string AvailMOpt4 { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(129)]
        public string AvailMOpt5 { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(129)]
        public string AvailMOpt6 { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(129)]
        public string AvailMOpt7 { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(129)]
        public string AvailMOpt8 { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(129)]
        public string AvailMOpt9 { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(129)]
        public string AvailMOpt10 { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(129)]
        public string AvailMOpt11 { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(129)]
        public string AvailMOpt12 { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(129)]
        public string AvailMOpt13 { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(129)]
        public string AvailMOpt14 { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(129)]
        public string AvailMOpt15 { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(129)]
        public string AvailMOpt16 { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(129)]
        public string AvailMOpt17 { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(129)]
        public string AvailMOpt18 { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(129)]
        public string AvailMOpt19 { get; set; }

        [Key]
        [Column(Order = 23)]
        [StringLength(129)]
        public string AvailMOpt20 { get; set; }

        [Key]
        [Column(Order = 24)]
        [StringLength(129)]
        public string AvailMOpt21 { get; set; }

        [Key]
        [Column(Order = 25)]
        [StringLength(129)]
        public string AvailMOpt22 { get; set; }

        [Key]
        [Column(Order = 26)]
        [StringLength(129)]
        public string AvailMOpt23 { get; set; }

        [Key]
        [Column(Order = 27)]
        [StringLength(129)]
        public string AvailMOpt24 { get; set; }

        [Key]
        [Column(Order = 28)]
        [StringLength(129)]
        public string AvailMOpt25 { get; set; }
    }
}
