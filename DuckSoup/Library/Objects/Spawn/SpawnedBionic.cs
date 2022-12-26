using API;
using API.Objects.Spawn;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedBionic : SpawnedEntity, ISpawnedBionic
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

    public void ParseBionicDetails(Packet packet)
    {
        UniqueId = packet.ReadUInt32();

        var movement = Objects.Movement.FromPacket(packet);
        State.Deserialize(packet);
    }
}