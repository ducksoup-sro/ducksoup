using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _SiegeFortressObject
{
    public int ID { get; set; }

    public int FortressID { get; set; }

    public int OwnerGuildID { get; set; }

    public int RefObjID { get; set; }

    public int HP { get; set; }

    public short Region { get; set; }

    public float PosX { get; set; }

    public float PosY { get; set; }

    public float PosZ { get; set; }

    public float Direction { get; set; }

    public byte OwnerLevel { get; set; }
}
