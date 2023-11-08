using PacketLibrary.VSRO188.Agent.Enums.CharacterSelection;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHARACTER_SELECTION_JOIN
public class SERVER_CHARACTER_SELECTION_JOIN_RESPONSE : Packet
{
    public byte Result;
    public CharacterSelectionErrorCode ErrorCode;
    
    public SERVER_CHARACTER_SELECTION_JOIN_RESPONSE() : base(0xB001)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out Result);
        if (Result == 0x02)
        {
            TryRead(out ErrorCode);
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Result);
        if (Result == 0x02)
        {
            TryWrite(ErrorCode);
        }
        return this;
    }

    public static Task<Packet> of()
    {
        return new SERVER_CHARACTER_SELECTION_JOIN_RESPONSE
                { }
            .Build();
    }
}