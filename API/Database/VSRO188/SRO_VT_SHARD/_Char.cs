using Database.VSRO188.SRO_VT_SHARD;

namespace API.Database.VSRO188.SRO_VT_SHARD;

public class _Char : global::Database.VSRO188.SRO_VT_SHARD._Char
{
    public _RefObjCommon? _refObjCommon;

    public _RefObjCommon RefObjCommon
    {
        get
        {
            return _refObjCommon ??= ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon
                .First(c => c.Value.ID == RefObjID).Value;
        }
    }

    public _RefObjChar? _refObjChar;
    
    public _RefObjChar RefObjChar
    {
        get
        {
            return _refObjChar ??= ServiceFactory.ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjChar
                .First(c => c.Value.ID == RefObjCommon.Link).Value;
        }
    }

    public bool IsMale()
    {
        return RefObjChar.CharGender == 1;
    }
        
    public bool IsFemale()
    {
        return RefObjChar.CharGender == 0;
    }
}