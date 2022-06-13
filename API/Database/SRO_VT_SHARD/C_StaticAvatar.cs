using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_StaticAvatar")]
    public partial class C_StaticAvatar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        public int? Param1 { get; set; }

        public int? Param2 { get; set; }

        public int? Param3 { get; set; }

        public int? Param4 { get; set; }

        public int? Param5 { get; set; }

        public int? Param6 { get; set; }

        public int? Param7 { get; set; }

        public int? Param8 { get; set; }

        public int? Param9 { get; set; }

        public int? Param10 { get; set; }

        public int? Param11 { get; set; }

        public int? Param12 { get; set; }

        public int? Param13 { get; set; }

        public int? Param14 { get; set; }

        public int? Param15 { get; set; }

        public int? Param16 { get; set; }

        public virtual C_Char C_Char { get; set; }
    }
}
