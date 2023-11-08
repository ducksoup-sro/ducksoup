using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.CharacterSelection;

public class SelectionCharacter
{
    public byte AcademyMemberClass;
    public List<SelectionItem> AvatarItems = new();
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

    public List<SelectionItem> Items = new();
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
        packet.TryRead(out RefObjId)
            .TryRead(out Name)
            .TryRead(out Scale)
            .TryRead(out CurLevel)
            .TryRead(out Exp)
            .TryRead(out Strength)
            .TryRead(out Intelligence)
            .TryRead(out StatPoint)
            .TryRead(out CurHP)
            .TryRead(out CurMP)
            .TryRead(out IsDeleting);

        if (IsDeleting) packet.TryRead(out DeleteTime);

        packet.TryRead(out GuildMemberClass)
            .TryRead(out IsGuildRenameRequired);

        if (IsGuildRenameRequired) packet.TryRead(out CurGuildName);

        packet.TryRead(out AcademyMemberClass)
            .TryRead(out byte itemCount);
        for (var i = 0; i < itemCount; i++) Items.Add(new SelectionItem(packet));

        packet.TryRead(out byte avatarItemCount);
        for (var i = 0; i < avatarItemCount; i++) AvatarItems.Add(new SelectionItem(packet));
    }

    public async Task Build(Packet packet)
    {
        packet.TryWrite(RefObjId)
            .TryWrite(Name)
            .TryWrite(Scale)
            .TryWrite(CurLevel)
            .TryWrite(Exp)
            .TryWrite(Strength)
            .TryWrite(Intelligence)
            .TryWrite(StatPoint)
            .TryWrite(CurHP)
            .TryWrite(CurMP)
            .TryWrite(IsDeleting);

        if (IsDeleting) packet.TryWrite(DeleteTime);

        packet.TryWrite(GuildMemberClass)
            .TryWrite(IsGuildRenameRequired);

        if (IsGuildRenameRequired) packet.TryWrite(CurGuildName);

        packet.TryWrite(AcademyMemberClass)
            .TryWrite(Items.Count);
        foreach (var selectionItem in Items) await selectionItem.Build(packet);

        packet.TryWrite(AvatarItems.Count);
        foreach (var selectionItem in AvatarItems) await selectionItem.Build(packet);
    }
}