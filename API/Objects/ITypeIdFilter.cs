
using API.Database.SRO_VT_SHARD;

namespace API.Objects;

// https://github.com/SDClowen/RSBot/
public interface ITypeIdFilter
{
    byte TypeID1 { get; set; }
    byte TypeID2 { get; set; }
    byte TypeID3 { get; set; }
    byte TypeID4 { get; set; }

    bool CompareByTypeID1 { get; set; }
    bool CompareByTypeID2 { get; set; }
    bool CompareByTypeID3 { get; set; }
    bool CompareByTypeID4 { get; set; }
    
    Predicate<_RefObjCommon> _condition { get; set; }
    bool EqualsRefItem(_RefObjCommon item);
}