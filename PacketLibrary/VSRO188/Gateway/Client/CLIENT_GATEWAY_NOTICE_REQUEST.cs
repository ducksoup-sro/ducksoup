using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_NOTICE#request
public class CLIENT_GATEWAY_NOTICE_REQUEST : Packet
{
    public byte ContentID;

    public CLIENT_GATEWAY_NOTICE_REQUEST() : base(0x6104)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;

    public override async Task Read()
    {
        TryRead(out ContentID);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(ContentID);
        return this;
    }

    public static Packet of(byte contentId)
    {
        return new CLIENT_GATEWAY_NOTICE_REQUEST
        {
            ContentID = contentId
        };
    }
}