using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.CharacterSelection;

public class SelectionItem
{
    public byte Plus;
    public uint RefItemId;

    public SelectionItem(Packet packet)
    {
        Read(packet);
    }

    public _RefObjCommon? _RefObjCommon => Cache.GetRefObjCommonAsync((int)RefItemId).Result;
    public _RefObjItem? _RefObjItem => Cache.GetRefObjItemAsync(_RefObjCommon.Link).Result;

    public async Task Read(Packet packet)
    {
        packet.TryRead<uint>(out RefItemId)
            .TryRead<byte>(out Plus);
    }

    public async Task Build(Packet packet)
    {
        packet.TryWrite<uint>(RefItemId)
            .TryWrite<byte>(Plus);
    }
}