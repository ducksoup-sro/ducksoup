using Database.VSRO188.SRO_VT_SHARD;

namespace API.Database.VSRO188.SRO_VT_SHARD;

public class _RefObjCommon : global::Database.VSRO188.SRO_VT_SHARD._RefObjCommon
{
    private _RefObjItem? _refObjItem;

    public _RefObjItem GetRefObjItem()
    {
        return _refObjItem ??= ServiceFactory.ServiceFactory
            .Load<ISharedObjects>(typeof(ISharedObjects)).RefObjItem
            .FirstOrDefault(c => c.Value.ID == Link).Value;
    }
        
    private _RefObjChar? _refObjChar;

    public _RefObjChar GetRefObjChar()
    {
        return _refObjChar ??= ServiceFactory.ServiceFactory
            .Load<ISharedObjects>(typeof(ISharedObjects)).RefObjChar
            .FirstOrDefault(c => c.Value.ID == Link).Value;
    }
}