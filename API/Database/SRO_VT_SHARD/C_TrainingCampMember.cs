using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_TrainingCampMember")]
    public partial class C_TrainingCampMember
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CampID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        public int RefObjID { get; set; }

        [Required]
        [StringLength(64)]
        public string CharName { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime JoinDate { get; set; }

        public byte MemberClass { get; set; }

        public byte CharJoinedLevel { get; set; }

        public byte CharCurLevel { get; set; }

        public byte CharMaxLevel { get; set; }

        public int HonorPoint { get; set; }

        public virtual C_Char C_Char { get; set; }

        public virtual C_TrainingCamp C_TrainingCamp { get; set; }
    }
}
