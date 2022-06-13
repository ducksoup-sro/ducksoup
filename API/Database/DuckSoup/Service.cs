using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.DuckSoup;

[Table("Service")]
public class Service 
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceId { get; set; }

    [Required] public string Name { get; set; }
    
    [Required] public ServerType ServerType { get; set; }
    
    [Required] public Machine LocalMachine { get; set; }
    
    [Required] public Machine RemoteMachine { get; set; }
    
    public Machine? SpoofMachine { get; set; }
    
    [Required] public int RemotePort { get; set; }
    
    [Required] public int BindPort { get; set; }
    
    [DefaultValue(2048)] [Required] public int ByteLimitation { get; set; }
    [DefaultValue(true)] [Required] public bool AutoStart { get; set; }
}