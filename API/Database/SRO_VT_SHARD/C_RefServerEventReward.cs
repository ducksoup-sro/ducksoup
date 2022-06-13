using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefServerEventReward")]
    public partial class C_RefServerEventReward
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefServerEventReward()
        {
            C_RefServerEventReward_ExpUPForPlayers = new HashSet<C_RefServerEventReward_ExpUPForPlayers>();
            C_RefServerEventReward_SpawnMonster = new HashSet<C_RefServerEventReward_SpawnMonster>();
        }

        public byte Service { get; set; }

        [Key]
        public int RewardID { get; set; }

        public int OwnerServerEventID { get; set; }

        public int RefRewardID { get; set; }

        public byte Quantity { get; set; }

        public byte RewardClass { get; set; }

        public byte MasterReward { get; set; }

        public virtual C_RefServerEvent C_RefServerEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefServerEventReward_ExpUPForPlayers> C_RefServerEventReward_ExpUPForPlayers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefServerEventReward_SpawnMonster> C_RefServerEventReward_SpawnMonster { get; set; }
    }
}
