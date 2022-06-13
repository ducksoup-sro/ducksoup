using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("BOOKS")]
    public partial class BOOK
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string title { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime pubdate { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4000)]
        public string synopsis { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool inprint { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int salesCount { get; set; }
    }
}
