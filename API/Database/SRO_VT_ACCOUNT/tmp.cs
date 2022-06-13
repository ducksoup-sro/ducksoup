using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    [Table("tmp")]
    public partial class tmp
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserJID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserID { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte Type { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SerialNo { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime timeBegin { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime timeEnd { get; set; }
    }
}
