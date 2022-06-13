using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_TrainingCampHonorRank")]
    public partial class C_TrainingCampHonorRank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ranking { get; set; }

        public int? CampID { get; set; }

        public byte? Rank { get; set; }
    }
}
