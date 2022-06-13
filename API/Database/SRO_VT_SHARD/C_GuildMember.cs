using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_GuildMember")]
    public partial class C_GuildMember
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GuildID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CharID { get; set; }

        [Required]
        [StringLength(64)]
        public string CharName { get; set; }

        public byte MemberClass { get; set; }

        public byte CharLevel { get; set; }

        public int GP_Donation { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime JoinDate { get; set; }

        public int? Permission { get; set; }

        public int? Contribution { get; set; }

        public int? GuildWarKill { get; set; }

        public int? GuildWarKilled { get; set; }

        [StringLength(64)]
        public string Nickname { get; set; }

        public int? RefObjID { get; set; }

        public byte? SiegeAuthority { get; set; }

        public virtual C_Char C_Char { get; set; }

        public virtual C_Guild C_Guild { get; set; }
    }
}
