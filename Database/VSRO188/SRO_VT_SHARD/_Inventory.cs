namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _Inventory
{
    public int CharID { get; set; }

    public byte Slot { get; set; }

    public long ItemID { get; set; }
    
    private _Item? _item;

    public _Item? GetItem()
    {
        if (_item != null) return _item;
        
        using var db = new Context.SRO_VT_SHARD();
        _item = db._Items.FirstOrDefault(c => ItemID == c.ID64);
        return _item;
    }
        
    private _Char? _char;

    public _Char? GetChar()
    {
        if (_char != null) return _char;
        
        using var db = new Context.SRO_VT_SHARD();
        _char = db._Chars.FirstOrDefault(c => CharID == c.CharID);
        return _char;
    }
}
