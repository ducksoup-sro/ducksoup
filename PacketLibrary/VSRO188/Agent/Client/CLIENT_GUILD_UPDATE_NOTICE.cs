using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

public class CLIENT_GUILD_UPDATE_NOTICE : Packet
{
    public string Title;
    public string Text;

    public CLIENT_GUILD_UPDATE_NOTICE() : base(0x70F9)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out Title);
        TryRead(out Text);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Title);
        TryWrite(Text);
        return this;
    }

    public static Task<Packet> of(string title, string text)
    {
        return new CLIENT_GUILD_UPDATE_NOTICE
        {
            Title = title,
            Text = text
        }.Build();
    }
}