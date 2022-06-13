using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.DuckSoup;

[Table("Event")]
public class Event
{
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EventId { get; set; }

    [Required] public string Eventname { get; set; }

    [Required] public string Crontime { get; set; }

    public string Comment { get; set; }
}