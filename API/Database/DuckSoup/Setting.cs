using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.DuckSoup;

[Table("GlobalSetting")]
public class Setting
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SettingsId { get; set; }

    [Required] public string key { get; set; }

    [Required] public string value { get; set; }
}