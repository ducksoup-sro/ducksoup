using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedNpc : SpawnedBionic
{
    public SpawnedNpc(uint objId)
        : base(objId)
    {
    }

    public NpcTalk Talk { get; } = new();

    internal virtual void Deserialize(Packet packet)
    {
        Talk.Deserialize(packet);
    }
}