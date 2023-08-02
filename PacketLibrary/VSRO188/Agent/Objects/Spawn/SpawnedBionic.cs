using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedBionic : SpawnedEntity
{
    public bool AttackingPlayer;
    public bool HasHealth => Health > 0;
    public int Health;
    public BadStatus BadEffect;
    public uint TargetId;
    public SpawnedBionic(uint objId)
    {
        Id = objId;

        if (RefObjChar != null)
            Health = RefObjChar.MaxHP;
    }

    public void ParseBionicDetails(Packet packet)
    {
        packet.TryRead<uint>(out UniqueId);

        var movement = Movement.FromPacket(packet);
        State.Deserialize(packet);
    }
}