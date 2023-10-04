using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public sealed class SpawnedMonster : SpawnedNpc
{
    public MonsterRarity Rarity;

    public SpawnedMonster(uint objId) :
        base(objId)
    {
    }

    public int MaxHealth
    {
        get
        {
            var baseHealth = RefObjChar.MaxHP;
            switch (Rarity)
            {
                case MonsterRarity.Champion:
                    return baseHealth * 2;

                case MonsterRarity.ChampionParty:
                    return baseHealth * 20;

                case MonsterRarity.GeneralParty:
                    return baseHealth * 10;

                case MonsterRarity.Elite:
                    return baseHealth * 30;

                case MonsterRarity.EliteParty:
                    return baseHealth * 300;

                case MonsterRarity.Giant:
                    return baseHealth * 20;

                case MonsterRarity.GiantParty:
                    return baseHealth * 200;

                default:
                    return baseHealth;
            }
        }
    }

    internal override void Deserialize(Packet packet)
    {
        ParseBionicDetails(packet);

        base.Deserialize(packet);

        packet.TryRead(out Rarity);

        // IsEventMob
        if (RefObjCommon.CodeName128.StartsWith("MOB_EV")) Rarity = MonsterRarity.Event;

        //NPC_MOB_TIEF, NPC_MOB_HUNTER
        if (RefObjCommon.TypeID4 == 2 || RefObjCommon.TypeID4 == 3) packet.TryRead<byte>(out var appearance);
    }
}