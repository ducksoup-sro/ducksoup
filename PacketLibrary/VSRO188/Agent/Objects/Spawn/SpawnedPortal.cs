using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public sealed class SpawnedPortal : SpawnedBionic
{
    public string OwnerName;
    public uint OwnerUniqueId;

    public SpawnedPortal(uint objId)
        : base(objId)
    {
    }

    internal static SpawnedPortal FromPacket(Packet packet, uint characterId)
    {
        var result = new SpawnedPortal(characterId);

        packet.TryRead(out result.UniqueId);
        result.Movement.Source = Position.FromPacket(packet);

        packet.TryRead<byte>(out var unk0)
            .TryRead<byte>(out var unk1)
            .TryRead<byte>(out var unk2)
            .TryRead<byte>(out var unk3);

        if (unk3 == 1)
            //Regular portal
            packet.TryRead<uint>(out var unk4)
                .TryRead<uint>(out var unk5);
        else if (unk3 == 6)
            //Dimension hole
            packet.TryRead(out result.OwnerName)
                .TryRead(out result.OwnerUniqueId);

        if (unk1 == 1)
            packet.TryRead<uint>(out var unk6)
                .TryRead<byte>(out var unk7);

        return result;
    }
}