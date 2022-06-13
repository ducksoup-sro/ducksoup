using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.DuckSoup;

[Table("Machine")]
public class Machine
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MachineId { get; set; }

    [Required] [StringLength(15)] public string Address { get; set; }
    
    public string Notice { get; set; }
}