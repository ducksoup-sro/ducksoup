using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _Friend
{
    public int CharID { get; set; }

    public int FriendCharID { get; set; }

    public string FriendCharName { get; set; } = null!;

    public int? RefObjID { get; set; }
}
