using System.Collections.Generic;
using System.Linq;
using API;
using API.Database.SRO_VT_SHARD;
using API.ServiceFactory;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public sealed class SpawnedPlayer : SpawnedBionic
{
    public string Name { get; set; }
    public Job Job { get; set; }
    public byte JobLevel { get; set; }
    public ScrollState ScrollMode { get; set; }
    public PvpState PvpState { get; set; }
    public bool InCombat { get; set; }
    public bool OnTransport { get; set; }
    public uint TransportUniqueId { get; set; }
    public byte PKFlag { get; set; }
    public InteractMode InteractMode { get; set; }
    public byte Scale { get; set; }
    public byte HwanLevel { get; set; }
    public PvpState PvpCape { get; set; }
    public ExpIcon AutoInverstExp { get; set; }
    public byte InventorySize { get; set; }
    public Dictionary<_RefObjCommon, byte> Inventory { get; set; }
    public byte AvatarInventorySize { get; set; }
    public Dictionary<_RefObjCommon, byte> Avatars { get; set; }
    public SpawnedPlayerStall Stall { get; set; }
    public SpawnedPlayerGuild Guild { get; set; }
    public bool WearsJobSuite { get; set; }

    public SpawnedPlayer(uint objId)
        : base(objId)
    {
    }

    internal void Deserialize(Packet packet)
    {
        Scale = packet.ReadUInt8();
        HwanLevel = packet.ReadUInt8();
        PvpCape = (PvpState) packet.ReadUInt8();
        AutoInverstExp = (ExpIcon) packet.ReadUInt8();
        InventorySize = packet.ReadUInt8();

        var itemCount = packet.ReadUInt8();
        Inventory = new Dictionary<_RefObjCommon, byte>();

        for (var i = 0; i < itemCount; i++)
        {
            var itemId = packet.ReadUInt32();
            var itemObj = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon
                .FirstOrDefault(c => c.Value.ID == itemId).Value;

            if (itemObj == null)
            {
                packet.ReadUInt8();
                continue;
            }

            //Check if the player wears a job-suit
            if (itemObj.TypeID2 == 1 && itemObj.TypeID3 == 7 && itemObj.TypeID4 is not 4 or 5)
                WearsJobSuite = true;

            if (itemObj.TypeID2 == 1)
                Inventory.Add(itemObj, packet.ReadUInt8()); //Item object and the "+" value as value
        }

        Avatars = new Dictionary<_RefObjCommon, byte>();

        AvatarInventorySize = packet.ReadUInt8();
        itemCount = packet.ReadUInt8();

        for (var i = 0; i < itemCount; i++)
        {
            var itemId = packet.ReadUInt32();
            var itemObj = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon
                .FirstOrDefault(c => c.Value.ID == itemId).Value;
            if (itemObj == null)
            {
                packet.ReadUInt8();
                continue;
            }

            Avatars.Add(itemObj, packet.ReadUInt8()); //Item object and the "+" value as value
        }


        var hasMask = packet.ReadBool();
        if (hasMask)
        {
            var maskId = packet.ReadUInt32();
            var maskObj = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon
                .FirstOrDefault(c => c.Value.ID == maskId).Value;
            if (maskObj == null)
            {
                return;
            }

            if (maskObj.TypeID1 == RefObjCommon.TypeID1 || maskObj.TypeID2 == RefObjCommon.TypeID2)
            {
                //duplicated player!
                var scale = packet.ReadUInt8();
                itemCount = packet.ReadUInt8();
                for (var i = 0; i < itemCount; i++)
                    packet.ReadUInt32(); //item id
            }
        }

        ParseBionicDetails(packet);
        
        Name = packet.ReadAscii();
        Job = (Job) packet.ReadUInt8();
        JobLevel = packet.ReadUInt8();
        PvpState = (PvpState) packet.ReadUInt8();
        OnTransport = packet.ReadBool();
        InCombat = packet.ReadBool();

        if (OnTransport)
        {
            TransportUniqueId = packet.ReadUInt32();
        }

        ScrollMode = (ScrollState) packet.ReadUInt8();
        InteractMode = (InteractMode) packet.ReadUInt8();

        packet.ReadUInt8(); //unkByte4

        var guildName = packet.ReadAscii();

        //Check if the player is wearing job suite, if not the GUILD object has to be parsed!
        if (!WearsJobSuite)
        {
            Guild = SpawnedPlayerGuild.FromPacket(packet);
            Guild.Name = guildName;
        }
        else
        {
            Guild = new SpawnedPlayerGuild {Name = guildName};
        }

        if (InteractMode == InteractMode.P2N_TALK)
        {
            Stall = SpawnedPlayerStall.FromPacket(packet);
        }

        packet.ReadUInt8(); //Equipment Cooldown

        PKFlag = packet.ReadUInt8(); //PKFlag
    }
}