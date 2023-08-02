using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
// https://www.elitepvpers.com/forum/sro-coding-corner/3970615-release-characterdata-entityspawn.html
public sealed class SpawnedCos : SpawnedNpc
{
    public string Name;
    public string GuildName;
    public string OwnerName;
    public uint OwnerUniqueId;

    public SpawnedCos(uint objId) :
        base(objId)
    {
    }

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
            if (refObj.TypeID4 == 5)
            {
                //NPC_COS_GUILD
                packet.TryRead(out GuildName);
            }
            else
            {
                packet.TryRead(out OwnerName);
            }

            // if (refObj.TypeID4 == 3 ||  // NPC_COS_P_GROWTH
            //     refObj.TypeID4 == 4 ||  //NPC_COS_P_ABILITY
            //     refObj.TypeID4 == 9)    // COS_PET2
            //     Name = packet.ReadAscii();
            // else if (refObj.TypeID4 == 5) //NPC_COS_GUILD
            //     GuildName = packet.ReadAscii();
            //
            // if (refObj.TypeID4 == 2     //NPC_COS_TRASNPORT
            //     || refObj.TypeID4 == 3  //NPC_COS_P_GROWTH
            //     || refObj.TypeID4 == 4  //NPC_COS_P_ABILITY
            //     || refObj.TypeID4 == 5  //NPC_COS_GUILD
            //     || refObj.TypeID4 == 6  //NPC_COS_CAPTURED
            //     || refObj.TypeID4 == 9) //COS_PET2
            // {
            //     OwnerName = packet.ReadAscii();

            if (refObj.TypeID4 == 2 //NPC_COS_TRASNPORT
                || refObj.TypeID4 == 3 //NPC_COS_P_GROWTH
                || refObj.TypeID4 == 4 //NPC_COS_ABILITY
                || refObj.TypeID4 == 5 //NPC_COS_GUILD
                || refObj.TypeID4 == 9) //COS_PET2 
            {
                packet.TryRead<byte>(out var ownerJobType);

                // if (refObj.TypeID4 == 2 //NPC_COS_TRASNPORT
                //     || refObj.TypeID4 == 3 //NPC_COS_P_GROWTH
                //     || refObj.TypeID4 == 5 //NPC_COS_GUILD
                //     || refObj.TypeID4 == 9) //COS_PET2 
                // {
                //     packet.ReadUInt8(); //Owner PVP state
                //
                //     if (refObj.TypeID4 == 5) //NPC_COS_GUILD
                //     {
                //         packet.ReadUInt32(); //OwnerRefID guild foo
                //     }
                // }
                if (refObj.TypeID4 != 4) //NO NPC_COS_P (Ability)
                {
                    packet.TryRead<byte>(out var murderFlag); //0 = White, 1 = Purple, 2 = Red
                }
                
                if(refObj.TypeID4 == 5)
                {
                    //NPC_COS_GUILD
                    packet.TryRead<uint>(out var ownerRegObjId);
                }
            }
            // }

            packet.TryRead<uint>(out OwnerUniqueId);
            if (refObj.TypeID4 == 9)
                packet.TryRead<byte>(out var unk1);
        }
    }
}