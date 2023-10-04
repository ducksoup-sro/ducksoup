using PacketLibrary.ISRO_R.Gateway.Client;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Server;

public class SERVER_GATEWAY_LOGIN_PIN_RESPONSE : Packet
{
    /// <summary>
    ///     1. <see cref="SERVER_GATEWAY_LOGIN_PIN_REQUEST" />
    ///     2. <see cref="CLIENT_GATEWAY_LOGIN_PIN_RESPONSE" />
    ///     3. <see cref="PacketLibrary.ISRO_R.Gateway.Server.SERVER_GATEWAY_LOGIN_PING_RESPONSE" />
    /// </summary>
    public SERVER_GATEWAY_LOGIN_PIN_RESPONSE() : base(0xA117)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        // 0000000000   04 01                                             ................

        /**
                     var type = packet.ReadByte();
            if (type != 4)
                return;

            var result = packet.ReadByte();
            if(result == 1)
            {
                Log.NotifyLang("SecondaryPwSuccess");
                return;
            }

            var errorCode = packet.ReadByte();
            switch (errorCode)
            {
                case 1:
                    Log.NotifyLang("SecondaryPwWrong");
                    break;
                default:
                    break;
            }
         */
    }

    public override async Task<Packet> Build()
    {
        return this;
    }
}