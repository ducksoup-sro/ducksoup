using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.DuckSoup;

[Table("Blacklist")]
public class Blacklist
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BlacklistId { get; set; }
    
    [Required] public int MsgId { get; set; }
    
    [Required] public ServerType ServerType { get; set; }
    
    public string Comment { get; set; }
}