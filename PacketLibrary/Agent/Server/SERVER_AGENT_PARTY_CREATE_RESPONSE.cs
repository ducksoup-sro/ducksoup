using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_CREATE
public class SERVER_AGENT_PARTY_CREATE_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xB060;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result;
    public uint JID;
    public ushort ErrorCode;
    
    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        switch (Result)
        {
            case 1:
                JID = packet.ReadUInt32(); // 4   uint    JID // leader JID
                break;
            case 2:
                ErrorCode = packet.ReadUInt16(); // 2   ushort  errorCode
                //11276 = The request for the party denied.
                //11280 = The party invite automaticly cancelled due to no response form the other player.
                //11288 = Player is in another party.
                //11301 = The user registered a party in the party matching system.
                break;
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result);
        switch (Result)
        {
            case 1:
                response.WriteUInt32(JID);
                break;
            case 2:
                response.WriteUInt16(ErrorCode);
                break;
        }
        return response;
    }

    public static Packet of(uint jid)
    {
        return new SERVER_AGENT_PARTY_CREATE_RESPONSE()
        {
            Result = 1,
            JID = jid
        }.Build();
    }
    
    public static Packet of(ushort errorCode)
    {
        return new SERVER_AGENT_PARTY_CREATE_RESPONSE
        {
            Result = 2,
            ErrorCode = errorCode
        }.Build();
    }
}

