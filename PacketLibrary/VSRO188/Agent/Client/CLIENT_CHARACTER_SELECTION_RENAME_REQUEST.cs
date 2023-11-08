using PacketLibrary.VSRO188.Agent.Enums.CharacterSelection;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHARACTER_SELECTION_RENAME
public class CLIENT_CHARACTER_SELECTION_RENAME_REQUEST : Packet
{
    public CharacterSelectionRenameAction RenameAction;
    public string CurName;
    public string NewName;
    public string GuildName;
    
    public CLIENT_CHARACTER_SELECTION_RENAME_REQUEST() : base(0x7450)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out RenameAction);
        switch (RenameAction)
        {
            case CharacterSelectionRenameAction.CharacterRename:
            case CharacterSelectionRenameAction.GuildRename:
                TryRead(out CurName);
                TryRead(out NewName);
                break;
            case CharacterSelectionRenameAction.GuildNameCheck:
                TryRead(out GuildName);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(RenameAction);
        switch (RenameAction)
        {
            case CharacterSelectionRenameAction.CharacterRename:
            case CharacterSelectionRenameAction.GuildRename:
                TryWrite(CurName);
                TryWrite(NewName);
                break;
            case CharacterSelectionRenameAction.GuildNameCheck:
                TryWrite(GuildName);
                break;
        }
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_CHARACTER_SELECTION_RENAME_REQUEST();
    }
}