using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefFmnCategoryTree
{
    public byte Service { get; set; }

    public string CategoryName { get; set; } = null!;

    public string StringID { get; set; } = null!;

    public string ParentCategoryName { get; set; } = null!;

    public int TidGroupID { get; set; }

    public byte Degree { get; set; }
}
