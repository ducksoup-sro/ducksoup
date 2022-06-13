using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class TB_Net2e_Bak
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string StrUserID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string SecondPassword { get; set; }

        [StringLength(70)]
        public string question { get; set; }

        [StringLength(50)]
        public string answer { get; set; }

        public byte? Status { get; set; }

        public byte? GMrank { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string MDK { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(2)]
        public string sex { get; set; }

        [StringLength(30)]
        public string certificate_num { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(10)]
        public string postcode { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(20)]
        public string mobile { get; set; }

        [StringLength(70)]
        public string cid { get; set; }

        public int? cidType { get; set; }

        public DateTime? regtime { get; set; }

        [StringLength(25)]
        public string reg_ip { get; set; }

        public DateTime? Time_log { get; set; }

        public int? freetime { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte sec_primary { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte sec_content { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(50)]
        public string WherePlay { get; set; }

        [StringLength(50)]
        public string WhereKnow { get; set; }

        [StringLength(50)]
        public string Reference { get; set; }

        [StringLength(50)]
        public string Games { get; set; }

        [StringLength(10)]
        public string strLevel { get; set; }

        [StringLength(50)]
        public string Class { get; set; }

        public byte? HowPlay { get; set; }

        [StringLength(25)]
        public string Inviter { get; set; }

        [StringLength(50)]
        public string Sec_act { get; set; }

        public DateTime? LastModification { get; set; }
    }
}
