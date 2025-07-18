using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.CharacterSelection;

public class SelectionCharacter
{
    public byte AcademyMemberClass;
    public List<SelectionItem> AvatarItems = new List<SelectionItem>();
    public string CurGuildName;
    public uint CurHP;
    public byte CurLevel;
    public uint CurMP;
    public uint DeleteTime;
    public ulong Exp;

    public byte GuildMemberClass;
    public ushort Intelligence;

    public bool IsDeleting;
    public bool IsGuildRenameRequired;

    public List<SelectionItem> Items = new List<SelectionItem>();
    public string Name;
    public uint RefObjId;
    public byte Scale;
    public ushort StatPoint;
    public ushort Strength;

    public SelectionCharacter(Packet packet)
    {
        Read(packet);
    }

    public _RefObjCommon? _RefObjCommon => Cache.GetRefObjCommonAsync((int)RefObjId).Result;

    public async Task Read(Packet packet)
    {
        packet.TryRead<uint>(out RefObjId)
            .TryReadString(out Name)
            .TryRead<byte>(out Scale)
            .TryRead<byte>(out CurLevel)
            .TryRead<ulong>(out Exp)
            .TryRead<ushort>(out Strength)
            .TryRead<ushort>(out Intelligence)
            .TryRead<ushort>(out StatPoint)
            .TryRead<uint>(out CurHP)
            .TryRead<uint>(out CurMP)
            .TryRead<bool>(out IsDeleting);

        if (IsDeleting) packet.TryRead<uint>(out DeleteTime);

        packet.TryRead<byte>(out GuildMemberClass)
            .TryRead<bool>(out IsGuildRenameRequired);

        if (IsGuildRenameRequired) packet.TryReadString(out CurGuildName);

        packet.TryRead<byte>(out AcademyMemberClass)
            .TryRead<byte>(out byte itemCount);
        for (int i = 0; i < itemCount; i++)
        {
            Items.Add(new SelectionItem(packet));
        }

        packet.TryRead<byte>(out byte avatarItemCount);
        for (int i = 0; i < avatarItemCount; i++)
        {
            AvatarItems.Add(new SelectionItem(packet));
        }
    }

    public async Task Build(Packet packet)
    {
        packet.TryWrite<uint>(RefObjId)
            .TryWriteString(Name)
            .TryWrite<byte>(Scale)
            .TryWrite<byte>(CurLevel)
            .TryWrite<ulong>(Exp)
            .TryWrite<ushort>(Strength)
            .TryWrite<ushort>(Intelligence)
            .TryWrite<ushort>(StatPoint)
            .TryWrite<uint>(CurHP)
            .TryWrite<uint>(CurMP)
            .TryWrite<bool>(IsDeleting);

        if (IsDeleting) packet.TryWrite<uint>(DeleteTime);

        packet.TryWrite<byte>(GuildMemberClass)
            .TryWrite<bool>(IsGuildRenameRequired);

        if (IsGuildRenameRequired) packet.TryWriteString(CurGuildName);

        packet.TryWrite<byte>(AcademyMemberClass)
            .TryWrite<byte>((byte)Items.Count);
        foreach (SelectionItem selectionItem in Items)
        {
            await selectionItem.Build(packet);
        }

        packet.TryWrite<byte>((byte)AvatarItems.Count);
        foreach (SelectionItem selectionItem in AvatarItems)
        {
            await selectionItem.Build(packet);
        }
    }
}