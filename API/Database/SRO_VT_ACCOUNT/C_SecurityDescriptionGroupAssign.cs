using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("_SecurityDescriptionGroupAssign")]
    public partial class C_SecurityDescriptionGroupAssign
    {
        [Key]
        [Column(Order = 0)]
        public byte nGroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nDescriptionID { get; set; }
    }
}
