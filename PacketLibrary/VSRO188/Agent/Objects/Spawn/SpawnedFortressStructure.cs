using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public sealed class SpawnedFortressStructure : SpawnedNpc
{
    public uint HP;
    public uint RefEventStructID;
    public ushort CurrentState;
    public SpawnedFortressStructure(uint objId) :
        base(objId) { }
    internal override void Deserialize(Packet packet)
    {
        packet.TryRead<uint>(out HP)
            .TryRead<uint>(out RefEventStructID)
            .TryRead<ushort>(out CurrentState);

        ParseBionicDetails(packet);

        base.Deserialize(packet);
    }
}