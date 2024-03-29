﻿using System;
using API.Database.SRO_VT_SHARD;
using API.Objects;

namespace DuckSoup.Library.Objects;

// https://github.com/SDClowen/RSBot/
public class TypeIdFilter : ITypeIdFilter
{
    public byte TypeID1 { get; set; }
    public byte TypeID2 { get; set; }
    public byte TypeID3 { get; set; }
    public byte TypeID4 { get; set; }

    public bool CompareByTypeID1 { get; set; }
    public bool CompareByTypeID2 { get; set; }
    public bool CompareByTypeID3 { get; set; }
    public bool CompareByTypeID4 { get; set; }

    public Predicate<_RefObjCommon> _condition { get; set; }
        
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