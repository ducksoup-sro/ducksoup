using System;
using System.Collections.Generic;

namespace API.Database.DuckSoup;

public partial class Event
{
    public int EventId { get; set; }

    public string Eventname { get; set; } = null!;

    public string Crontime { get; set; } = null!;

    public string? Comment { get; set; }
}
