using PacketLibrary.Enums;
using PacketLibrary.Enums.Agent.CharacterSelection;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHARACTER_SELECTION_ACTION
public class CLIENT_AGENT_CHARACTER_SELECTION_ACTION_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x7007;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public CharacterSelectionAction Action { get; set; }
    public string Name { get; set; }
    public uint RefObjID { get; set; }
    public byte Scale { get; set; }
    public uint EQUIP_SLOT_MAIL { get; set; }
    public uint EQUIP_SLOT_PANTS { get; set; }
    public uint EQUIP_SLOT_BOOTS { get; set; }
    public uint EQUIP_SLOT_WEAPON { get; set; }

    public Task Read(Packet packet)
    {
        Action = (CharacterSelectionAction) packet.ReadUInt8(); // 1   byte    action
        if (Action == CharacterSelectionAction.Create)
        {
            // 2   ushort  Name.Length
            //     *   string  Name
            Name = packet.ReadAscii();
            RefObjID = packet.ReadUInt32(); // 4   uint    RefObjID
            Scale = packet.ReadUInt8(); // 1   byte    Scale
            EQUIP_SLOT_MAIL = packet.ReadUInt32(); // 4   uint    RefItemID // EQUIP_SLOT_MAIL
            EQUIP_SLOT_PANTS = packet.ReadUInt32(); // 4   uint    RefItemID // EQUIP_SLOT_PANTS
            EQUIP_SLOT_BOOTS = packet.ReadUInt32(); // 4   uint    RefItemID // EQUIP_SLOT_BOOTS
            EQUIP_SLOT_WEAPON = packet.ReadUInt32(); // 4   uint    RefItemID // EQUIP_SLOT_WEAPON
        }
        else if (Action == CharacterSelectionAction.Delete ||
                 Action == CharacterSelectionAction.CheckName ||
                 Action == CharacterSelectionAction.Restore)
        {
            // 2 ushort Name.Length
            //     * string Name
            Name = packet.ReadAscii();
        }

        return Task.CompletedTask;
    }


    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Action);
        if (Action == CharacterSelectionAction.Create)
        {
            response.WriteAscii(Name);
            response.WriteUInt32(RefObjID);
            response.WriteUInt8(Scale);
            response.WriteUInt32(EQUIP_SLOT_MAIL);
            response.WriteUInt32(EQUIP_SLOT_PANTS);
            response.WriteUInt32(EQUIP_SLOT_BOOTS);
            response.WriteUInt32(EQUIP_SLOT_WEAPON);
        }
        else if (Action == CharacterSelectionAction.Delete ||
                 Action == CharacterSelectionAction.CheckName ||
                 Action == CharacterSelectionAction.Restore)
        {

            response.WriteAscii(Name);
        }

        return response;
    }

    public static Packet of()
    {
        throw new NotImplementedException();
    }
}