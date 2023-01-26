#region

using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using API;
using API.Database.Context;
using API.Database.SRO_VT_SHARD;
using API.Objects;
using API.Objects.Cos;
using API.Session;
using DuckSoup.Library.Objects;

#endregion

namespace DuckSoup.Library.Session;

public class SessionData : ISessionData
{
    private readonly Dictionary<string, object> _extraData;

    public SessionData()
    {
        _extraData = new Dictionary<string, object>();
        State = new State();
    }

    public IState State { get; }
    public long? LastSnowshieldUsage { get; set; }
    public long? LastClientReady { get; set; }
    public int? JID { get; set; }
    public int? Charid { get; set; }
    public string Charname { get; set; }
    public uint UniqueCharId { get; set; }
    public int? LatestRegionId { get; set; }
    public int? SectorX { get; set; }
    public int? SectorY { get; set; }
    public float? PositionX { get; set; }
    public float? PositionY { get; set; }
    public float? PositionZ { get; set; }
    public Job? JobType { get; set; }
    public uint? PartyMatchingId { get; set; }
    public ITransport? Transport { get; set; }
    public IJobTransport? JobTransport { get; set; }
    public IGrowth? Growth { get; set; }
    public IAbility? AbilityPet { get; set; }
    public IFellow? Fellow { get; set; }
    public ICos? Vehicle { get; set; }
    public bool OnTransport { get; set; }
    public uint TransportUniqueId { get; set; }
    public bool FirstSpawn { get; set; } = false;

    [JsonIgnore]
    public _Char GetChar
    {
        get
        {
            using var db = new SRO_VT_SHARD();
            return db._Chars.First(c => c.CharID == Charid);
        }
    }
    
    public object this[string field]
    {
        get => _extraData.ContainsKey(field) ? _extraData[field] : "";
        set => _extraData[field] = value;
    }
}