#region

#endregion

using System.Text.Json.Serialization;
using API.Database.SRO_VT_SHARD;
using API.Objects.Cos;

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
        ITransport? Transport { get; set; }
        IJobTransport? JobTransport { get; set; }
        IGrowth? Growth { get; set; }
        IAbility? AbilityPet { get; set; }
        IFellow? Fellow { get; set; }
        ICos? Vehicle { get; set; }
        bool OnTransport { get; set; }
        uint TransportUniqueId { get; set; }

        [JsonIgnore]
        C_Char GetChar { get; }
        public object this[string field] { get; set; }
    }
}