using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public sealed class SpawnedFortressStructure : SpawnedNpc
{
    public ushort CurrentState;
    public uint HP;
    public uint RefEventStructID;

    public SpawnedFortressStructure(uint objId) :
        base(objId)
    {
    }

    internal override void Deserialize(Packet packet)
    {
        packet.TryRead(out HP)
            .TryRead(out RefEventStructID)
            .TryRead(out CurrentState);

        ParseBionicDetails(packet);

        base.Deserialize(packet);
    }
}