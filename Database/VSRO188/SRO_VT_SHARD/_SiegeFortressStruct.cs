using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _SiegeFortressStruct
{
    public int FortressID { get; set; }

    public int OwnerGuildID { get; set; }

    public int RefEventStructID { get; set; }

    public int RefObjID { get; set; }

    public int HP { get; set; }

    public DateTime MakeDate { get; set; }

    public short State { get; set; }
}
