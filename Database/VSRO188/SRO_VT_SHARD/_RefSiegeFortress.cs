namespace Database.VSRO188.SRO_VT_SHARD;

public class _RefSiegeFortress
{
    public byte Service { get; set; }

    public int FortressID { get; set; }

    public string CodeName128 { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string NameID128 { get; set; } = null!;

    public string LinkedTeleportCodeName { get; set; } = null!;

    public byte Scale { get; set; }

    public short MaxAdmission { get; set; }

    public byte MaxGuard { get; set; }

    public byte MaxBarricade { get; set; }

    public short TaxTargets { get; set; }

    public int RequestFee { get; set; }

    public string CrestPath128 { get; set; } = null!;

    public string RequestNPCName128 { get; set; } = null!;
}