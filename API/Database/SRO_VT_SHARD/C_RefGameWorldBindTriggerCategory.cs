using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGameWorldBindTriggerCategory")]
    public partial class C_RefGameWorldBindTriggerCategory
    {
        public int Service { get; set; }

        public int ID { get; set; }

        public int GameWorldID { get; set; }

        public int TriggerCategoryID { get; set; }

        public virtual C_RefGame_World C_RefGame_World { get; set; }

        public virtual C_RefTriggerCategory C_RefTriggerCategory { get; set; }
    }
}
