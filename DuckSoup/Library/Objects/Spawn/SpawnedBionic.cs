using API;
using DuckSoup.Library.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedBionic : SpawnedEntity
{
    public bool AttackingPlayer { get; private set; }
    public bool HasHealth => Health > 0;
    public int Health { get; set; }
    public BadStatus BadEffect { get; set; }
    public uint TargetId { get; set; }
    public SpawnedBionic(uint objId)
    {
        Id = objId;

        if (RefObjChar != null)
            Health = RefObjChar.MaxHP;
    }
    internal void ParseBionicDetails(Packet packet)
    {
        UniqueId = packet.ReadUInt32();

        var movement = Movement.FromPacket(packet);
        State.Deserialize(packet);
    }
}