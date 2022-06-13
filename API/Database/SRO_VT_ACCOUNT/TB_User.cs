using System.ComponentModel.DataAnnotations;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class TB_User
    {
        [Key]
        public int JID { get; set; }

        [Required]
        [StringLength(25)]
        public string StrUserID { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public byte? Status { get; set; }

        public byte? GMrank { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

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

        public DateTime? regtime { get; set; }

        [StringLength(25)]
        public string reg_ip { get; set; }

        public DateTime? Time_log { get; set; }

        public int? freetime { get; set; }

        public byte sec_primary { get; set; }

        public byte sec_content { get; set; }

        public int AccPlayTime { get; set; }

        public int LatestUpdateTime_ToPlayTime { get; set; }

        public int Play123Time { get; set; }
    }
}
