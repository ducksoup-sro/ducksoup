using PacketLibrary.VSRO188.Agent.Enums.CharacterSelection;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHARACTER_SELECTION_ACTION
public class CLIENT_CHARACTER_SELECTION_ACTION_REQUEST : Packet
{
    public CharacterSelectionAction Action;
    public string Name;
    public uint CharacterRefObjId;
    public byte Scale;
    public uint ChestRefObjId;
    public uint PantsRefObjId;
    public uint BootsRefObjId;
    public uint WeaponRefObjId;
    
    public CLIENT_CHARACTER_SELECTION_ACTION_REQUEST() : base(0x7007)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out Action);
        switch (Action)
        {
            case CharacterSelectionAction.Create:
                TryRead(out Name);
                TryRead(out CharacterRefObjId);
                TryRead(out Scale);
                TryRead(out ChestRefObjId);
                TryRead(out PantsRefObjId);
                TryRead(out BootsRefObjId);
                TryRead(out WeaponRefObjId);
                break;
            case CharacterSelectionAction.Delete:
            case CharacterSelectionAction.CheckName:
            case CharacterSelectionAction.Restore:
                TryRead(out Name);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Action);
        switch (Action)
        {
            case CharacterSelectionAction.Create:
                TryWrite(Name);
                TryWrite(CharacterRefObjId);
                TryWrite(Scale);
                TryWrite(ChestRefObjId);
                TryWrite(PantsRefObjId);
                TryWrite(BootsRefObjId);
                TryWrite(WeaponRefObjId);
                break;
            case CharacterSelectionAction.Delete:
            case CharacterSelectionAction.CheckName:
            case CharacterSelectionAction.Restore:
                TryWrite(Name);
                break;
        }
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_CHARACTER_SELECTION_ACTION_REQUEST();
    }
}