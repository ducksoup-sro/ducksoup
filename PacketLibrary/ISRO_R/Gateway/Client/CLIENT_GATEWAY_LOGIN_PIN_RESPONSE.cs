using PacketLibrary.ISRO_R.Gateway.Server;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Client;

public class CLIENT_GATEWAY_LOGIN_PIN_RESPONSE : Packet
{
    /// <summary>
    /// 1. <see cref="SERVER_GATEWAY_LOGIN_PIN_REQUEST"/>
    /// 2. <see cref="CLIENT_GATEWAY_LOGIN_PIN_RESPONSE"/>
    /// 3. <see cref="PacketLibrary.ISRO_R.Gateway.Server.SERVER_GATEWAY_LOGIN_PING_RESPONSE"/>
    /// </summary>
    public CLIENT_GATEWAY_LOGIN_PIN_RESPONSE() : base(0x6117, true, false)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;
    
    public async override Task Read()
    {
        // 0000000000   04 06 00 78 54 59 73 A6 4A 4C 2A                  ...xTYs¦JL*.....
    }

    public async override Task<Packet> Build()
    {
        return this;
    }
}