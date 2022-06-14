using PacketLibrary.Enums;
using PacketLibrary.Enums.Gateway;
using PacketLibrary.Objects.Gateway;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#response
public class SERVER_GATEWAY_LOGIN_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xA102;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result { get; set; }
    public uint AgentServerToken { get; set; }
    public HostAndPort AgentServer { get; set; }
    
    public LoginErrorCode ErrorCode { get; set; }
    public MaxCurAttempts MaxCurAttempts { get; set; }

    public LoginBlockType BlockType { get; set; }
    public Punishment PunishmentData { get; set; }

    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        if (Result == 0x01)
        {
            AgentServerToken = packet.ReadUInt32(); // 4   uint    AgentServer.Token
            AgentServer = new HostAndPort(packet);
        }
        else if (Result == 0x02)
        {
            ErrorCode = (LoginErrorCode) packet.ReadUInt8(); // 1   byte    errorCode
            if (ErrorCode == LoginErrorCode.InvalidCredentials)
            {
                MaxCurAttempts = new MaxCurAttempts(packet);
            }
            else if (ErrorCode == LoginErrorCode.Blocked)
            {
                BlockType = (LoginBlockType) packet.ReadUInt8(); // 1   byte    blockType
                if (BlockType == LoginBlockType.Punishment)
                {
                    PunishmentData = new Punishment(packet);
                }
            }
        }
        else if (Result == 0x03) //Custom Message as A102 result, not supported by every client.
        {
            //I've not looked into this yet.
            packet.ReadUInt8(); // 1   byte    unkByte0
            packet.ReadUInt8(); // 1   byte    unkByte1
            // 2   ushort  Message.Length
            //     *   string  Message
            packet.ReadAscii();
            packet.ReadUInt16(); // 2   ushort  unkUShort0
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);

        response.WriteUInt8(Result);
        if (Result == 0x01)
        {
            response.WriteUInt32(AgentServerToken);
            AgentServer.build(response);
        }
        else if (Result == 0x02)
        {
            response.WriteUInt8(ErrorCode);
            if (ErrorCode == LoginErrorCode.InvalidCredentials)
            {
                MaxCurAttempts.build(response);
            }
            else if (ErrorCode == LoginErrorCode.Blocked)
            {
                response.WriteUInt8(BlockType);
                if (BlockType == LoginBlockType.Punishment)
                {
                    PunishmentData.build(response);
                }
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

        return response;
    }

    public static Packet of()
    {
        throw new NotImplementedException();
    }
}