using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefTriggerBindEvent")]
    public partial class C_RefTriggerBindEvent
    {
        public int Service { get; set; }

        public int ID { get; set; }

        public int TriggerID { get; set; }

        public int TriggerEventID { get; set; }

        public virtual C_RefTrigger C_RefTrigger { get; set; }

        public virtual C_RefTriggerEvent C_RefTriggerEvent { get; set; }
    }
}
