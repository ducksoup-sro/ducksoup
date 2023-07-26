﻿using API.Session;
using Database.VSRO188.SRO_VT_ACCOUNT;
using Database.VSRO188.SRO_VT_SHARD;

namespace API;

public interface ISharedObjects : IDisposable
{
    Dictionary<int, _RefObjChar> RefObjChar { get; }
    Dictionary<int, _RefObjCharExtraSkill> RefObjCharExtraSkill { get; }
    Dictionary<int, API.Database.VSRO188.SRO_VT_SHARD._RefObjCommon> RefObjCommon { get; }
    Dictionary<int, API.Database.VSRO188.SRO_VT_SHARD._RefObjItem> RefObjItem { get; }
    Dictionary<int, _RefObjStruct> RefObjStruct { get; }
    Dictionary<byte, _RefLevel> RefLevel { get; }
    Dictionary<int, _RefSkill> RefSkill { get; }
    Dictionary<int, _Notice> Notice { get; }

    HashSet<ISession> DownloadSessions { get; }
    HashSet<ISession> GatewaySessions { get; }
    HashSet<ISession> AgentSessions { get; }
}