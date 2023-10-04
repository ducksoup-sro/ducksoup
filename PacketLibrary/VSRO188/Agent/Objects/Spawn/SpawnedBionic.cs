using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedBionic : SpawnedEntity
{
    public bool AttackingPlayer;
    public BadStatus BadEffect;
    public int Health;
    public uint TargetId;

    public SpawnedBionic(uint objId)
    {
        Id = objId;

        if (RefObjChar != null)
            Health = RefObjChar.MaxHP;
    }

    public bool HasHealth => Health > 0;

    public void ParseBionicDetails(Packet packet)
    {
        packet.TryRead(out UniqueId);

        var movement = Movement.FromPacket(packet);
        State.Deserialize(packet);
    }
}