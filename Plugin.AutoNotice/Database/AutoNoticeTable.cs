using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618

namespace Plugin.AutoNotice.Database;

[Table("AutoNotice")]
public class AutoNoticeTable
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NoticeId { get; set; }

    [Required] [StringLength(32)] public string Receiver { get; set; }
    
    [Required] public string Notice { get; set; }
    
    public DateTime? SendAfter { get; set; }
}