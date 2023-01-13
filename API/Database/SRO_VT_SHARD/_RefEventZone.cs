using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefEventZone
{
    public int Service { get; set; }

    public int ID { get; set; }

    public string ZoneName { get; set; } = null!;

    public string EventName { get; set; } = null!;

    public int? Param1 { get; set; }

    public int? Param2 { get; set; }

    public int? Param3 { get; set; }

    public int? Param4 { get; set; }

    public int? Param5 { get; set; }

    public string? strParam1 { get; set; }

    public string? strParam2 { get; set; }

    public string? strParam3 { get; set; }

    public string? strParam4 { get; set; }

    public string? strParam5 { get; set; }
}
