using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefHWANLevel")]
    public partial class C_RefHWANLevel
    {
        [Key]
        public byte HwanLevel { get; set; }

        public int? ParamFourcc1 { get; set; }

        public byte? ParamValue1 { get; set; }

        public int? ParamFourcc2 { get; set; }

        public byte? ParamValue2 { get; set; }

        public int? ParamFourcc3 { get; set; }

        public byte? ParamValue3 { get; set; }

        public int? ParamFourcc4 { get; set; }

        public byte? ParamValue4 { get; set; }

        public int? ParamFourcc5 { get; set; }

        public byte? ParamValue5 { get; set; }

        [StringLength(129)]
        public string AssocFileObj128 { get; set; }

        [StringLength(70)]
        public string Title_CH70 { get; set; }

        [StringLength(70)]
        public string Title_EU70 { get; set; }
    }
}
