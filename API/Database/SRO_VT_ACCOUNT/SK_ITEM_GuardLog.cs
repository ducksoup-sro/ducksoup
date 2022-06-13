using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class SK_ITEM_GuardLog
    {
        [Key]
        public int autoID { get; set; }

        public long? serial64 { get; set; }

        public int? gremain { get; set; }

        public int? shardID { get; set; }

        public int? optionLvl { get; set; }

        public DateTime? LastGuard { get; set; }
    }
}
