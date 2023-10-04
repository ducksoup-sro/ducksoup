using Database.VSRO188.SRO_VT_SHARD;

namespace PacketLibrary.VSRO188.Agent.Objects;

// https://github.com/SDClowen/RSBot/
public class TypeIdFilter
{
    public bool CompareByTypeID1;
    public bool CompareByTypeID2;
    public bool CompareByTypeID3;
    public bool CompareByTypeID4;
    public byte TypeID1;
    public byte TypeID2;
    public byte TypeID3;
    public byte TypeID4;

    public TypeIdFilter(byte t1, byte t2, byte t3, byte t4)
    {
        TypeID1 = t1;
        TypeID2 = t2;
        TypeID3 = t3;
        TypeID4 = t4;
    }

    public TypeIdFilter(Predicate<_RefObjCommon> condition)
    {
        _condition = condition;
    }

    public TypeIdFilter()
    {
    }

    public Predicate<_RefObjCommon> _condition { get; set; }

    public bool EqualsRefItem(_RefObjCommon item)
    {
        if (_condition != null && _condition(item))
            return true;

        if (CompareByTypeID1)
            return TypeID1 == item.TypeID1;

        if (CompareByTypeID2)
            return TypeID2 == item.TypeID2;

        if (CompareByTypeID3)
            return TypeID3 == item.TypeID3;

        if (CompareByTypeID4)
            return TypeID4 == item.TypeID4;

        return TypeID1 == item.TypeID1 && TypeID2 == item.TypeID2 && TypeID3 == item.TypeID3 && TypeID4 == item.TypeID4;
    }
}