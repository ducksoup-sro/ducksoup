using System;
using API;
using API.Database.SRO_VT_SHARD;
using API.ServiceFactory;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Skill;

public class SkillInfo
{
    public uint Id;
    public bool Enabled;
    public _RefSkill Record => ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefSkill[(int) Id];

    public bool IsPassive => Record.Basic_Activity == 0;
    public bool IsAttack => Record.ParamsContains(6386804);
    public bool IsDot => Record.Basic_Code.StartsWith("SKILL_EU_WARLOCK_DOTA");
    public bool IsImbue => Record.Basic_Activity == 1 && IsAttack;
    public uint Token { get; set; }

    public SkillInfo(uint id, uint token) : this(id, false)
    {
        Token = token;
    }

    public SkillInfo(uint id, bool enabled)
    {
        
        Id = id;
        Enabled = enabled;
    }

    internal static SkillInfo FromPacket(Packet packet)
    {
        return new SkillInfo(packet.ReadUInt32(), packet.ReadBool());
    }
}