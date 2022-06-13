using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("__SiegeFortressStatus__")]
    public partial class C__SiegeFortressStatus__
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShardID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(129)]
        public string FortressName { get; set; }

        public byte FortressScale { get; set; }

        public short TaxRatio { get; set; }

        [StringLength(129)]
        public string OwnerGuildName { get; set; }

        [StringLength(129)]
        public string OwnerGuildMaster { get; set; }

        [StringLength(129)]
        public string OwnerAllianceGuildName1 { get; set; }

        [StringLength(129)]
        public string OwnerAllianceGuildName2 { get; set; }

        [StringLength(129)]
        public string OwnerAllianceGuildName3 { get; set; }

        [StringLength(129)]
        public string OwnerAllianceGuildName4 { get; set; }

        [StringLength(129)]
        public string OwnerAllianceGuildName5 { get; set; }

        [StringLength(129)]
        public string OwnerAllianceGuildName6 { get; set; }

        [StringLength(129)]
        public string OwnerAllianceGuildName7 { get; set; }

        [StringLength(129)]
        public string OwnerAllianceGuildName8 { get; set; }

        public DateTime? OwnerUpdateDate { get; set; }
    }
}
