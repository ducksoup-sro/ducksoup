using PacketLibrary.VSRO188.Agent.Enums.CharacterSelection;
using PacketLibrary.VSRO188.Agent.Objects.CharacterSelection;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHARACTER_SELECTION_ACTION
public class SERVER_CHARACTER_SELECTION_ACTION_RESPONSE : Packet
{
    public CharacterSelectionAction Action;
    public List<SelectionCharacter> Characters = new List<SelectionCharacter>();
    public CharacterSelectionErrorCode ErrorCode;
    public byte Result;

    public SERVER_CHARACTER_SELECTION_ACTION_RESPONSE() : base(0xB007)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead<CharacterSelectionAction>(out Action);
        TryRead<byte>(out Result);
        switch (Result)
        {
            case 0x01 when Action == CharacterSelectionAction.List:
            {
                TryRead(out byte characterCount);
                for (int i = 0; i < characterCount; i++)
                {
                    Characters.Add(new SelectionCharacter(this));
                }

                break;
            }
            case 0x02:
                TryRead<CharacterSelectionErrorCode>(out ErrorCode);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<byte>((byte)Action);
        TryWrite<byte>(Result);
        switch (Result)
        {
            case 0x01 when Action == CharacterSelectionAction.List:
            {
                TryWrite<byte>((byte)Characters.Count);
                foreach (SelectionCharacter selectionCharacter in Characters)
                {
                    await selectionCharacter.Build(this);
                }
                break;
            }
            case 0x02:
                TryWrite<ushort>((ushort)ErrorCode);
                break;
        }

        return this;
    }

    public static Task<Packet> of()
    {
        return new SERVER_CHARACTER_SELECTION_ACTION_RESPONSE().Build();
    }
}