using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Client;

public class CLIENT_GATEWAY_LOGIN_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x6102;
    public static bool Encrypted => true;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public byte ContentID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public ushort ShardID { get; set; }

    public Task Read(Packet packet)
    {
        ContentID = packet.ReadUInt8(); // 1   byte    Content.ID
        // 2   ushort  Username.Length
        //     *   string  Username
        Username = packet.ReadAscii();
        // 2   ushort  Password.Length
        //     *   string  Password
        Password = packet.ReadAscii();
        ShardID = packet.ReadUInt16(); // 2   ushort  Shard.ID

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(ContentID);
        response.WriteAscii(Username);
        response.WriteAscii(Password);
        response.WriteUInt16(ShardID);

        return response;
    }

    public static Packet of(byte contentId, string username, string password, ushort shardId)
    {
        return new CLIENT_GATEWAY_LOGIN_REQUEST()
        {
            ContentID = contentId,
            Username = username,
            Password = password,
            ShardID = shardId
        }.Build();
    }
}