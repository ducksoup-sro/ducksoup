using API;
using API.Database.SRO_VT_SHARD;
using API.ServiceFactory;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedSpellArea : SpawnedEntity
{
    public uint SkillId;
    public C_RefSkill Record => ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefSkill[(int) SkillId];

    internal static SpawnedSpellArea FromPacket(Packet packet)
    {
        //UNK0

        packet.ReadUInt16();

        var spellArea = new SpawnedSpellArea
        {
            SkillId = packet.ReadUInt32(),
            UniqueId = packet.ReadUInt32()
        };

        spellArea.Movement.Source = Objects.Position.FromPacket(packet);

        return spellArea;
    }
}