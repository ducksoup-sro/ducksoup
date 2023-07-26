using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _AssociationReputation
{
    public string AssociationCodeName { get; set; } = null!;

    public string AssociationTypeName { get; set; } = null!;

    public int Reputation { get; set; }

    public int PriorOccupation { get; set; }
}
