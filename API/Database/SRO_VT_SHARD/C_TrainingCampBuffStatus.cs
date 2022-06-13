using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_TrainingCampBuffStatus")]
    public partial class C_TrainingCampBuffStatus
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CampID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RecipientCharID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte BuffSlotIdx { get; set; }

        public int DonorCharID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime StartingTime { get; set; }

        public int RemainBuffPoint { get; set; }

        public byte BuffType { get; set; }
    }
}
