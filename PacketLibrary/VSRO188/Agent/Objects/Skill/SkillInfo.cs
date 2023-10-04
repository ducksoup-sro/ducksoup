using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Skill;

public class SkillInfo
{
    public bool Enabled;
    public uint Id;

    public SkillInfo(uint id, uint token) : this(id, false)
    {
        Token = token;
    }

    public SkillInfo(uint id, bool enabled)
    {
        Id = id;
        Enabled = enabled;
    }

    public _RefSkill Record => Cache.GetRefSkillAsync((int)Id).Result;
    public bool IsPassive => Record.Basic_Activity == 0;
    public bool IsAttack => Record.ParamsContains(6386804);
    public bool IsDot => Record.Basic_Code.StartsWith("SKILL_EU_WARLOCK_DOTA");
    public bool IsImbue => Record.Basic_Activity == 1 && IsAttack;
    public uint Token { get; set; }

    internal static SkillInfo FromPacket(Packet packet)
    {
        packet.TryRead<uint>(out var id)
            .TryRead<bool>(out var enabled);
        return new SkillInfo(id, enabled);
    }
}