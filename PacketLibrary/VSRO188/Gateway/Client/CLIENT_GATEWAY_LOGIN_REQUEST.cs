using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#request
public class CLIENT_GATEWAY_LOGIN_REQUEST : Packet
{
    public byte ContentID;
    public string Password;
    public ushort ShardID;
    public string Username;

    public CLIENT_GATEWAY_LOGIN_REQUEST() : base(0x6102, true)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;

    public override async Task Read()
    {
        TryRead(out ContentID)
            .TryRead(out Username)
            .TryRead(out Password)
            .TryRead(out ShardID);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(ContentID);
        TryWrite(Username);
        TryWrite(Password);
        TryWrite(ShardID);
        return this;
    }

    public static Packet of(byte contentId, string username, string password, ushort shardId)
    {
        return new CLIENT_GATEWAY_LOGIN_REQUEST
        {
            ContentID = contentId,
            Username = username,
            Password = password,
            ShardID = shardId
        };
    }
}