using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_AUTH
public class CLIENT_AUTH_REQUEST : Packet
{
    public byte ContentId;
    public byte[] MacAddress;
    public string Password;
    public uint Token;
    public string Username;

    public CLIENT_AUTH_REQUEST() : base(0x6103, true)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out Token);
        TryRead(out Username);
        TryRead(out Password);
        TryRead(out ContentId);
        for (var i = 0; i < 6; i++)
        {
            TryRead<byte>(out var macAddressByte);
            MacAddress[i] = macAddressByte;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Token);
        TryWrite(Username);
        TryWrite(Password);
        TryWrite(ContentId);
        foreach (var b in MacAddress) TryWrite(b);
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_AUTH_REQUEST();
    }
}