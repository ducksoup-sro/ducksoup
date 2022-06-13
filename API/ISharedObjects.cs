using API.Database.SRO_VT_ACCOUNT;
using API.Database.SRO_VT_SHARD;
using API.Session;

namespace API;

public interface ISharedObjects : IDisposable
{
    Dictionary<int, C_RefObjCommon> RefObjCommon { get; }
    Dictionary<int, C_RefSkill> RefSkill { get; }
    Dictionary<int, C_Notice> Notice { get; }

    HashSet<ISession> DownloadSessions { get; }
    HashSet<ISession> GatewaySessions { get; }
    HashSet<ISession> AgentSessions { get; }
}