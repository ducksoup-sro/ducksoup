using System;
using System.Collections.Generic;

namespace API.Database.DuckSoup;

public partial class Whitelist
{
    public int WhitelistId { get; set; }

    public int MsgId { get; set; }

    public ServerType ServerType { get; set; }

    public string? Comment { get; set; }
}
