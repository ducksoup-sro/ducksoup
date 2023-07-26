using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#ibuv-confirm-request
public class CLIENT_GATEWAY_LOGIN_IBUV_CONFIRM_REQUEST : Packet
{
    public string Code;

    public CLIENT_GATEWAY_LOGIN_IBUV_CONFIRM_REQUEST() : base(0x6323)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;

    public override async Task Read()
    {
        TryRead(out Code);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Code);
        return this;
    }

    public static Packet of(string code)
    {
        return new CLIENT_GATEWAY_LOGIN_IBUV_CONFIRM_REQUEST
        {
            Code = code
        };
    }
}