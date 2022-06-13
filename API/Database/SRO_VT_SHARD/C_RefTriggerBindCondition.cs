using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerBindCondition")]
    public partial class C_RefTriggerBindCondition
    {
        public int Service { get; set; }

        public int ID { get; set; }

        public int TriggerID { get; set; }

        public int TriggerConditionID { get; set; }

        public virtual C_RefTrigger C_RefTrigger { get; set; }

        public virtual C_RefTriggerCondition C_RefTriggerCondition { get; set; }
    }
}
