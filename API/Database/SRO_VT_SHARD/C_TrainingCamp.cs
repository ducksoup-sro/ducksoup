using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_TrainingCamp")]
    public partial class C_TrainingCamp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_TrainingCamp()
        {
            C_TrainingCampMember = new HashSet<C_TrainingCampMember>();
        }

        public int ID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreationDate { get; set; }

        public byte Rank { get; set; }

        public int GraduateCount { get; set; }

        public int EvaluationPoint { get; set; }

        public DateTime LatestEvaluationDate { get; set; }

        [StringLength(129)]
        public string CommentTitle { get; set; }

        [StringLength(2048)]
        public string Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_TrainingCampMember> C_TrainingCampMember { get; set; }
    }
}
