using PacketLibrary.ISRO_R.Gateway.Client;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Server;

public class SERVER_GATEWAY_LOGIN_PIN_REQUEST : Packet
{
    public byte Flag;

    /// <summary>
    ///     1. <see cref="SERVER_GATEWAY_LOGIN_PIN_REQUEST" />
    ///     2. <see cref="CLIENT_GATEWAY_LOGIN_PIN_RESPONSE" />
    ///     3. <see cref="PacketLibrary.ISRO_R.Gateway.Server.SERVER_GATEWAY_LOGIN_PING_RESPONSE" />
    /// </summary>
    public SERVER_GATEWAY_LOGIN_PIN_REQUEST() : base(0x2116)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        // 0000000000   01                                                ................
        TryRead(out Flag);
    }

    public override async Task<Packet> Build()
    {
        Reset();

        TryWrite(Flag);
        return this;
    }
}