using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_TrainingCampSubMentorHonorPoint")]
    public partial class C_TrainingCampSubMentorHonorPoint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        public int HonorPoint { get; set; }

        public virtual C_Char C_Char { get; set; }
    }
}
