using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedPlayerStall
{
    public string Name { get; set; }
    public uint DecorationId { get; set; }

    public _RefObjItem Decoration => Cache.GetRefObjItemAsync((int)DecorationId).Result;

    internal static SpawnedPlayerStall FromPacket(Packet packet)
    {
        packet.TryRead(out var name)
            .TryRead<uint>(out var decorationId);

        return new SpawnedPlayerStall
        {
            Name = name,
            DecorationId = decorationId
        };
    }
}