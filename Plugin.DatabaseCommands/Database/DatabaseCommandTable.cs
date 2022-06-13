using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618

namespace Plugin.DatabaseCommands.Database;

[Table("DatabaseCommand")]
public class DatabaseCommandTable
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CommandId { get; set; }
    
    [Required] public string Command { get; set; }
    
    public DateTime? SendAfter { get; set; }
}