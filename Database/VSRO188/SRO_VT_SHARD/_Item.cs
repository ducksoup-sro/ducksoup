namespace Database.VSRO188.SRO_VT_SHARD;

public class _Item
{
    private _RefObjCommon? _refObjCommon;
    public long ID64 { get; set; }

    public int RefItemID { get; set; }

    public byte? OptLevel { get; set; }

    public long? Variance { get; set; }

    public int Data { get; set; }

    public string? CreaterName { get; set; }

    public byte MagParamNum { get; set; }

    public long? MagParam1 { get; set; }

    public long? MagParam2 { get; set; }

    public long? MagParam3 { get; set; }

    public long? MagParam4 { get; set; }

    public long? MagParam5 { get; set; }

    public long? MagParam6 { get; set; }

    public long? MagParam7 { get; set; }

    public long? MagParam8 { get; set; }

    public long? MagParam9 { get; set; }

    public long? MagParam10 { get; set; }

    public long? MagParam11 { get; set; }

    public long? MagParam12 { get; set; }

    public long Serial64 { get; set; }

    public _RefObjCommon? GetChar()
    {
        if (_refObjCommon != null) return _refObjCommon;

        using var db = new Context.SRO_VT_SHARD();
        _refObjCommon = db._RefObjCommons.FirstOrDefault(c => RefItemID == c.ID);
        return _refObjCommon;
    }
}