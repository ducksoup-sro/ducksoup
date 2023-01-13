using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefTeleport
{
    public int Service { get; set; }

    public int ID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public string? AssocRefObjCodeName128 { get; set; }

    public int AssocRefObjID { get; set; }

    public string ZoneName128 { get; set; } = null!;

    public short GenRegionID { get; set; }

    public short GenPos_X { get; set; }

    public short GenPos_Y { get; set; }

    public short GenPos_Z { get; set; }

    public short GenAreaRadius { get; set; }

    public byte CanBeResurrectPos { get; set; }

    public byte CanGotoResurrectPos { get; set; }

    public short GenWorldID { get; set; }

    public byte BindInteractionMask { get; set; }

    public byte FixedService { get; set; }
}
