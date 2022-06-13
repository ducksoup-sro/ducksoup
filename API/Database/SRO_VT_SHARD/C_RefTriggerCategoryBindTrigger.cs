using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerCategoryBindTrigger")]
    public partial class C_RefTriggerCategoryBindTrigger
    {
        public int Service { get; set; }

        public int ID { get; set; }

        public int TriggerCategoryID { get; set; }

        public int TriggerID { get; set; }

        public virtual C_RefTrigger C_RefTrigger { get; set; }
    }
}
