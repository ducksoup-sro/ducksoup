using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Server;

public class SERVER_GATEWAY_LOGIN_PIN_REQUEST : Packet
{
    /// <summary>
    /// 1. <see cref="PacketLibrary.ISRO_R.Gateway.Server.SERVER_GATEWAY_LOGIN_PIN_REQUEST"/>
    /// 2. <see cref="PacketLibrary.ISRO_R.Gateway.Client.CLIENT_GATEWAY_LOGIN_PIN_RESPONSE"/>
    /// 3. <see cref="PacketLibrary.ISRO_R.Gateway.Server.SERVER_GATEWAY_LOGIN_PING_RESPONSE"/>
    /// </summary>
    public SERVER_GATEWAY_LOGIN_PIN_REQUEST() : base(0x2116, false, false)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public byte Flag;
    
    public async override Task Read()
    {
        // 0000000000   01                                                ................
        TryRead<byte>(out Flag);
    }

    public async override Task<Packet> Build()
    {
        Reset();

        TryWrite<byte>(Flag);
        return this;
    }
}