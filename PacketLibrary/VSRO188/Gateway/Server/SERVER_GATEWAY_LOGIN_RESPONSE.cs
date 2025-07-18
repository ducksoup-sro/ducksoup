using PacketLibrary.Global.Objects;
using PacketLibrary.VSRO188.Gateway.Enums;
using PacketLibrary.VSRO188.Gateway.Objects;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#response
public class SERVER_GATEWAY_LOGIN_RESPONSE : Packet
{
    public HostAndPort AgentServer;
    public uint AgentServerToken;

    public LoginBlockType BlockType;

    public LoginErrorCode ErrorCode;
    public MaxCurAttempts MaxCurAttempts;
    public Punishment PunishmentData;

    public byte Result;


    public SERVER_GATEWAY_LOGIN_RESPONSE() : base(0xA102)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead<byte>(out Result); // 1   byte    result
        if (Result == 0x01)
        {
            TryRead<uint>(out AgentServerToken); // 4   uint    AgentServer.Token
            AgentServer = new HostAndPort(this);
        }
        else if (Result == 0x02)
        {
            TryRead<LoginErrorCode>(out ErrorCode); // 1   byte    errorCode
            if (ErrorCode == LoginErrorCode.InvalidCredentials)
            {
                MaxCurAttempts = new MaxCurAttempts(this);
            }
            else if (ErrorCode == LoginErrorCode.Blocked)
            {
                TryRead<LoginBlockType>(out BlockType); // 1   byte    blockType
                if (BlockType == LoginBlockType.Punishment)
                {
                    PunishmentData = new Punishment(this);
                }
            }
        }
        else if (Result == 0x03) //Custom Message as A102 result, not supported by every client.
        {
            //I've not looked into this yet.
            TryRead<byte>(out byte unkByte0) // 1   byte    unkByte0
                .TryRead<byte>(out byte unkByte1) // 1   byte    unkByte1
                .TryRead(out string unkAscii) // 2   ushort  Message.Length //     *   string  Message
                .TryRead<ushort>(out ushort unkUshort0); // 2   ushort  unkUShort0
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();

        TryWrite<byte>(Result);
        if (Result == 0x01)
        {
            TryWrite<uint>(AgentServerToken);
            AgentServer.Build(this);
        }
        else if (Result == 0x02)
        {
            TryWrite<byte>((byte)ErrorCode);
            if (ErrorCode == LoginErrorCode.InvalidCredentials)
            {
                MaxCurAttempts.Build(this);
            }
            else if (ErrorCode == LoginErrorCode.Blocked)
            {
                TryWrite<byte>((byte)BlockType);
                if (BlockType == LoginBlockType.Punishment) PunishmentData.Build(this);
            }
        }
        else if (Result == 0x03)
        {
            throw new NotImplementedException();
            // response.WriteUInt8();
            // response.WriteUInt8();
            // response.WriteAscii();
            // response.WriteUInt16();
        }

        return this;
    }

    public static SERVER_GATEWAY_LOGIN_RESPONSE of()
    {
        return new SERVER_GATEWAY_LOGIN_RESPONSE();
    }
}