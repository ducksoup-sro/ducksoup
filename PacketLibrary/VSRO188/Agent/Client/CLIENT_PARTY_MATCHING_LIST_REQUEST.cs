using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_LIST
public class CLIENT_PARTY_MATCHING_LIST_REQUEST : Packet
{
    public byte PageIndex;

    public CLIENT_PARTY_MATCHING_LIST_REQUEST() : base(0x706C)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead<byte>(out PageIndex);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<byte>(PageIndex);
        return this;
    }

    public static Task<Packet> of(byte pageIndex)
    {
        return new CLIENT_PARTY_MATCHING_LIST_REQUEST
        {
            PageIndex = pageIndex
        }.Build();
    }
}