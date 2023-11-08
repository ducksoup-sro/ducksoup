using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.CharacterSelection;

public class SelectionItem
{
    public uint RefItemId;
    public byte Plus;

    public SelectionItem(Packet packet)
    {
        Read(packet);
    }

    public async Task Read(Packet packet)
    {
        packet.TryRead(out RefItemId)
            .TryRead(out Plus);
    }
    
    public async Task Build(Packet packet)
    {
        packet.TryWrite(RefItemId)
            .TryWrite(Plus);
    }

    public _RefObjCommon? _RefObjCommon => Cache.GetRefObjCommonAsync((int)RefItemId).Result;
    public _RefObjItem? _RefObjItem => Cache.GetRefObjItemAsync(_RefObjCommon.Link).Result;
}