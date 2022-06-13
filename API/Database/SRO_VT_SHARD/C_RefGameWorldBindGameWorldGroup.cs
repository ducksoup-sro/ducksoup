using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefGameWorldBindGameWorldGroup")]
    public partial class C_RefGameWorldBindGameWorldGroup
    {
        public int Service { get; set; }

        public int ID { get; set; }

        public int GameWorldID { get; set; }

        public int GameWorldGroupID { get; set; }

        public virtual C_RefGame_World C_RefGame_World { get; set; }

        public virtual C_RefGameWorldGroup C_RefGameWorldGroup { get; set; }
    }
}
