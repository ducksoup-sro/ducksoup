#region

#endregion

namespace API.Session
{
    public interface ISessionData
    {
        IState State { get; }
        long? LastSnowshieldUsage { get; set; }
        int? JID { get; set; }
        int? Charid { get; set; }
        string Charname { get; set; }
        uint UniqueCharId { get; set; }
        int? LatestRegionId { get; set; }
        int? SectorX { get; set; }
        int? SectorY { get; set; }
        float? PositionX { get; set; }
        float? PositionY { get; set; }
        float? PositionZ { get; set; }
        Job? JobType { get; set; }
        uint? PartyMatchingId { get; set; }
        public object this[string field] { get; set; }
    }
}