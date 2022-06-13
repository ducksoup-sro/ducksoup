#region

using System.Collections.Generic;
using API;
using API.Session;

#endregion

namespace DuckSoup.Library.Session;

public class SessionData : ISessionData
{
    private readonly Dictionary<string, object> _extraData;

    public SessionData()
    {
        _extraData = new Dictionary<string, object>();
    }

    public void Dispose()
    {
        LastSnowshieldUsage = null;
        JID = null;
        Charid = null;
        Charname = null;
        UniqueCharId = 0;
        LatestRegionId = null;
        SectorX = null;
        SectorY = null;
        PositionX = null;
        PositionY = null;
        PositionZ = null;
        PvpState = null;
        InCombat = null;
        ScrollingType = null;
        GameStateType = null;
        JobType = null;
        PartyMatchingId = null;
    }

    public long? LastSnowshieldUsage { get; set; }
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
    public PvpState? PvpState { get; set; }
    public bool? InCombat { get; set; }
    public Scrolling? ScrollingType { get; set; }
    public GameState? GameStateType { get; set; }
    public Job? JobType { get; set; }
    public uint? PartyMatchingId { get; set; }

    public object this[string field]
    {
        get => _extraData.ContainsKey(field) ? _extraData[field] : "";
        set => _extraData[field] = value;
    }
}