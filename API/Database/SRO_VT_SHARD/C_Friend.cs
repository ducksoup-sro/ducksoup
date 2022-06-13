using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_Friend")]
    public partial class C_Friend
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FriendCharID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(64)]
        public string FriendCharName { get; set; }

        public int? RefObjID { get; set; }

        public virtual C_Char C_Char { get; set; }

        public virtual C_Char C_Char1 { get; set; }
    }
}
