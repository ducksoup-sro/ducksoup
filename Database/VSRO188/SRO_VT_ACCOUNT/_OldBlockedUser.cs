using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_ACCOUNT;

public partial class _OldBlockedUser
{
    public int UserJID { get; set; }

    public byte Type { get; set; }

    public int SerialNo { get; set; }

    public DateTime timeBegin { get; set; }

    public DateTime timeEnd { get; set; }
}
