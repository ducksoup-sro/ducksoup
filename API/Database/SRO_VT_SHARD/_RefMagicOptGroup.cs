using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefMagicOptGroup
{
    public byte Service { get; set; }

    public int LinkID { get; set; }

    public byte MagicType { get; set; }

    public string CodeName128 { get; set; } = null!;

    public int MOptID { get; set; }

    public byte MOptLevel { get; set; }

    public int Value { get; set; }

    public int Param1 { get; set; }

    public string Param1_Desc { get; set; } = null!;

    public int Param2 { get; set; }

    public string Param2_Desc { get; set; } = null!;
}
