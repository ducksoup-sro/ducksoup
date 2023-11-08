using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.CharacterSelection;

public class SelectionCharacter
{
    public uint RefObjId;
    public string Name;
    public byte Scale;
    public byte CurLevel;
    public ulong Exp;
    public ushort Strength;
    public ushort Intelligence;
    public ushort StatPoint;
    public uint CurHP;
    public uint CurMP;
    
    public bool IsDeleting;
    public uint DeleteTime;
    
    public byte GuildMemberClass;
    public bool IsGuildRenameRequired;
    public string CurGuildName;

    public byte AcademyMemberClass;

    public List<SelectionItem> Items = new List<SelectionItem>();
    public List<SelectionItem> AvatarItems = new List<SelectionItem>();
    
    public SelectionCharacter(Packet packet)
    {
        Read(packet);
    }

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

        if (IsDeleting)
        {
            packet.TryRead(out DeleteTime);
        }

        packet.TryRead(out GuildMemberClass)
            .TryRead(out IsGuildRenameRequired);

        if (IsGuildRenameRequired)
        {
            packet.TryRead(out CurGuildName);
        }
        
        packet.TryRead(out AcademyMemberClass)
            .TryRead(out byte itemCount);
        for (var i = 0; i < itemCount; i++)
        {
            Items.Add(new SelectionItem(packet));
        }
        
        packet.TryRead(out byte avatarItemCount);
        for (var i = 0; i < avatarItemCount; i++)
        {
            AvatarItems.Add(new SelectionItem(packet));
        }
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

        if (IsDeleting)
        {
            packet.TryWrite(DeleteTime);
        }

        packet.TryWrite(GuildMemberClass)
            .TryWrite(IsGuildRenameRequired);

        if (IsGuildRenameRequired)
        {
            packet.TryWrite(CurGuildName);
        }
        
        packet.TryWrite(AcademyMemberClass)
            .TryWrite(Items.Count);
        foreach (var selectionItem in Items)
        {
            await selectionItem.Build(packet);
        }
        
        packet.TryWrite(AvatarItems.Count);
        foreach (var selectionItem in AvatarItems)
        {
            await selectionItem.Build(packet);
        }
    }
    
    public _RefObjCommon? _RefObjCommon => Cache.GetRefObjCommonAsync((int)RefObjId).Result;

}