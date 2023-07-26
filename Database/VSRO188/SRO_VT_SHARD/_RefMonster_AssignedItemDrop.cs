using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefMonster_AssignedItemDrop
{
    public int RefMonsterID { get; set; }

    public int RefItemID { get; set; }

    public byte DropGroupType { get; set; }

    public byte OptLevel { get; set; }

    public byte DropAmountMin { get; set; }

    public byte DropAmountMax { get; set; }

    public float DropRatio { get; set; }

    public short? RefMagicOptionID1 { get; set; }

    public int? CustomValue1 { get; set; }

    public short? RefMagicOptionID2 { get; set; }

    public int? CustomValue2 { get; set; }

    public short? RefMagicOptionID3 { get; set; }

    public int? CustomValue3 { get; set; }

    public short? RefMagicOptionID4 { get; set; }

    public int? CustomValue4 { get; set; }

    public short? RefMagicOptionID5 { get; set; }

    public int? CustomValue5 { get; set; }

    public short? RefMagicOptionID6 { get; set; }

    public int? CustomValue6 { get; set; }

    public short? RefMagicOptionID7 { get; set; }

    public int? CustomValue7 { get; set; }

    public short? RefMagicOptionID8 { get; set; }

    public int? CustomValue8 { get; set; }

    public short? RefMagicOptionID9 { get; set; }

    public int? CustomValue9 { get; set; }

    public string RentCodeName { get; set; } = null!;
}
