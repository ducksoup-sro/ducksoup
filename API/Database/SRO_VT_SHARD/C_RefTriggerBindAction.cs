using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerBindAction")]
    public partial class C_RefTriggerBindAction
    {
        public int Service { get; set; }

        public int ID { get; set; }

        public int TriggerID { get; set; }

        public int TriggerActionID { get; set; }

        public virtual C_RefTrigger C_RefTrigger { get; set; }

        public virtual C_RefTriggerAction C_RefTriggerAction { get; set; }
    }
}
