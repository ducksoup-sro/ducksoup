using API;
using API.ServiceFactory;
using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_DISTRIBUTION
public class SERVER_AGENT_PARTY_DISTRIBUTION : IPacketStructure
{
    public static ushort MsgId => 0x3068;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public uint UserJID;
    public uint RefItemID;
    public byte OptLevel;
    public ushort Quantity;

    public Task Read(Packet packet)
    {
        UserJID = packet.ReadUInt32(); // 4   uint    memberInfo.JID
        RefItemID = packet.ReadUInt32(); // 4   uint    RefItemID
        var item = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon[(int) RefItemID];
        if (item.TypeID1 != 3) return Task.CompletedTask;
        switch (item.TypeID2)
        {
            //ITEM_
            case 1:
                //ITEM_CH_
                //ITEM_EU_
                //ITEM_AVATAR_
                OptLevel = packet.ReadUInt8(); // 1   byte    OptLevel
                break;
            case 2:
                //ITEM_COS_
                // No message triggered by server.        
                break;
            case 3:
                //ITEM_ETC_
                Quantity = packet.ReadUInt16(); // 2   ushort  Quantity            
                break;
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt32(UserJID); 
        response.WriteUInt32(RefItemID);
        var item = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon[(int) RefItemID];
        if (item.TypeID1 != 3) return response;
        switch (item.TypeID2)
        {
            //ITEM_
            case 1:
                //ITEM_CH_
                //ITEM_EU_
                //ITEM_AVATAR_
                response.WriteUInt8(OptLevel);
                break;
            case 2:
                //ITEM_COS_
                // No message triggered by server.        
                break;
            case 3:
                //ITEM_ETC_
                response.WriteUInt16(Quantity);            
                break;
        }

        return response;
    }

    public static Packet of(uint userJID, uint refItemId, byte optLevel)
    {
        return new SERVER_AGENT_PARTY_DISTRIBUTION
        {
            UserJID = userJID,
            RefItemID = refItemId,
            OptLevel = optLevel
        }.Build();
    }
    
    public static Packet of(uint userJID, uint refItemId, ushort quantity)
    {
        return new SERVER_AGENT_PARTY_DISTRIBUTION
        {
            UserJID = userJID,
            RefItemID = refItemId,
            Quantity = quantity
        }.Build();
    }
}

