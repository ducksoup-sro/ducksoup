using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public sealed class SpawnedCos : SpawnedNpc
{
    public string Name { get; set; }
    public string GuildName { get; set; }
    public string OwnerName { get; set; }
    public uint OwnerUniqueId { get; set; }
    public SpawnedCos(uint objId) :
        base(objId) { }

    internal override void Deserialize(Packet packet)
    {
        ParseBionicDetails(packet);
        base.Deserialize(packet);

        var refObj = RefObjCommon;

        if (refObj.TypeID4 == 2 //NPC_COS_TRANSPORT
            || refObj.TypeID4 == 3 //NPC_COS_P_GROWTH
            || refObj.TypeID4 == 4 //NPC_COS_P_ABILITY
            || refObj.TypeID4 == 5 //NPC_COS_GUILD
            || refObj.TypeID4 == 6 //NPC_COS_CAPTURED
            || refObj.TypeID4 == 7 //NPC_COS_QUEST
            || refObj.TypeID4 == 8 //NPC_COS_QUEST
            || refObj.TypeID4 == 9) // COS_PET2
        {
            if (refObj.TypeID4 == 3 ||  // NPC_COS_P_GROWTH
                refObj.TypeID4 == 4 ||  //NPC_COS_P_ABILITY
                refObj.TypeID4 == 9)    // COS_PET2
                Name = packet.ReadAscii();
            else if (refObj.TypeID4 == 5) //NPC_COS_GUILD
                GuildName = packet.ReadAscii();

            if (refObj.TypeID4 == 2     //NPC_COS_TRASNPORT
                || refObj.TypeID4 == 3  //NPC_COS_P_GROWTH
                || refObj.TypeID4 == 4  //NPC_COS_P_ABILITY
                || refObj.TypeID4 == 5  //NPC_COS_GUILD
                || refObj.TypeID4 == 6  //NPC_COS_CAPTURED
                || refObj.TypeID4 == 9) //COS_PET2
            {
                OwnerName = packet.ReadAscii();

                if (refObj.TypeID4 == 2 //NPC_COS_TRASNPORT
                    || refObj.TypeID4 == 3 //NPC_COS_P_GROWTH
                    || refObj.TypeID4 == 4 //NPC_COS_ABILITY
                    || refObj.TypeID4 == 5 //NPC_COS_GUILD
                    || refObj.TypeID4 == 9) //COS_PET2 
                {
                    packet.ReadUInt8(); //Owner job type

                    if (refObj.TypeID4 == 2 //NPC_COS_TRASNPORT
                        || refObj.TypeID4 == 3 //NPC_COS_P_GROWTH
                        || refObj.TypeID4 == 5 //NPC_COS_GUILD
                        || refObj.TypeID4 == 9) //COS_PET2 
                    {
                        packet.ReadUInt8(); //Owner PVP state

                        if (refObj.TypeID4 == 5) //NPC_COS_GUILD
                        {
                            packet.ReadUInt32(); //OwnerRefID guild foo
                        }
                    }
                }
            }

            OwnerUniqueId = packet.ReadUInt32();
            if (refObj.TypeID4 == 9)
                packet.ReadUInt8(); //???
        }
    }
}