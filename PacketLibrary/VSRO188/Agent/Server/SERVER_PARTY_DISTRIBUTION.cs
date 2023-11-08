using Database.VSRO188;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_DISTRIBUTION
public class SERVER_PARTY_DISTRIBUTION : Packet
{
    public uint UserJID;
    public uint RefItemID;
    public byte OptLevel;
    public ushort Quantity;
    
    public SERVER_PARTY_DISTRIBUTION() : base(0x3068)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out UserJID);
        TryRead(out RefItemID);
        var item = await Cache.GetRefObjCommonAsync((int) RefItemID);
        if (item == null || item.TypeID1 != 3)
        {
            return;
        }
        switch (item.TypeID2)
        {
            case 1:
                TryRead(out OptLevel);
                break;
            case 2:
                // No message triggered by server.        
                break;
            case 3:
                TryRead(out Quantity);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(UserJID);
        TryWrite(RefItemID);
        var item = await Cache.GetRefObjCommonAsync((int) RefItemID);
        if (item == null || item.TypeID1 != 3)
        {
            return this;
        }
        switch (item.TypeID2)
        {
            case 1:
                TryWrite(OptLevel);
                break;
            case 2:
                // No message triggered by server.        
                break;
            case 3:
                TryWrite(Quantity);
                break;
        }
        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_DISTRIBUTION();
    }
}