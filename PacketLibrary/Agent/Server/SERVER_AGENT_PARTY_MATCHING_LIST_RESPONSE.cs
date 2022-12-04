using PacketLibrary.Enums;
using PacketLibrary.Objects.Agent;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_LIST
public class SERVER_AGENT_PARTY_MATCHING_LIST_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xB06C;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result;
    public byte PageCount;
    public byte PageIndex;
    public byte PartyCount;
    public List<PartyMatchEntry> PartyMatch = new();
    public ushort ErrorCode;

    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        switch (Result)
        {
            case 1:
            {
                PageCount = packet.ReadUInt8(); //     1   byte    PageCount
                PageIndex = packet.ReadUInt8(); //     1   byte    PageIndex
                PartyCount = packet.ReadUInt8(); //     1   byte    PartyCount
                for (var i = 0; i < PartyCount; i++)
                {
                    PartyMatch.Add(new PartyMatchEntry(packet));
                }

                break;
            }
            case 2:
                ErrorCode = packet.ReadUInt16();  //     2   ushort  errorCode
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
            {
                response.WriteUInt8(PageCount);
                response.WriteUInt8(PageIndex);
                response.WriteUInt8(PartyCount);
                foreach (var partyMatchEntry in PartyMatch)
                {
                    response = partyMatchEntry.Build(response);
                }

                break;
            }
            case 2:
                response.WriteUInt16(ErrorCode);
                break;
        }

        return response;
    }

    public static Packet of(byte pageCount, byte pageIndex, byte partyCount, List<PartyMatchEntry> partyMatch)
    {
        return new SERVER_AGENT_PARTY_MATCHING_LIST_RESPONSE
        {
            Result = 1,
            PageCount = pageCount,
            PageIndex = pageIndex,
            PartyCount = partyCount,
            PartyMatch = partyMatch
        }.Build();
    }
    
    public static Packet of(ushort errorCode)
    {
        return new SERVER_AGENT_PARTY_MATCHING_LIST_RESPONSE
        {
            Result = 2,
            ErrorCode = errorCode
        }.Build();
    }
}

