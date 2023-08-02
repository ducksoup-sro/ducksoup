using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedSpellArea : SpawnedEntity
{
    public uint SkillId;
    public _RefSkill Record => Cache.GetRefSkillAsync((int) SkillId).Result;

    internal static SpawnedSpellArea FromPacket(Packet packet)
    {
        packet.TryRead<ushort>(out var unk0)
            .TryRead<uint>(out var skillId)
            .TryRead<uint>(out var uniqueId);
        
        var spellArea = new SpawnedSpellArea
        {
            SkillId = skillId,
            UniqueId = uniqueId
        };

        spellArea.Movement.Source = Position.FromPacket(packet);

        return spellArea;
    }
}