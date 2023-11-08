using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHARACTER_SELECTION_JOIN
public class CLIENT_CHARACTER_SELECTION_JOIN_REQUEST : Packet
{
    public string Name;
    
    public CLIENT_CHARACTER_SELECTION_JOIN_REQUEST() : base(0x7001)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out Name);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Name);
        return this;
    }

    public static Task<Packet> of(string name)
    {
        return new CLIENT_CHARACTER_SELECTION_JOIN_REQUEST
        {
            Name = name
        }.Build();
    }
}