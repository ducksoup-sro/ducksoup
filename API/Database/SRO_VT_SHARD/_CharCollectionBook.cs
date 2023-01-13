using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _CharCollectionBook
{
    public int CharID { get; set; }

    public int ThemeID { get; set; }

    public int SlotIndex { get; set; }

    public DateTime RegDate { get; set; }
}
