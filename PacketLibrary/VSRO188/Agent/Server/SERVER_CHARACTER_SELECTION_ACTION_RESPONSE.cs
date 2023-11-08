using PacketLibrary.VSRO188.Agent.Enums.CharacterSelection;
using PacketLibrary.VSRO188.Agent.Objects.CharacterSelection;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHARACTER_SELECTION_ACTION
public class SERVER_CHARACTER_SELECTION_ACTION_RESPONSE : Packet
{
    public CharacterSelectionAction Action;
    public List<SelectionCharacter> Characters = new();
    public CharacterSelectionErrorCode ErrorCode;
    public byte Result;

    public SERVER_CHARACTER_SELECTION_ACTION_RESPONSE() : base(0xB007)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out Action);
        TryRead(out Result);
        switch (Result)
        {
            case 0x01 when Action == CharacterSelectionAction.List:
            {
                TryRead(out byte characterCount);
                for (var i = 0; i < characterCount; i++) Characters.Add(new SelectionCharacter(this));

                break;
            }
            case 0x02:
                TryRead(out ErrorCode);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Action);
        TryWrite(Result);
        switch (Result)
        {
            case 0x01 when Action == CharacterSelectionAction.List:
            {
                TryWrite(Characters.Count);
                foreach (var selectionCharacter in Characters) await selectionCharacter.Build(this);
                break;
            }
            case 0x02:
                TryWrite(ErrorCode);
                break;
        }

        return this;
    }

    public static Task<Packet> of()
    {
        return new SERVER_CHARACTER_SELECTION_ACTION_RESPONSE().Build();
    }
}