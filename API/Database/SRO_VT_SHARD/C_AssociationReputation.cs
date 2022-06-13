using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_AssociationReputation")]
    public partial class C_AssociationReputation
    {
        [Key]
        [Column(Order = 0)]
        public string AssociationCodeName { get; set; }

        [Key]
        [Column(Order = 1)]
        public string AssociationTypeName { get; set; }

        public int Reputation { get; set; }

        public int PriorOccupation { get; set; }
    }
}
