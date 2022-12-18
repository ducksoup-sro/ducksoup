using API.Database.SRO_VT_ACCOUNT;
using API.Database.SRO_VT_SHARD;
using API.Session;

namespace API;

public interface ISharedObjects : IDisposable
{
    Dictionary<int, C_RefObjChar> RefObjChar { get; }
    Dictionary<int, C_RefObjCharExtraSkill> RefObjCharExtraSkill { get; }
    Dictionary<int, C_RefObjCommon> RefObjCommon { get; }
    Dictionary<int, C_RefObjItem> RefObjItem { get; }
    Dictionary<int, C_RefObjStruct> RefObjStruct { get; }
    Dictionary<int, C_RefSkill> RefSkill { get; }
    Dictionary<int, C_Notice> Notice { get; }

    HashSet<ISession> DownloadSessions { get; }
    HashSet<ISession> GatewaySessions { get; }
    HashSet<ISession> AgentSessions { get; }
}