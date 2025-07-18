namespace API.Database.DuckSoup;

public class Event
{
    public int EventId { get; set; }

    public string Eventname { get; set; } = null!;

    public string Crontime { get; set; } = null!;

    public string? Comment { get; set; }
}